using UnityEngine;
using System.Collections;

public class FuseBox : MonoBehaviour {

	public bool accessable;
	bool lightsOn;
	bool enterRange;

	public AudioClip lightSwitchNoise; //temporary sound name
	private AudioSource source;

	GameObject darknessWall;

	// Use this for initialization
	void Start () {
		accessable = false;
		lightsOn = false;

		source = GetComponent<AudioSource> ();

		darknessWall = GameObject.Find ("Invisible Darkness Wall");
	}
	
	// Update is called once per frame
	void Update () {
		if (accessable == true && lightsOn == false && enterRange && Input.GetKeyDown ("f"))
		{
			//source.PlayOneShot(lightSwitchNoise, 4f);
			// turn on lights in room 3
			darknessWall.SetActive(false);
		}
	}

	void OnGUI(){
		if(enterRange && accessable && lightsOn == false){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to turn on lights");
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
