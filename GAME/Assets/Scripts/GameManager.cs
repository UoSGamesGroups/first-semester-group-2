using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] Levels;
    int PlayerScore;
	// Use this for initialization
	void Start () {
		Instantiate (Levels[0], new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
        PlayerScore = 0;
	}
}
