﻿using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	//set active on last door explosion
	GameObject doorGone;
	bool countdownStart;
	//set countdownStart to Time.time at set active moment
	float startTime;
	float minutes;
	float tenSeconds;
	float seconds;
	GUIStyle fontDetails;
	public Texture clock;

	public GameObject minutesObj;
	public GameObject tenSecObj;
	public GameObject SecObj;

	public Texture2D[] numTextures;
	public Texture2D num0;
	public Texture2D num1;
	public Texture2D num2;
	public Texture2D num3;
	public Texture2D num4;
	public Texture2D num5;
	public Texture2D num6;
	public Texture2D num7;
	public Texture2D num8;
	public Texture2D num9;

	public bool won;

	void Start ()
	{
		doorGone = GameObject.Find ("First Person Controller");
		startTime = Time.time;
		minutes = 1.0f;
		tenSeconds = 3.0f;
		seconds = 0.0f;
		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.black;
		fontDetails.fontSize = 20;

		numTextures = new Texture2D[10];
		numTextures [0] = num0;
		numTextures [1] = num1;
		numTextures [2] = num2;
		numTextures [3] = num3;
		numTextures [4] = num4;
		numTextures [5] = num5;
		numTextures [6] = num6;
		numTextures [7] = num7;
		numTextures [8] = num8;
		numTextures [9] = num9;

		won = false;
	}

	void Update () 
	{
		countdownStart = doorGone.GetComponent<CheckDoor> ().doorGone;
		//print (countdownStart);
		if (countdownStart && !won) 
		{
			if(Time.time >= startTime + 1)
			{
				seconds = seconds - 1;
				if(seconds < 0)
				{
					seconds = 9;
					tenSeconds = tenSeconds - 1;
				}
				if(tenSeconds < 0)
				{
					minutes = 0;
					tenSeconds = 5;
					seconds = 9;
				}
				//time = timer.ToString();
				startTime = Time.time;

			}

			if (minutes == 0 && tenSeconds == 0 && seconds == 0)
			{
				Application.LoadLevel("prototype");
			}

			for (float i = 0; i < 10; i++) {
				if (i == minutes) {
					minutesObj.renderer.material.mainTexture = numTextures[(int)i];
				}
				if (i == tenSeconds) {
					tenSecObj.renderer.material.mainTexture = numTextures[(int)i];
				}
				if (i == seconds) {
					SecObj.renderer.material.mainTexture = numTextures[(int)i];
				}
			}
		}
	}
		
	void OnGUI()
	{
		if(countdownStart)
		{
			GUI.DrawTexture(new Rect(Screen.width - 405, 5, 150, 100), clock, ScaleMode.ScaleToFit, true, 0.0f);
			GUI.Label(new Rect(Screen.width - 350, 50, 350, 60), " " + minutes + "  " + tenSeconds + seconds, fontDetails);
		}

	}


}
