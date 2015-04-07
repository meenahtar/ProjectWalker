using UnityEngine;
using System.Collections;

public class CheckDoor : MonoBehaviour {

	GameObject bomb;
	GameObject lighter;
	GameObject door;
	bool doorCheck;
	public bool doorGone;
	public bool bombPlaced;

	GameObject alarm;

	// Use this for initialization
	void Start () 
	{
		doorCheck = false;
		bombPlaced = false;
		bomb = GameObject.Find ("Cherry Bomb");
		lighter = GameObject.Find ("Lighter");
		doorGone = false;

		alarm = GameObject.Find ("Alarm");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If you are at the 3rd room door..
		if (doorCheck == true && bomb.GetComponent<BombScript>().bombObtained) 
		{
			if (Input.GetKeyDown ("g")) 
			{
				if(bombPlaced == false) 
				{
					bomb.GetComponent<BombScript>().enabled = false;
					bomb.transform.Translate(new Vector3(17.5f, 5.0f, -15.0f), Space.Self);
					bomb.SetActive(true);
					bombPlaced = true;
				}
			} 

			if (Input.GetKeyDown ("f")) 
			{
				if(lighter.GetComponent<LighterPickup>().lighterObtained == true && bombPlaced)
				{
					bomb.SetActive(false);
					door.SetActive(false);
					doorGone = true;

					alarm.GetComponent<Alarm>().startAlarm();
					
				}
			}


		}
	}

	void OnGUI(){
		if (doorCheck && bomb.GetComponent<BombScript> ().bombObtained && bombPlaced == false) 
		{
			GUI.Label (new Rect (Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press 'G' to place bomb");
		} 
		else if (bombPlaced && doorCheck && doorGone == false) 
		{
			GUI.Label (new Rect (Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press 'F' to light bomb");
		}

		
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "bombDoor") {
			door = other.gameObject;
			doorCheck = true;
		}
	}

	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){
		if (other.gameObject.name == "bombDoor") {
			doorCheck = false;
		}
	}
}
