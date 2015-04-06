using UnityEngine;
using System.Collections;

public class KeyPadControl : MonoBehaviour {
	
	GameObject[] keyPadBacks;
	GameObject keyPadBack1;
	GameObject keyPadBack2;
	GameObject keyPadBack3;
	GameObject keyPadBack4;
	GameObject keyPadBack5;
	GameObject keyPadBack6;
	GameObject keyPadBack7;
	GameObject keyPadBack8;
	GameObject keyPadBack9;

	bool keyDown;
	int keyCounter;
	bool keyCodeCompleted;
	bool codeVerification;
	string codeAnswer;
	string codeEntered;

	float errorTimeStart;
	float errorTimer;
	bool errorStatus;
	
	// Use this for initialization
	void Start () {
		keyPadBacks = new GameObject[9];
		for (int i = 0; i < 10; i++) {
			keyPadBacks[i] = GameObject.Find("KeyPadBack" + (i + 1));
		}

		keyDown = false;
		keyCounter = 0;
		keyCodeCompleted = false;
		codeVerification = false;
		codeAnswer = "1943";
		codeEntered = "";
		errorTimer = 3;
		errorStatus = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (keyCounter == 4) {
			keyCodeCompleted = true;
		}
		if (Time.time - errorTimeStart > errorTimer) {
			errorStatus = false;
			//change all keybacks to white
			// ---
		}

		if (!errorStatus) {

			if (keyCodeCompleted) {

				if (codeEntered.Equals(codeAnswer))
				{
					codeVerification = true;
					//change all keybacks to correct state (green?)
					// ---
					//other victory reactions (final cutscene?)
					// ---
				}
				else
				{
					//start error sequence
					errorStatus = true;
					errorTimeStart = Time.time;
					//reset keycode variables
					codeEntered = "";
					keyCounter = 0;
					keyCodeCompleted = false;
					//change all keybacks to red
					// ---

				}

			} else {

				if (keyDown) {
					if (Input.GetKeyUp ("1")) {
						if (codeEntered[codeEntered.Length - 1].Equals("1"))
						{
							keyDown = false;
							keyCounter = keyCounter + 1;
							//change keyBack color to white
							// ---
						}
					} else if (Input.GetKeyUp ("2")) {
						//
					}
				}
				else {
					if (Input.GetKeyDown ("1")) {
						keyDown = true;
						codeEntered = codeEntered + "1";
						//change keyBack color to pressed (grey?)
						// ---
						//send command to character speech
						// ---
					} else if (Input.GetKeyDown ("2")) {
						//
					} 
				}
				
			}
		}
	}
}
