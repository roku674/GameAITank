using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour {
	GameObject MyCube;
	GameObject Tank;
	float x=0f;
	// Use this for initialization
	void Start () {
		Tank = GameObject.Find ("Tank3");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L)) {
			MyCube = Instantiate(Resources.Load ("Doodle") as GameObject,Tank.transform.position + new Vector3(0,0+x++,3),Quaternion.identity);
		}
	}
}
