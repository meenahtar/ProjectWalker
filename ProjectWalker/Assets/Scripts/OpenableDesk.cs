using UnityEngine;
using System.Collections;

public class OpenableDesk : MonoBehaviour {
	
	bool opened;
	bool enterRange;

	
	public AudioClip lockedSound;
	public AudioClip openSound;
	
	private AudioSource source;

	// Use this for initialization
	void Start () {
		opened = false;
		enterRange = false;
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (opened == false && enterRange && Input.GetKeyDown ("f")) {
			transform.Translate(new Vector3(1.5f, 0.0f, 0.0f), Space.Self);
			opened = true;
			source.PlayOneShot(openSound, 4f);
		} 
		else if (Input.GetKeyDown ("f") && opened && enterRange) {
			transform.Translate(new Vector3(-1.5f, 0.0f, 0.0f), Space.Self);
			opened = false;
			source.PlayOneShot(openSound, 4f);
		}
	}
	
	void OnGUI(){
		if(enterRange && opened == false){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open drawer");
		}
		if(enterRange && opened){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to close drawer");
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
