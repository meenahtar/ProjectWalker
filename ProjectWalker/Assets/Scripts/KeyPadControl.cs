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
		for (int i = 0; i < 9; i++) {
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

		if (errorStatus) {
			if (Time.time - errorTimeStart > errorTimer) {
				errorStatus = false;
				
				//change all keybacks to white
				for (int i = 0; i < 9; i++) {
					keyPadBacks[i].renderer.material.color = Color.white;
				}
			}
		}
		else {

			if (keyCodeCompleted) {

				if (codeEntered.Equals(codeAnswer))
				{
					codeVerification = true;

					//change all keybacks to correct state (green?)
					for (int i = 0; i < 9; i++) {
						keyPadBacks[i].renderer.material.color = Color.green;
					}
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
					for (int i = 0; i < 9; i++) {
						keyPadBacks[i].renderer.material.color = Color.red;
					}

				}

			} else {

				if (!keyDown) {

					print ("Enter Key Down Check");

					for (int i = 1; i < 10; i++){
						if (Input.GetKeyDown (i.ToString()) && !keyDown) {
							keyDown = true;
							codeEntered = codeEntered + i.ToString();
							
							//change keyBack color to pressed (grey?)
							keyPadBacks[i - 1].renderer.material.color = Color.yellow;
							//send command to character speech
							// ---

							print("GetKeyDown: " + i.ToString());
							print("CodeEntered: " + codeEntered);
						}
					}
				}

				if (keyDown) {

					print ("Enter Key Up Check");

					for (int i = 1; i < 10; i++){
						if (Input.GetKeyUp (i.ToString())) {

							print("GetKeyUp: " + i.ToString());

							if (codeEntered[codeEntered.Length - 1].Equals((char)i)) {

								print("Code Last Index Comparison Success");

								keyDown = false;
								keyCounter = keyCounter + 1;

								//change keyBack color to white
								keyPadBacks[i -  1].renderer.material.color = Color.white;
							}
						}
					}
				}
				
			}
		}
	}
}
