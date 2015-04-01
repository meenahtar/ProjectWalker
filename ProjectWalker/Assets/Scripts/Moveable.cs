using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	GameObject playerReference;
	bool enterRange;
	Vector3 difference;
	Vector3 newPosition;
	Vector3 chairStartPos;

	public int GroundSpeed = 5;
	public int Gravity = 1;
	public bool IsGrounded = false;

	// Use this for initialization
	void Start () {
		playerReference = GameObject.FindWithTag ("Player");
		chairStartPos = transform.position;

		GetComponent<Rigidbody>().WakeUp ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && enterRange) {
			difference = playerReference.transform.position - transform.position;
		}

		CheckForGround();

		if (Input.GetKey ("f") && enterRange) {
				newPosition = new Vector3 (playerReference.transform.position.x - difference.x, playerReference.transform.position.y - difference.y, playerReference.transform.position.z - difference.z);
				GetComponent<Rigidbody> ().MovePosition (newPosition);
		}  else if (!IsGrounded) {
			transform.Translate(-Vector2.up * Gravity * Time.deltaTime);
		}
	}

	void OnGUI(){
		if(enterRange){
			GUI.Label(new Rect(Screen.width/2 - 150, Screen.height - 100, 300, 30), "Hold 'F' and move character to move object");
		}
	}

	void CheckForGround(){
		if(transform.position.y < chairStartPos.y)
		{
			// Cache the position
			Vector3 position = transform.position;
			// Set Y component to floor level
			position.y = chairStartPos.y;
			// Assign new position
			transform.position = position;
		}
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
				enterRange = true;
		} else {
			enterRange = false;
		}
	}

	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			enterRange = false;
		}
	}
}
