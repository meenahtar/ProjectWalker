using UnityEngine;
using System.Collections;

public class KeypadScript : MonoBehaviour {

	public bool enterRange;
	public bool exitRange;


	// Use this for initialization
	void Start () {
		enterRange = false;
		exitRange = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (enterRange == true && Input.GetKeyDown("f")) 
		{

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
