using UnityEngine;
using System.Collections;

public class CharacterSpeech : MonoBehaviour 
{
	public float speechTimer;
	bool startGame;
	public bool firstTimeThrough;
	public bool keyObtained;
	GUIStyle fontDetails;
	GameObject doorEnter;
	GameObject note1Read;

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



	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		if (startGame)
		{
			if(firstTimeThrough)
			{
				speechTimer = Time.time;
				firstTimeThrough = false;
			}

			if(Time.time <= speechTimer + 10)
			{

				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Ugh, my head. Wh- what is this place? Better have a look around.", fontDetails);
			}
			else
			{
				startGame = false;
				firstTimeThrough = true;
			}

		}

		else if (!keyObtained && doorEnter.GetComponent<LockedDoor>().enter == true && doorEnter.GetComponent<LockedDoor>().open == false && doorEnter.GetComponent<LockedDoor>().usedKey == false)
		{
			if(firstTimeThrough)
			{
				speechTimer = Time.time;
				firstTimeThrough = false;
			}
			
			if(Time.time <= speechTimer + 10)
			{
				
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "The door is locked", fontDetails);
			}
			else
			{
				firstTimeThrough = true;
			}
			
		}
		
		else if (note1Read.GetComponent<ReadNote>().displayText == true)
		{
			if(firstTimeThrough)
			{
				speechTimer = Time.time;
				firstTimeThrough = false;
			}
			if(Time.time <= speechTimer + 6)
			{
				
				GUI.Label (new Rect (Screen.width / 2 - 250 , Screen.height - 200, 500, 40), "Well then. I suppose there ought to be a key somewhere around here...", fontDetails);
			}
			else
			{
				firstTimeThrough = true;
			}

		}
		
	}

}
