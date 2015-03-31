using UnityEngine;
using System.Collections;

public class CharacterSpeech : MonoBehaviour 
{
	float speechTimer;
	bool startGame;
	bool firstTimeThrough;
	GUIStyle fontDetails;

	// Use this for initialization
	void Start () 
	{
		startGame = true;
		firstTimeThrough = true;
		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;
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
		
	}
}
