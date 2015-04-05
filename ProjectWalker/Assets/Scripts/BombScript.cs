using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
	
	GameObject bomb;
	
	bool enter;
	
	public bool bombObtained;
	
	
	// Use this for initialization
	void Start () 
	{
		bomb = GameObject.Find ("Cherry Bomb");
		bombObtained = false;
		//screwDriver.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("g") && enter)
		{
			bombObtained = true;
			bomb.SetActive(false);
		}
	}
	
	void OnGUI()
	{
		if(enter)
		{
			GUI.Label(new Rect(Screen.width/2 - 175, Screen.height - 100, 350, 30), "Press 'G' to grab Cherry Bomb");
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

