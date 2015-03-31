using UnityEngine;
using System.Collections;

public class CharacterSpeech : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open drawer");
		/*if(enterRange && opened == false && GameObject.Find("Note2").GetComponent<ReadNote2>().getKey == true){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open drawer");
		}*/

		
	}
}
