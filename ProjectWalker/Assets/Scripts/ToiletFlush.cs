using UnityEngine;
using System.Collections;

public class ToiletFlush : MonoBehaviour {

	bool enterRange;
	public AudioClip flushSound;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		enterRange = false;
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enterRange && Input.GetKeyDown ("g")){
			source.PlayOneShot(flushSound, 4f);
		} 
	}

	void OnGUI()
	{
		if(enterRange)
		{
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 160, 150, 30), "Press 'G' to flush toilet");
		}
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			enterRange = true;
		}
	}
	
	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			enterRange = false;
		}
	}
}
