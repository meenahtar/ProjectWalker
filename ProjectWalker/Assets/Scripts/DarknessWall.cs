using UnityEngine;
using System.Collections;

public class DarknessWall : MonoBehaviour {

	GameObject FuseBox;
	public bool enterRange;
	GameObject Room3EnterDoor;

	GUIStyle fontDetails;

	// Use this for initialization
	void Start () {
		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;

		FuseBox = GameObject.Find ("FuseBox");
		Room3EnterDoor = GameObject.Find ("Room3EnterDoor");
	}
	
	// Update is called once per frame
	void Update () {
		if (enterRange && FuseBox.GetComponent<FuseBox>().accessable == false && Room3EnterDoor.GetComponent<UnlockedDoor>().open == true) 
		{
			FuseBox.GetComponent<FuseBox>().accessable = true;
		}
	}
	void OnGUI()
	{
		if (enterRange){
			GUI.Label (new Rect (Screen.width / 2 - 250, Screen.height - 200, 500, 40), "It's way too dark in there. Maybe if I fix this fusebox first…", fontDetails);
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
