using UnityEngine;
using System.Collections;

public class OpenableDesk : MonoBehaviour {

	bool pressedOpen;
	bool opened;
	bool enterRange;

	float finalX;

	float startTime;

	// Use this for initialization
	void Start () {
		finalX = 4f;
		pressedOpen = false;
		opened = false;
		enterRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			pressedOpen = true;
			startTime = Time.time;
		}
		if (pressedOpen && opened == false) {
			while (transform.position.x < finalX) {
				transform.Translate(new Vector3(finalX - transform.position.x, 0.0f, 0.0f), Space.Self);
				opened = true;
			}
		}
	}
	
	void OnGUI(){
		if(enterRange && opened == false){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open drawer");
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
