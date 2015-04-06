using UnityEngine;
using System.Collections;

public class OpenableVent : MonoBehaviour {

	bool enterRange;
	bool pressedOpen;
	bool opened;

	GameObject vent;
	GameObject FPC;
	GameObject ventKey;

	public AudioClip lockedSound;
	public AudioClip openSound;
	public AudioClip pickUpSound;
	
	private AudioSource source;

	// Use this for initialization
	void Start () {
		vent = GameObject.Find ("Vent");
		FPC = GameObject.Find ("First Person Controller");
		ventKey = GameObject.Find ("Vent Key");
		ventKey.SetActive (false);

		pressedOpen = false;
		opened = false;
		enterRange = false;
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && FPC.GetComponent<CharacterSpeech>().screwDriverObtained == true) {
			pressedOpen = true;
		} 
		
		if (pressedOpen && opened == false && enterRange && Input.GetKeyDown ("f")) {
			opened = true;
			ventKey.SetActive(true);
			vent.SetActive(false);
  			source.PlayOneShot(openSound, 4f);
		} 
	}

	void OnGUI()
	{
		if(enterRange && opened == false && FPC.GetComponent<CharacterSpeech>().screwDriverObtained == true){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 350, 30), "Press 'F' to use screwdriver on vent");
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
