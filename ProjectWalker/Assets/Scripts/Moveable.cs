using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	GameObject playerReference;
	public bool enterRange;
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
	

		if (Input.GetKey ("f") && enterRange) {
			newPosition = new Vector3 (playerReference.transform.position.x - difference.x, chairStartPos.y, playerReference.transform.position.z - difference.z);
			GetComponent<Rigidbody> ().MovePosition (newPosition);
		} 
	}

	void OnGUI(){
		if(enterRange){
			GUI.Label(new Rect(Screen.width/2 - 150, Screen.height - 100, 300, 30), "Hold 'F' and move character to move object");
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
