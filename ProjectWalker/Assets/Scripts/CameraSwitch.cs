using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public Camera firstPersonCamera;
	public Camera keyPadCamera;

	// Use this for initialization
	void Start () {
		firstPersonCamera.enabled = true;
		keyPadCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void useKeyPad() {
		firstPersonCamera.enabled = false;
		keyPadCamera.enabled = true;
	}

	public void stopUseKeyPad() {
		keyPadCamera.enabled = false;
		firstPersonCamera.enabled = true;
	}

	public Camera returnActiveCamera() {
		if (firstPersonCamera.enabled) {
			return firstPersonCamera;
		} else {
			return keyPadCamera;
		}
	}
}
