using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] cameras;
	public GameObject street;
	public GameObject[] Levels;
	int cameraNumber = 0;
	// Use this for initialization
	void Start () {
		Instantiate (street, new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// This will cycle through the cameras throughout the scene
	public void SwitchCamera(){
		if (cameraNumber < cameras.Length - 1) {
			cameraNumber += 1;
		} else {
			cameraNumber = 0;
		}

		foreach(GameObject camera in cameras){
			camera.SetActive(false);
		}
		cameras[cameraNumber].SetActive(true);
	}
}
