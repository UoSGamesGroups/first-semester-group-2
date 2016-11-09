using UnityEngine;
using System.Collections;

public class MazeLightingScript : MonoBehaviour {

    float lightningTimer;
    public Animator mapAnimator;
    int nextAnimation;
    AudioSource thunderSource;
    public AudioClip thunder;

	// Use this for initialization
	void Start () {
        nextAnimation = Random.Range(1, 4);
        thunderSource = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        lightningTimer -= Time.deltaTime;
        if (lightningTimer <= 0) {
            lightningTimer = Random.Range(6, 7);
            mapAnimator.SetTrigger(nextAnimation.ToString());
            nextAnimation = Random.Range(1, 4);
        }
	}

    public void ThunderSound() {
        Debug.Log("playing sound");
        thunderSource.PlayOneShot(thunder);
    }
}
