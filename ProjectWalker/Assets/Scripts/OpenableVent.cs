using UnityEngine;
using System.Collections;

public class OpenableVent : MonoBehaviour {

	bool enterRange;
	bool pressedOpen;
	bool opened;
	public bool keyObtained;

	GameObject vent;
	GameObject screwDriver;

	public AudioClip lockedSound;
	public AudioClip openSound;
	public AudioClip pickUpSound;
	
	private AudioSource source;

	// Use this for initialization
	void Start () {
		vent = GameObject.Find ("Vent");
		screwDriver = GameObject.Find ("Screw Driver");

		pressedOpen = false;
		opened = false;
		enterRange = false;
		keyObtained = false;
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && screwDriver.GetComponent<Screwdriver>().screwDriverObtained == true) {
			pressedOpen = true;
		} 

		if(Input.GetKeyDown ("f") && enterRange && GameObject.Find("Note2").GetComponent<ReadNote2>().getKey == false){
			source.PlayOneShot(lockedSound, 4f);
		}
		
		
		if (Input.GetKeyDown ("g") && enterRange) {
			keyObtained = true;
			GameObject key = GameObject.Find("Vent Key");
			source.PlayOneShot(pickUpSound, 4f);
			key.SetActive(false);
		}
		
		if (pressedOpen && opened == false && enterRange && Input.GetKeyDown ("f")) {
			opened = true;
			vent.SetActive(false);
			source.PlayOneShot(openSound, 4f);
		} 
	}

	void OnGUI()
	{
		if(enterRange && opened == false && screwDriver.GetComponent<Screwdriver>().screwDriverObtained == true){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 350, 30), "Press 'F' to use screwdriver on vent");
		}
		//Get key
		if(enterRange && opened && keyObtained == false && screwDriver.GetComponent<Screwdriver>().screwDriverObtained == true){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 350, 30), "Press 'G' to take key");
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
