using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public Camera playerCamera;
	public Text InteractText;
	public Text noEntryText;
	public GameManager gameManager;
	public Slider energySlider;
	public GameObject fadePanel;
	float interactTimer;
	bool holdingBucket = false;
	GameObject bucketToHold;
	public GameObject bucketPositionObject;
	public bool readyToInteract = true;
	float ReadyToDrop = 0;
	bool openingDoor;
	float openDoorTimer;
    bool nextToDoor;
    bool nextToKey;
    bool nextToBucket;
    GameObject DoorToOpen;
    GameObject keyToPickup;
    GameObject BucketToPickup;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		this.transform.position = new Vector3 (0, 1, 0);
		//energySlider.value = 0.2f;
		noEntryText.enabled = false;
		readyToInteract = true;
		holdingBucket = false;
		openDoorTimer = 0;
		PlayerPrefs.SetInt("LevelNumber", 1);
	}
	
	// Update is called once per frame
	void Update () {
		Interact ();
		if (PlayerPrefs.GetInt ("LevelNumber") == 0) {
			PlayerPrefs.SetInt ("LevelNumber", 1);
		}
		if (interactTimer > 0) {
			interactTimer -= Time.deltaTime;
		} else if (readyToInteract == false && holdingBucket == false){
			readyToInteract = true;
			noEntryText.enabled = false;
		}

		if (holdingBucket == true) {
			HoldBucket(bucketToHold);
		}
		FadingPanel ();

	}

	public void AddEnergy(){
		if(energySlider.value < 1){
			energySlider.value += 0.2f;
		}
	}

	public void UseEnergy(){
		if(energySlider.value > 0){
			energySlider.value -= 0.2f;
		}
	}



	void Interact(){
		Debug.Log("ReadyToOpen is " + readyToInteract);
		if (readyToInteract == true) {
            if (nextToDoor == true) {

			    if (InteractText.enabled == false) {
					InteractText.enabled = true;
					InteractText.text = "Click to open door";
				}

				if (openingDoor == true && openDoorTimer <= 0){
					OpenDoor (DoorToOpen.GetComponent<DoorScript> ().levelToLoad, DoorToOpen.GetComponent<DoorScript> ().spawnPosition);
				}
				if (Input.GetButtonDown ("Interact"))
				if (PlayerPrefs.GetInt ("LevelNumber") >= DoorToOpen.GetComponent<DoorScript> ().levelToLoad) {
					this.GetComponent<Movement> ().enabled = false;
					openingDoor = true;
					openDoorTimer = 2;
					InteractText.text = "";
				} else {
					Debug.Log ("Not Ready");
					interactTimer = 3;
					readyToInteract = false;
					InteractText.enabled = false;
					noEntryText.enabled = true;
					}
			} else if (nextToKey == true) {
				if (InteractText.enabled == false) {
					InteractText.enabled = true;
					InteractText.text = "Click to take key";
				}
				if (Input.GetButtonDown ("Interact")) {
					TakeKey (keyToPickup.GetComponent<KeyScript> ().thisLevelNumber+1, keyToPickup.gameObject);
				}
			} else if (nextToBucket && holdingBucket == false) {
				if (InteractText.enabled == false) {
					InteractText.enabled = true;
					InteractText.text = "Click to pickup bucket";
				}
				if (Input.GetButtonDown ("Interact")) {
					bucketToHold = BucketToPickup;
					holdingBucket = true;
					ReadyToDrop = 0;
					readyToInteract = false;
					InteractText.enabled = false;
				}
			}
			else
			{
				if (InteractText.enabled == true) {
					InteractText.enabled = false;
				}
			}
		} 
		else 
		{
			if (InteractText.enabled == true) {
				InteractText.enabled = false;
			}
		} 
	}
	


	void OpenDoor(int LevelNumber, Vector3 SpawnPos){
		Debug.Log ("Opening level " + LevelNumber);
		if (PlayerPrefs.GetInt ("LevelNumber") >= LevelNumber) {
			this.transform.position = SpawnPos;
			Destroy (GameObject.FindWithTag ("Level"));
			Instantiate (gameManager.Levels [LevelNumber]);
			this.GetComponent<Movement>().enabled = true;
			openingDoor = false;
            nextToDoor = false;
		} else {
			Debug.Log ("Not Ready");
			interactTimer = 3;
			readyToInteract = false;
			InteractText.enabled = false;
			noEntryText.enabled = true;
		}
	}

	void TakeKey(int levelToSet, GameObject key){
		Debug.Log ("Unlocked Level " + levelToSet);
		PlayerPrefs.SetInt ("LevelNumber", levelToSet);
        nextToKey = false;
        keyToPickup = null;
           
        Destroy (key);
	}

	void HoldBucket(GameObject bucket){
		
		bucket.transform.position = bucketPositionObject.transform.position;
		bucket.transform.rotation = bucketPositionObject.transform.rotation;
		if (Input.GetButtonDown("Interact") && ReadyToDrop >= 0.5){
			holdingBucket = false;
			interactTimer = 1;
		}
		ReadyToDrop += Time.deltaTime;
	}

	void FadingPanel(){
		if (openDoorTimer > 0) {
			openDoorTimer -= Time.deltaTime;
			fadePanel.GetComponent<Image> ().enabled = true;
			fadePanel.GetComponent<Image> ().color = new Color (0, 0, 0, Mathf.MoveTowards (fadePanel.GetComponent<Image> ().color.a, 255, 0.01f));
		} else {
			if (fadePanel.GetComponent<Image> ().enabled == true) {
				fadePanel.GetComponent<Image> ().color = new Color (0, 0, 0, Mathf.MoveTowards (fadePanel.GetComponent<Image> ().color.a, 0, 0.01f));
				if (fadePanel.GetComponent<Image> ().color == new Color (0, 0, 0, 0)) {
					fadePanel.GetComponent<Image> ().enabled = false;
				}
			}
		}
	}

    void OnTriggerStay2D(Collider2D other){
        if(other.transform.tag == "Door"){
            nextToDoor = true;
            DoorToOpen = other.gameObject;
        }

        if (other.transform.tag == "Key")
        {
            nextToKey = true;
            keyToPickup = other.gameObject;
        }
        
        if (other.transform.tag == "Bucket")
        {
            nextToBucket = true;
            BucketToPickup = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.transform.tag == "Door")
        {
            nextToDoor = false;
            DoorToOpen = null;
        }
        if (other.transform.tag == "Key")
        {
            nextToKey = false;
            keyToPickup = null;
        }
        if (other.transform.tag == "Bucket")
        {
            nextToBucket = false;
            BucketToPickup = null;
        }
    }

}
