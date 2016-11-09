using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BucketSceneDoor : MonoBehaviour {

    public void OpenMaze() {
        SceneManager.LoadScene(2);
    }
}
