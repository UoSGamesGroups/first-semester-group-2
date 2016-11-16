using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	float Speed = 5;
	Rigidbody2D thisRigidbody2d;
	bool grounded;
	public float jumpHeight;
	float cameraHeight;
    bool jumped;

	// Use this for initialization
	void Start () {
		thisRigidbody2d = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		if (Input.GetAxisRaw ("Horizontal") > 0.01f) {
			this.transform.position += new Vector3(Speed,0,0) * Time.deltaTime;
            this.transform.localScale = new Vector3(0.15f, 0.15f, 1);
		}
		if (Input.GetAxisRaw ("Horizontal") < -0.01f) {
			this.transform.position += new Vector3(-Speed,0,0) * Time.deltaTime;
            this.transform.localScale = new Vector3(-0.15f, 0.15f, 1);
        }
		if (Input.GetAxisRaw("Vertical") > 0.01f && jumped == false && thisRigidbody2d.velocity.y <= 0.5) {
			Jump ();
            jumped = true;
		}
        if (Input.GetAxisRaw("Vertical") > -0.01f && Input.GetAxisRaw("Vertical") < 0.01f && jumped == true)
        {
            jumped = false;
        }



    }

	public void Jump(){
		if (grounded == true){
			thisRigidbody2d.velocity =new Vector2 (0, jumpHeight);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){

		Debug.Log ("We Touched " + coll.gameObject.tag);

		if (coll.gameObject.tag == "Ground") {
			grounded = true;
			Debug.Log ("grounded is " + grounded);
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") {
			grounded = false;
			Debug.Log ("grounded is " + grounded);
		}
	}
		
}
