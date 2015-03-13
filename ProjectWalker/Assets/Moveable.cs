using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	GameObject playerReference;
	bool enterRange;
	Vector3 difference;
	Vector3 newPosition;

	// Use this for initialization
	void Start () {
		playerReference = GameObject.FindWithTag ("Player");
		rigidbody.WakeUp ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			difference = playerReference.transform.position - transform.position;
		}
		if (Input.GetKey ("f")) {
			newPosition = new Vector3(playerReference.transform.position.x - difference.x, playerReference.transform.position.y - difference.y, playerReference.transform.position.z - difference.z);
			rigidbody.MovePosition(newPosition);
		}
	}

	void OnGUI(){
		if(enterRange){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Hold 'F' to move object");
		}
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			enterRange = true;
		}
	}
	
	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			enterRange = false;
		}
	}
}
