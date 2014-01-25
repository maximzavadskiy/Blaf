using UnityEngine;
using System.Collections;

public class CollectKitten : MonoBehaviour {

	public AudioClip collectSound;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D (Collider2D collider) {
		print (collider.name);
		if(collider.CompareTag("Player")) { 
			// play from independent source, as kittens are gonna be removed  :(
			if(collectSound) AudioSource.PlayClipAtPoint(collectSound, transform.position);
			Score.instance.kittenSaved++;
			Destroy(gameObject);
		}
	}
}
