using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadNote2 : MonoBehaviour {
	
	GameObject note;
	//first person controller
	GameObject FPC;
	//main camera
	GameObject MC;
	GameObject drawer;
	
	bool open;
	bool enter;
	
	Sprite noteSprite;
	string noteName;
	

	// Use this for initialization
	void Start () 
	{
		 //.GetComponent<Image> ();
		//note = GameObject.Find ("Image");
		//note = GameObject.Find("Note1").GetComponent<ReadNote> ().note;
		FPC = GameObject.Find ("First Person Controller");
		MC = GameObject.Find ("Main Camera");
		drawer = GameObject.Find("deskDrawer");
		note = this.gameObject;
		
		open = false;
		enter = false;

		
		//noteName = gameObject.name;
		//noteName = "note2";
		//noteSprite = Resources.Load<Sprite>(noteName);
		//note.GetComponent<Image>().sprite = noteSprite;
		//cannot use extra script
		//may have to extend parent class and have differences in local class
		
		note.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//note.GetComponent<Image> ().SetActive(true);

		//print (drawer.GetComponent<OpenableDesk> ().opened);
		if(Input.GetKeyDown("g") && enter)
		{
			if (open) 
			{

				note.SetActive(false);
				open = false;
				FPC.GetComponent<MouseLook>().enabled = true;
				FPC.GetComponent<CharacterMotor>().enabled = true;
				MC.GetComponent<MouseLook>().enabled = true;
			}
			else
			{
				note = GameObject.Find("Note1").GetComponent<ReadNote> ().note;
				noteName = gameObject.name;
				noteSprite = Resources.Load<Sprite>(noteName);
				note.GetComponent<Image>().sprite = noteSprite;

				note.SetActive(true);
				open = true;
				FPC.GetComponent<MouseLook>().enabled = false;
				FPC.GetComponent<CharacterMotor>().enabled = false;
				MC.GetComponent<MouseLook>().enabled = false;
				
				
			}
		}
		
	}
	
	void OnGUI()
	{
		if(enter)
		{
			if (open) {
				GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 160, 150, 30), "Press 'G' to close note");
			}
			else {
				GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 160, 150, 30), "Press 'G' to read note");
			}
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

