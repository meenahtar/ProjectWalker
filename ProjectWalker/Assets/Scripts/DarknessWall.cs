using UnityEngine;
using System.Collections;

public class DarknessWall : MonoBehaviour {

	GameObject FuseBox;
	public bool enterRange;
	GameObject Room3EnterDoor;

	// Use this for initialization
	void Start () {
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
