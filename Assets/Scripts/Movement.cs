using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 50f;

	Vector3 direction;
	CharacterController CC;

	// Use this for initialization
	void Start () 
	{
		CC = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
	}

	void Move()
	{
		CC.SimpleMove(direction * speed * Time.deltaTime);
		direction = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized; 
	}
}
