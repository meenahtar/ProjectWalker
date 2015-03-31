﻿// Smothly open a door
var smooth = 2.0;
var DoorOpenAngle = 90.0;
public var open : boolean;
public var enter : boolean;

private var defaultRot : Vector3;
private var openRot : Vector3;

public var lockedSound : AudioClip;
public var openSound : AudioClip;

private var source : AudioSource;

function Start(){
	defaultRot = transform.eulerAngles;
	openRot = new Vector3 (defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
	source = GetComponent.<AudioSource>();
}

//Main function
function Update (){
	if(open){
		//Open door
		
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
	}else{
		//Close door
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
	}

	if(Input.GetKeyDown("f") && enter && GameObject.Find("First Person Controller").GetComponent("CharacterSpeech").keyObtained == true){
		source.PlayOneShot(openSound, 4f);
		open = !open;
		GameObject.Find("First Person Controller").GetComponent("CharacterSpeech").keyObtained = false;
	} else if(Input.GetKeyDown("f") && enter && GameObject.Find("First Person Controller").GetComponent("CharacterSpeech").keyObtained == false){
		source.PlayOneShot(lockedSound, 4f);
	}
}

function OnGUI(){
	if(enter && GameObject.Find("First Person Controller").GetComponent("CharacterSpeech").keyObtained == true){
		GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
	}
}

//Activate the Main function when player is near the door
function OnTriggerEnter (other : Collider){
	if (other.gameObject.tag == "Player") {
		enter = true;
	}
}

//Deactivate the Main function when player is go away from door
function OnTriggerExit (other : Collider){
	if (other.gameObject.tag == "Player") {
		enter = false;
	}
}