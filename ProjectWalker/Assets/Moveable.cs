using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	GameObject playerReference;

	// Use this for initialization
	void Start () {
		GplayerReference = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			
		}
	}

	function OnGUI(){
		if(enter){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Hold 'F' to move object");
		}
	}

	//Activate the Main function when player is near the door
	function OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			enter = true;
		}
	}
	
	//Deactivate the Main function when player is go away from door
	function OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			enter = false;
		}
}
