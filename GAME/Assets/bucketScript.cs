using UnityEngine;
using System.Collections;

public class bucketScript : MonoBehaviour {

    public bool beingHeld;
    bool onBooks;
    GameObject BucketHolder;
    GameObject Player;
    bool used = false;

    void start() {

    }

    void Update() { 
        if (Player == null) {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if (beingHeld == false && onBooks == true) {
            
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.transform.position = BucketHolder.transform.position;
			this.GetComponent<BoxCollider2D>().enabled = false;
            if (used == false)
            {
                used = true;
				PlayerPrefs.SetInt("BooksSaved", PlayerPrefs.GetInt("BooksSaved") + 1);
                Player.GetComponent<PlayerController>().BucketPositioned();
                this.gameObject.tag = "UsedBucket";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Touched Bucket Holder");
        if (other.gameObject.tag == "BucketHolder") {
            BucketHolder = other.gameObject;
            onBooks = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "BucketHolder")
        {
            BucketHolder = null;
            onBooks = false;
            Debug.Log("Left Bucket Holder");
        }
    }
}
