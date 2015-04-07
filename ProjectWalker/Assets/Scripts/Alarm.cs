using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {

	public AudioSource alarm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startAlarm() {
		alarm.Play ();
	}
}
