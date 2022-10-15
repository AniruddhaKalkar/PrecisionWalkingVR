using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys the gameobject when the object collides with it
/// </summary>
public class DestroyOnTouch : MonoBehaviour {
	private AudioSource audioSource;
	private bool destroyed = false;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider other){
		//don't destroy obstacles
		if (other.tag != "Obstacle" && !destroyed) {
			destroyed = true;
			//make sure sound is played before object is destroyed
			if (audioSource) {
				audioSource.Play ();
				Destroy (this.gameObject, audioSource.clip.length);
				GetComponent<MeshRenderer> ().enabled = false;
			} else {
				Destroy (this.gameObject);
			}
		}
	}
}
