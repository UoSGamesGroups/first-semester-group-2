using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] Levels;
    int PlayerScore;
	float TimeCounter;
	bool finished;
	// Use this for initialization
	void Start () {
		TimeCounter = 0;
		Instantiate (Levels[0], new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
        PlayerScore = 0;
	}

	void Update(){
		if (!finished){
			TimeCounter += Time.deltaTime;
		}
	}

	public void FinishLevel(){
		finished = true;
		string Timer = " ";
		int minutes = 0;
		string seconds;
		if (TimeCounter < 60){
			Timer = Mathf.Round(TimeCounter).ToString() + "s";
		}else{
			while (TimeCounter >= 60){
				minutes++;
				TimeCounter -= 60;
			}
			if (TimeCounter < 10) {
				seconds = 0 + Mathf.Round(TimeCounter).ToString ();
			} else {
				seconds = TimeCounter.ToString();
			}
				

			Timer = minutes.ToString() + ":" + seconds;
		}

		PlayerPrefs.SetString("TimeTaken", Timer);


	}
}
