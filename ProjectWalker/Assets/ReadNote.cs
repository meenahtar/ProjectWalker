using UnityEngine;
using System.Collections;

public class ReadNote : MonoBehaviour {

	GameObject note;

	// Use this for initialization
	void Start () {
		note = GameObject.Find ("Image"); //.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp ("o")) {
			if(note.activeSelf)
			{
				note.SetActive(false);
			}
			else
			{
				note.SetActive(true);
			}
			//note.GetComponent<Image> ().SetActive(true);
		}
		
	}
}
