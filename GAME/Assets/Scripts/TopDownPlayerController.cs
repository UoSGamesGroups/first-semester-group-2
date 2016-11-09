using UnityEngine;
using System.Collections;

public class TopDownPlayerController : MonoBehaviour {

    public float Speed = 10;
    Rigidbody2D thisRigidbody;

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

    void OnTriggerEnter2D() {

    }
}
