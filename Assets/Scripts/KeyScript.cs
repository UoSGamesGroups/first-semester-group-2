using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
	public int thisLevelNumber;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("LevelNumber") > thisLevelNumber) {
			this.gameObject.SetActive (false);
		}
	}

}
