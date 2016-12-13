using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class BucketSceneDoor : MonoBehaviour {

	GameManager gameManager; 

	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

    public void OpenMaze() {
        //SceneManager.LoadScene(2);
		Application.LoadLevel(2);
		gameManager.FinishLevel();

    }
}
