using UnityEngine;
using System.Collections;

public class CharacterSpeech : MonoBehaviour 
{
	public float speechTimer;
	bool startGame;
	
	public bool keyObtained;
	public bool screwDriverObtained;
	
	GUIStyle fontDetails;
	GameObject doorEnter1;
	GameObject doorEnter2;
	GameObject chair3;
	GameObject note1Read;
	GameObject fuseBox;
	GameObject darknessWall;
	
	bool enteredDoor2;
	bool enteredChair3;
	bool enteredWall;
	
	bool firstStart;
	bool firstNote;
	bool firstKey;
	bool firstDoor2;
	bool firstScrew;
	bool firstChair;
	bool firstWall;
	
	// Use this for initialization
	void Start () 
	{
		startGame = true;
		
		keyObtained = false;
		screwDriverObtained = false;

		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;
		doorEnter1 = GameObject.Find ("Door1");
		doorEnter2 = GameObject.Find ("Door2");
		chair3 = GameObject.Find ("Chair 3");
		note1Read = GameObject.Find ("Note1");
		fuseBox = GameObject.Find ("FuseBox");
		darknessWall = GameObject.Find("Invisible Darkness Wall");
		
		enteredDoor2 = false;
		enteredChair3 = false;
		enteredWall = false;
		
		firstStart = true;
		firstNote = true;
		firstKey = true;
		firstDoor2 = true;
		firstScrew = true;
		firstChair = true;
		firstWall = true;
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter (Collider other){

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
		else if (keyObtained)
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
		// On second door enter
		else if(enteredDoor2){
			if(firstDoor2){
				speechTimer = Time.time;
				firstDoor2 = false;
			}
			
			if(Time.time <= speechTimer + 5){
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Another locked door, huh? This day just keeps getting better and better", fontDetails);		
			} 
			else{
				enteredDoor2 = false;
			}
		}
		else if(screwDriverObtained && !enteredChair3){
			if(firstScrew){
				speechTimer = Time.time;
				firstScrew = false;
			}
			
			if(Time.time <= speechTimer + 4){
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "I've definitely seen this screwdriver before...", fontDetails);
			}
		}
		else if(enteredChair3){
			if(firstChair){
				speechTimer = Time.time;
				firstChair = false;
			}
			
			if(Time.time <= speechTimer + 4){
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Perhaps this chair will be of use to me.", fontDetails);
			}
			else{
				enteredChair3 = false;
			}
		}
		else if(enteredWall){
			if(firstWall){
				speechTimer = Time.time;
				firstWall = false;
			}
			
			if(Time.time <= speechTimer + 4){
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "It's way too dark in there. Maybe if I fix this fusebox first…", fontDetails);
			}
			else{
				enteredWall = false;
			}
		}
		
		// On first locked door collision
		if (keyObtained == false && doorEnter1.GetComponent<LockedDoor>().enter == true && doorEnter1.GetComponent<LockedDoor>().open == false)
		{
			GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "This seems to be locked", fontDetails);			
		}
		else if(doorEnter1.GetComponent<LockedDoor>().open == true && doorEnter1.GetComponent<LockedDoor>().enter == true){
			GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Whoa, Deja Vu", fontDetails);
		}
		
		// On second locked door collision
		if (keyObtained == false && doorEnter2.GetComponent<LockedDoor>().enter == true && doorEnter2.GetComponent<LockedDoor>().open == false)
		{
			enteredDoor2 = true;
		}
		
		// On chair collision
		if(screwDriverObtained && chair3.GetComponent<Moveable>().enterRange){
			print("Entered chair");
			enteredChair3 = true;
		}
		
		// On Darkness Wall Collision
		if(!fuseBox.GetComponent<FuseBox>().lightsOn && darknessWall.GetComponent<DarknessWall>().enterRange){
			enteredWall = true;
		}
		
	}
}


