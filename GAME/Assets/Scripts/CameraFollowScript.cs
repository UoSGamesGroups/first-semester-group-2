using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    public GameObject Camera;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, new Vector3(this.transform.position.x, 0, -10f), 0.1f);
	}
}
