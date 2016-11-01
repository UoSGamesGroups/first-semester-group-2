using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] cameras;
	public GameObject[] Levels;
	int cameraNumber = 0;
	// Use this for initialization
	void Start () {
		Instantiate (Levels[0], new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("PPLevelNumber is " + PlayerPrefs.GetInt("LevelNumber"));
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
