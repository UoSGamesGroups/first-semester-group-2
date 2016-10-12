using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	float rotationY = 0F;
	float rotationX = 0F;

	public float sensitivityX = 5F;
	public float sensitivityY = 5F;

	public float minimumX = -180F;
	public float maximumX = 180F;

	public float minimumY = 0F;
	public float maximumY = 0F;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseXAndY) {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		} else if (axes == RotationAxes.MouseX) {
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		} else {
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3 (-rotationY, -rotationX, 0);
		}
	}
}
