using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour {
	public Camera cam1;
	public Camera cam2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//"C" key toggles the cameras
		if(Input.GetKeyDown(KeyCode.C)){
			//Check which camera is active
			if (cam1.enabled) {
				cam1.enabled = false;
				cam2.enabled = true;
			} else {
				cam1.enabled = true;
				cam2.enabled = false;
			}
		} 

	}
}
