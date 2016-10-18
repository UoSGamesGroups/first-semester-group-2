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
	[SerializeField]
	LayerMask mask;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		this.transform.position = new Vector3 (0, 1, 0);
		energySlider.value = 0.2f;
		noEntryText.enabled = false;
		readyToInteract = true;
		PlayerPrefs.SetInt("LevelNumber", 1);
		holdingBucket = false;
		openDoorTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Interact ();
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
		RaycastHit hit;
		float distance = 3;
		Debug.Log("ReadyToOpen is " + readyToInteract);
		if (readyToInteract == true) {
			if (Physics.Raycast (playerCamera.transform.position, playerCamera.transform.forward, out hit, distance, mask)) {
				GameObject HitObject = hit.collider.gameObject;
				Debug.Log ("We hit " + hit.collider.gameObject.name);

				if (hit.collider.tag == "Door") {
					if (InteractText.enabled == false) {
						InteractText.enabled = true;
						InteractText.text = "Click to open door";
					} else {
						
					}
					if (openingDoor == true && openDoorTimer <= 0){
						
						OpenDoor (HitObject.GetComponent<DoorScript> ().levelToLoad, HitObject.GetComponent<DoorScript> ().spawnPosition, HitObject.GetComponent<DoorScript> ().spawnRotation);
					}
					if (Input.GetButtonDown ("Fire1"))
					if (PlayerPrefs.GetInt ("LevelNumber") >= HitObject.GetComponent<DoorScript> ().levelToLoad) {
						
						this.GetComponent<MouseLook> ().enabled = false;
						this.GetComponent<Movement> ().enabled = false;
						playerCamera.GetComponent<MouseLook> ().enabled = false;
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
				} else if (hit.collider.tag == "Key") {
					if (InteractText.enabled == false) {
						InteractText.enabled = true;
						InteractText.text = "Click to take key";
					}
					if (Input.GetButtonDown ("Fire1")) {
						TakeKey (HitObject.GetComponent<KeyScript> ().thisLevelNumber+1, HitObject.gameObject);
					}
				} else if (hit.collider.tag == "Bucket" && holdingBucket == false) {
					if (InteractText.enabled == false) {
						InteractText.enabled = true;
						InteractText.text = "Click to pickup bucket";
					}
					if (Input.GetButtonDown ("Fire1")) {
						bucketToHold = HitObject;
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
	}


	void OpenDoor(int LevelNumber, Vector3 SpawnPos, Vector3 SpawnRot){
		Debug.Log ("Opening level " + LevelNumber);
		if (PlayerPrefs.GetInt ("LevelNumber") >= LevelNumber) {
			this.GetComponent<MouseLook> ().rotationX = SpawnRot.y;
			this.transform.position = SpawnPos;
			this.transform.eulerAngles = SpawnRot - new Vector3 (this.GetComponent<MouseLook> ().rotationX, this.GetComponent<MouseLook> ().rotationY);
			Destroy (GameObject.FindWithTag ("Level"));
			Instantiate (gameManager.Levels [LevelNumber]);
			this.GetComponent<MouseLook>().enabled = true;
			this.GetComponent<Movement>().enabled = true;
			playerCamera.GetComponent<MouseLook>().enabled = true;
			openingDoor = false;
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
		Destroy (key);
	}

	void HoldBucket(GameObject bucket){
		
		bucket.transform.position = bucketPositionObject.transform.position;
		bucket.transform.rotation = bucketPositionObject.transform.rotation;
		if (Input.GetButtonDown("Fire1") && ReadyToDrop >= 0.5){
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

}
