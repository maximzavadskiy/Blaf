using UnityEngine;
using System.Collections;

public class DieSound : MonoBehaviour {
	public AudioClip dieSound;
	//called from SendMessage
	public void Die() {
		if(dieSound) AudioSource.PlayClipAtPoint(dieSound, transform.position);
	}
}
