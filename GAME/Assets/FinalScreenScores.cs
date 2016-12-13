using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScreenScores : MonoBehaviour {

	public Text energyText;
	public Text bookText;
	public Text timeText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = PlayerPrefs.GetString("TimeTaken");
		bookText.text = PlayerPrefs.GetInt("BooksSaved").ToString()+ "/6";
		energyText.text = PlayerPrefs.GetString("EnergyLeft");
	}
}
