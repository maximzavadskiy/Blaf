using UnityEngine;
using System.Collections;

public class DieFromBullet : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.CompareTag ("Bullet")) {
			SendMessage("Die"); //Deat script will handle it, different for kitten and monster
		}
	}
}
