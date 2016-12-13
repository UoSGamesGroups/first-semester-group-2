using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	string BooksSaved;
    string showString;
    public Text ScoreText;
    public Text doorUnockedText;
	// Update is called once per frame
	
    void Start() {
        doorUnockedText.enabled = false;
		PlayerPrefs.SetInt("BooksSaved", 0);
    }

    void Update () {
		BooksSaved = PlayerPrefs.GetInt("BooksSaved").ToString();
		showString = BooksSaved + "/4";
		if (PlayerPrefs.GetInt("BooksSaved") >= 4) {
            doorUnockedText.enabled = true;
        }
        ScoreText.text = showString;
	}

	public void SaveTime(float Time){
		
	}
}
