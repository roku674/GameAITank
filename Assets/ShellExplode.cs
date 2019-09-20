using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplode : MonoBehaviour {
    GameObject Explosion;
    GameObject ExplosionSound;
    //public AudioClip explosionSound;

	// Use this for initialization
	void Start () {
		Explosion = GameObject.Find ("BigExplosionEffect");
        ExplosionSound = GameObject.Find("ExplosionSound");
	}

	//Event handler that fires when the current object collides with something
	void OnCollisionEnter(Collision c) {

		//Point of contact
		Vector3 hitPoint = c.contacts [0].point;

		GameObject explosion = Instantiate (Explosion, hitPoint, Quaternion.identity);
        GameObject explosionSound = Instantiate(ExplosionSound, hitPoint, Quaternion.identity);
        explosionSound.GetComponent<AudioSource>().Play();

		Destroy (explosionSound, 2.0f);
        //ad force explosio
        Collider[] explosionVictims;
        explosionVictims = Physics.OverlapSphere(hitPoint, 20);       
        foreach(Collider victim in explosionVictims)
         {
            Vector3 forceDirection = victim.transform.position - hitPoint;
            forceDirection.Normalize();
            victim.attachedRigidbody.AddForce(1000 * forceDirection);
         }
        

        //Make an explosion sound
        //AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        //Destroy the parent object
        Destroy(gameObject);

	}


}
