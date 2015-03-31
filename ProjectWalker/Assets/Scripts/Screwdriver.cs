using UnityEngine;
using System.Collections;

public class Screwdriver : MonoBehaviour {

	GameObject screwDriver;

	bool enter;

	public bool screwDriverObtained;

	
	// Use this for initialization
	void Start () 
	{
		screwDriver = GameObject.Find ("Screw Driver");
		screwDriverObtained = false;
		screwDriver.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("g") && enter)
		{
			screwDriverObtained = true;
			screwDriver.SetActive(false);
		}
	}
	
	void OnGUI()
	{
		if(enter)
		{
			GUI.Label(new Rect(Screen.width/2 - 175, Screen.height - 100, 350, 30), "Press 'G' to grab screwdriver");
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
