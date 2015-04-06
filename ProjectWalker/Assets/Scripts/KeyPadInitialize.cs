using UnityEngine;
using System.Collections;

public class KeyPadInitialize : MonoBehaviour {

	bool enterRange;
	bool accessing;
	GameObject keyPadBacks;

	//first person controller
	GameObject FPC;
	//main camera
	GameObject MC;

	// Use this for initialization
	void Start () {
		keyPadBacks = GameObject.Find ("KeyPadBacks");
		keyPadBacks.SetActive (false);

		FPC = GameObject.Find ("First Person Controller");
		MC = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (enterRange && Input.GetKeyDown ("f") && !accessing) {
			//disable FPC
			FPC.GetComponent<MouseLook>().enabled = false;
			FPC.GetComponent<CharacterMotor>().enabled = false;
			MC.GetComponent<MouseLook>().enabled = false;

			accessing = true;
			keyPadControl.SetActive(true);
		}
	}

	void OnGUI()
	{
		if(enterRange && !accessing) {
				GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to use keypad");
			}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			enterRange = true;
		}
	}
	
	//If player exits note zone
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") 
		{
			enterRange = false;
		}
	}
}
