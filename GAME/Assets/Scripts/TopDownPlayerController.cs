using UnityEngine;
using System.Collections;

public class TopDownPlayerController : MonoBehaviour {

    public float Speed = 10;
    Rigidbody2D thisRigidbody;
	public GameObject LevelToOpen;

	// Use this for initialization
	void Start () {
        thisRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        thisRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal")*Speed, Input.GetAxisRaw("Vertical")*Speed, 0);
    }

    void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Door"){
			OpenDoor ();
			Debug.Log ("space to open Door");
			//this.GetComponent<PlayerController>().
		}
    }

	void OpenDoor(){
		if (Input.GetButtonDown ("Interact")) {
			this.transform.position = new Vector3 (0, 0, 0);
			Destroy (GameObject.FindWithTag ("Level"));
			Instantiate (LevelToOpen);
		}
	}
}
