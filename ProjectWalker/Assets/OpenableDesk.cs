using UnityEngine;
using System.Collections;

public class OpenableDesk : MonoBehaviour {

	bool pressedOpen;
	bool opened;
	bool enterRange;
	public bool keyObtained;

	float finalX;
	float smooth;

	float startTime;

	
	public AudioClip lockedSound;
	public AudioClip openSound;
	
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Start () {
		finalX = 4f;
		pressedOpen = false;
		opened = false;
		enterRange = false;
		keyObtained = false;
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && GameObject.Find("Note2").GetComponent<ReadNote2>().getKey == true) {

			pressedOpen = true;
			startTime = Time.time;

		} 
		if(Input.GetKeyDown ("f") && enterRange && GameObject.Find("Note2").GetComponent<ReadNote2>().getKey == false){
			source.PlayOneShot(lockedSound, 4f);
		}


		if (Input.GetKeyDown ("g")) {
			keyObtained = true;
			GameObject key = GameObject.Find("Key");
			key.SetActive(false);
		}

		if (pressedOpen && opened == false && enterRange && Input.GetKeyDown ("f")) {
			transform.Translate(new Vector3(1.5f, 0.0f, 0.0f), Space.Self);
			opened = true;
			source.PlayOneShot(openSound, 4f);
			/*while (transform.position.x < finalX) {
				transform.Translate(new Vector3(1.0f, 0.0f, 0.0f), Space.Self);
				opened = true;
				// - transform.position.x
			}*/
		} 


	}
	
	void OnGUI(){
		if(enterRange && opened == false && GameObject.Find("Note2").GetComponent<ReadNote2>().getKey == true){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open drawer");
		}
		//Get key
		if(enterRange && opened && keyObtained == false && GameObject.Find("Note2").GetComponent<ReadNote2>().getKey == true){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'G' to take key");
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
