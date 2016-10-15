using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float walkSpeed = 1.5f;
	public float sensitivity = 3.0f;
	public float jumpSpeed = 5.0f;
	public float viewRange = 70.0f;

	private float verticalRot = 0;
	private float yVelocity = 0;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {

		//character rotation
		float rotateX = Input.GetAxis("Mouse X") * sensitivity;
		transform.Rotate (0, rotateX, 0);

		//camera rotation (up/down)
		verticalRot -= Input.GetAxis("Mouse Y") * sensitivity;
		verticalRot = Mathf.Clamp (verticalRot, -viewRange, viewRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRot, 0, 0);


		//character movement
		float forwardSpeed = Input.GetAxis ("Vertical") * walkSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * walkSpeed;

		yVelocity += Physics.gravity.y * Time.deltaTime;

		Vector3 speed = new Vector3 (sideSpeed, yVelocity, forwardSpeed);
		speed = transform.rotation * speed;

		CharacterController cc = GetComponent<CharacterController> ();
		cc.Move (speed * Time.deltaTime);

	}
}
