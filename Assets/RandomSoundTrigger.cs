using UnityEngine;
using System.Collections;

public class RandomSoundTrigger : MonoBehaviour {

	public AudioClip[] sounds;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			if(sounds.Length > 0 ) AudioSource.PlayClipAtPoint( sounds[Random.Range(0,sounds.Length - 1 )], transform.position, 100f );
			Destroy(gameObject);
		}
	}
}
