using UnityEngine;
using System.Collections;

public class DieFromBullet : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.CompareTag("Bullet"))
						GameObject.Destroy (gameObject);
	}
}
