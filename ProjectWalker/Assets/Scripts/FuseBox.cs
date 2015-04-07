using UnityEngine;
using System.Collections;

public class FuseBox : MonoBehaviour {

	public bool accessable;
	public bool lightsOn;
	public bool firstLight;
	
	public float lightTimer;
	
	bool enterRange;

	public AudioClip lightSwitchNoise; //temporary sound name
	private AudioSource source;

	GameObject darknessWall;
	GameObject lights;
	Light[] allChildren;
	
	// Use this for initialization
	void Start () {
		accessable = false;
		lightsOn = false;
		firstLight = true;
		
		source = GetComponent<AudioSource> ();
		darknessWall = GameObject.Find ("Invisible Darkness Wall");
		lights = GameObject.Find("Room 3 Lights");
		
		allChildren = lights.GetComponentsInChildren<Light>();
		for( int i = 0; i < allChildren.Length; i++){
			Light light = allChildren[i];
			light.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (accessable == true && lightsOn == false && enterRange && Input.GetKeyDown ("f"))
		{
			//source.PlayOneShot(lightSwitchNoise, 4f);
			// turn on lights in room 3
			lightsOn = true;
			darknessWall.SetActive(false);
			
			
			
			
		}
		
		if(lightsOn){
			if(firstLight){
				lightTimer = Time.time;
				firstLight = false;
			}
			
			for( int i = 0; i < allChildren.Length; i++){
				Light light = allChildren[i];
				
				if(i % 4 == 0 && lightTimer + 1 <= Time.time ){
					light.enabled = true;
				} 
				
				if(i % 4 == 1 && lightTimer + 2 <= Time.time){
					light.enabled = true;
				}
				
				if(i % 4 == 2 && lightTimer + 3 <= Time.time){
					light.enabled = true;
				}
				
				if(i % 4 == 3 && lightTimer + 4 <= Time.time){
					light.enabled = true;
				}
			}	
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
