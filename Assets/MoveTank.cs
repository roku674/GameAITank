using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour {
	float accel=0;
	const float maxSpeed = 5.0f;
	AudioSource aud;
	Camera cam;
	GameObject turret;
	GameObject gun;

	//Used to keep track of the angle of the gun
	float gunAngle = 0;  
	const float maxGunAngle = 40.0f;
	const float minGunAngle = -6.0f;


	// Use this for initialization
	void Start () {
		//Get a reference to the audio source
		aud = GetComponent<AudioSource> ();
		//Get a reference to the second camera
		cam = GameObject.Find("Camera").GetComponent<Camera>();
		//Get a reference to the turret
		turret = GameObject.Find("turret");
		//Get a reference to the gun
		gun =  GameObject.Find("gun");
	}

	// Update is called once per frame
	void Update () {


		int z = 2;

		transform.position += accel * transform.forward * Time.deltaTime;

		aud.volume = Mathf.Abs( 0.1f + accel / (maxSpeed * 2.0f));
			
		//Move forward
		if (Input.GetKey (KeyCode.W)) {
			if (accel < maxSpeed)
				accel += 2.0f*Time.deltaTime;
		} else { //decelerate
			if (accel > 0)
				accel -= 2.0f*Time.deltaTime;
		}

		//Move backwards
		if (Input.GetKey (KeyCode.S)) {
			if (accel > -maxSpeed)
				accel -= 2.0f*Time.deltaTime;
		} else { //decelerate
			if (accel < 0)
				accel += 2.0f*Time.deltaTime;
		}

		//Turn Right
		if(Input.GetKey(KeyCode.D) ) transform.Rotate(0,50.0f*Time.deltaTime,0);

		//Turn Left
		if(Input.GetKey(KeyCode.A) ) transform.Rotate(0,-50.0f*Time.deltaTime,0);
	
	    //Zoom second camera in
		if(Input.GetKey(KeyCode.Z) ) cam.transform.position += cam.transform.forward * Time.deltaTime;

		//Zoom second camera out
		if(Input.GetKey(KeyCode.X) ) cam.transform.position -= cam.transform.forward * Time.deltaTime;
	
		//If the right mouse button is pressed
		if (Input.GetMouseButton (1)) {

			//Get the horizontal and vertical movement of the mouse
			float h = Input.GetAxis ("Mouse X");
			float v = Input.GetAxis ("Mouse Y");

			//Rotate the turret
			if (h!=0) turret.transform.Rotate(0,h*Time.deltaTime*300,0);

			//Rotate the gun
			if (v!=0) rotateGun(v);
		}
	}

	//A method to restrict rotation of the gun
	void rotateGun(float angle) {
		float angleOfRotation = angle*Time.deltaTime*100;
		float newGunAngle = gunAngle + angleOfRotation;
		if (newGunAngle >= minGunAngle && newGunAngle <= maxGunAngle) {
			gun.transform.Rotate (0, 0, angle * Time.deltaTime * 100);
			gunAngle = newGunAngle;
		}
	}

}
