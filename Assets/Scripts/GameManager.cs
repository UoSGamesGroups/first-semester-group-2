using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] cameras;
	int cameraNumber = 0;
	// Use this for initialization
	void Start () {
	
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
