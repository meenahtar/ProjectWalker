using UnityEngine;
using System.Collections;

public class CharacterSpeech : MonoBehaviour 
{
	float speechTimer;
	bool startGame;
	bool firstTimeThrough;
	public bool keyObtained;
	GUIStyle fontDetails;
	GameObject doorEnter;

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

		else if (!keyObtained && doorEnter.GetComponent<LockedDoor>().enter == true && doorEnter.GetComponent<LockedDoor>().open == false)
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
				startGame = false;
				firstTimeThrough = true;
			}
			
		}
		
	}

}
