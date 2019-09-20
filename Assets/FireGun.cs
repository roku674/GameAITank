using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {
	GameObject tankShell;
	GameObject shellStart;
	GameObject gun;
	AudioSource gunShotSound;

	// Use this for initialization
	void Start () {
		tankShell = GameObject.Find ("TankShell");
		shellStart = GameObject.Find ("ShellStart");
		gun = GameObject.Find ("gun");
		gunShotSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		int x = 3;
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject newShell = Instantiate (tankShell, shellStart.transform.position, shellStart.transform.rotation);

			//Destroys the shell after 5 seconds
			Destroy (newShell, 5.0f);

			//Add some force to the shell
			newShell.GetComponent<Rigidbody> ().AddForce (gun.transform.right * 200000);

			gunShotSound.Play ();

		}
	}
}
