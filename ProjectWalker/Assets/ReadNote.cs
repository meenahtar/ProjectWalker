using UnityEngine;
using System.Collections;

public class ReadNote : MonoBehaviour {

	GameObject note;
	bool open;
	bool enter;

	// Use this for initialization
	void Start () 
	{
		note = GameObject.Find ("Image"); //.GetComponent<Image> ();
		open = false;
		enter = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (open) 
		{
			//note.Destroy();
			note.SetActive(true);
			print ("working");
		}
		else
		{
			note.SetActive(false);
		}
			//note.GetComponent<Image> ().SetActive(true);


		if(Input.GetKeyDown("f") && enter)
		{
			open = !open;
		}

	}

	void OnGUI()
	{
		if(enter)
		{
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to read note");
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
