using UnityEngine;
using System.Collections;

public class GetKey : MonoBehaviour 
{
	bool enterRange;
	public AudioClip pickUpSound;
	private AudioSource source;
	GameObject FPC;

	// Use this for initialization
	void Start () 
	{
		enterRange = false;
		source = GetComponent<AudioSource>();
		FPC = GameObject.Find ("First Person Controller");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enterRange && Input.GetKeyDown ("g")) 
		{
			FPC.GetComponent<CharacterSpeech>().keyObtained = true;
			source.PlayOneShot(pickUpSound, 4f);
			//setActive(false);
			this.gameObject.SetActive(false);
		} 
	}

	void OnGUI(){
		if(enterRange && FPC.GetComponent<CharacterSpeech>().keyObtained == false){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'G' to pick up key");
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
