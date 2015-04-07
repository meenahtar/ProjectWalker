using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {

	bool enterRange;
	bool on;

	public AudioSource music;
	public AudioSource speech;

	// Use this for initialization
	void Start () {
		on = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && enterRange && on) {
			on = false;
			music.Pause();
			speech.Pause();
		} else if (Input.GetKeyDown ("f") && enterRange && !on) {
			on = true;
			music.Play();
			speech.Play();
		}
	}

	void OnGUI()
	{
		if (enterRange && on) {
			GUI.Label (new Rect (Screen.width / 2 - 175, Screen.height - 100, 350, 30), "Press 'F' to turn off radio");
		} else if (enterRange && !on) {
			GUI.Label (new Rect (Screen.width / 2 - 175, Screen.height - 100, 350, 30), "Press 'F' to turn on radio");
		}
	}

	//If player enters note zone
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			enterRange = true;
		}
	}
	
	//If player exits note zone
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") 
		{
			enterRange = false;
		}
	}
}
