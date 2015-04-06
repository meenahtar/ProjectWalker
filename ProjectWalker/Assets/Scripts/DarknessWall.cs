using UnityEngine;
using System.Collections;

public class DarknessWall : MonoBehaviour {

	GameObject FuseBox;
	bool enterRange;

	// Use this for initialization
	void Start () {
		FuseBox = GameObject.Find ("FuseBox");
	}
	
	// Update is called once per frame
	void Update () {
		if (enterRange && FuseBox.GetComponent<FuseBox>().accessable == false) 
		{
			FuseBox.GetComponent<FuseBox>().accessable = true;
		}
	}

	void OnGUI(){
		if(enterRange){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "find fusebox");
			//set variable for characterspeech?
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
