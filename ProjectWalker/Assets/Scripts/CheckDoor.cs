using UnityEngine;
using System.Collections;

public class CheckDoor : MonoBehaviour {

	GameObject bomb;
	bool doorCheck;
	public bool bombPlaced;

	// Use this for initialization
	void Start () 
	{
		doorCheck = false;
		bombPlaced = false;
		bomb = GameObject.Find ("Cherry Bomb");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If you are at the 3rd room door..
		if (doorCheck == true && bomb.GetComponent<BombScript>().bombObtained) 
		{
			if (Input.GetKeyDown ("g")) 
			{
				bomb.GetComponent<BombScript>().enabled = false;
				bomb.transform.Translate(new Vector3(17.5f, 5.0f, -15.0f), Space.Self);
				bomb.SetActive(true);
				bombPlaced = true;
			} 

		}
	}

	void OnGUI(){
		if(doorCheck && bomb.GetComponent<BombScript>().bombObtained)
		{
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'G' to place bomb");
		}

		
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "bombDoor") {
			doorCheck = true;
		}
	}

	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){
		if (other.gameObject.name == "bombDoor") {
			doorCheck = false;
		}
	}
}
