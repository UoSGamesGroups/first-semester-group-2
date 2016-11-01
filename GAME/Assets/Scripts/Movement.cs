using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	float Speed = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		if (Input.GetAxis ("Horizontal") > 0.01f) {
			this.transform.position += new Vector3(Speed,0,0) * Time.deltaTime;
            this.transform.localScale = new Vector3(0.06f, 0.14f, 1);
		}
		if (Input.GetAxis ("Horizontal") < -0.01f) {
			this.transform.position += new Vector3(-Speed,0,0) * Time.deltaTime;
            this.transform.localScale = new Vector3(-0.06f, 0.14f, 1);
        }

	}
}
