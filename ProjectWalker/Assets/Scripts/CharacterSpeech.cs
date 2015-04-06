using UnityEngine;
using System.Collections;

public class CharacterSpeech : MonoBehaviour 
{
	public float speechTimer;
	bool startGame;
	bool isDoor1;
	public bool firstTimeThrough;
	public bool keyObtained;
	bool displayText;
	GUIStyle fontDetails;
	GameObject doorEnter;
	GameObject note1Read;
	
	
	bool firstStart;
	bool firstNote;
	bool firstKey;
	bool firstBudge;
	bool firstDoor;
	
	// Use this for initialization
	void Start () 
	{
		startGame = true;
		keyObtained = false;
		firstTimeThrough = true;
		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;
		doorEnter = GameObject.Find ("Door1");
		note1Read = GameObject.Find ("Note1");
		isDoor1 = false;

		firstStart = true;
		firstNote = true;
		firstKey = true;
		firstBudge = true;
		firstDoor = true;
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Door1") 
		{
			isDoor1 = true;
		} 
	}
	
	void OnGUI()
	{
		// On game start
		if (startGame)
		{
			if(firstStart)
			{
				speechTimer = Time.time;
				firstStart = false;
			}

			if(Time.time <= speechTimer + 4)
			{
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Ugh, my head. Wh- what is this place? Better have a look around....", fontDetails);
			}
			else{
				startGame = false;
			}
		}	
		// On first note read
		else if (note1Read.GetComponent<ReadNote>().displayText == true)
		{
			if(firstNote)
			{
				speechTimer = Time.time;
				firstNote = false;
			}
			if(Time.time <= speechTimer + 6)
			{
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Well then. I suppose there ought to be a key somewhere around here...", fontDetails);
			}			
		}
		
		// On key pickup
		else if (keyObtained == true)
		{
			if(firstKey)
			{
				speechTimer = Time.time;
				firstKey = false;
			}
			if(Time.time <= speechTimer + 5)
			{
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Alright, time to get out of this room", fontDetails);
			}
		}
		
		// On door collision
		if(keyObtained == false && doorEnter.GetComponent<LockedDoor>().enter == true && doorEnter.GetComponent<LockedDoor>().open == false && Input.GetKeyDown("f")){
			if(firstBudge)
			{
				speechTimer = Time.time;
				firstBudge = false;
			}
			if(Time.time <= speechTimer + 5)
			{
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "It won’t budge. I must be missing something.", fontDetails);
			}
		}
		else if (keyObtained == false && doorEnter.GetComponent<LockedDoor>().enter == true && doorEnter.GetComponent<LockedDoor>().open == false)
		{
			GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "The door is locked", fontDetails);			
		}
		else if(doorEnter.GetComponent<LockedDoor>().open == true && doorEnter.GetComponent<LockedDoor>().enter == true){
			GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Whoa, Deja Vu", fontDetails);
		}
		
	}
	
	void showText(bool cond, string text, int displayTime){
		if(cond){
			speechTimer = Time.time;
			cond = !cond;
		}
		
		if(Time.time <= speechTimer + displayTime){
			//display text
			GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), text, fontDetails);		
		}
		else{
		}
	}
}


