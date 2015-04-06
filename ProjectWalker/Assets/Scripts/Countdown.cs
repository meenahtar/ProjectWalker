using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	//set active on last door explosion

	float countdownStart;
	//set countdownStart to Time.time at set active moment
	float timer;

	void Start () {
		countdownStart = 0.0f;
		timer = 300.0f; //five minutes
	}

	void Update () {
		if (countdownStart != 0.0f) {

		}
	}


}
