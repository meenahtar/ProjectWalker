using UnityEngine;
using System.Collections;

public class LighterPickup : MonoBehaviour {

	GameObject lighter;	
	bool enter;
	GameObject FPC;
	public bool lighterObtained;
	
	// Use this for initialization
	void Start () 
	{
		lighterObtained = false;
		lighter = GameObject.Find ("Lighter");
		FPC = GameObject.Find ("First Person Controller");
		lighter.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("g") && enter)
		{
			//FPC.GetComponent<CharacterSpeech>().screwDriverObtained = true;
			lighterObtained = true;
			lighter.SetActive(false);
		}
	}
	
	void OnGUI()
	{
		if(enter)
		{
			GUI.Label(new Rect(Screen.width/2 - 175, Screen.height - 100, 350, 30), "Press 'G' to grab lighter");
		}
	}
	
	//If player enters note zone
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			enter = true;
		}
	}
	
	//If player exits note zone
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") 
		{
			enter = false;
		}
	}
}
