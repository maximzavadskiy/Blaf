using UnityEngine;
using System.Collections;

public class KittenDeath : MonoBehaviour {

	public GameObject enemyToSpawn;

	// Use this for initialization
	public void Die () {
		GameObject.Destroy(gameObject);
		Score.instance.kittenKilled++;

		Instantiate (enemyToSpawn, transform.position, Quaternion.identity);
	}
}
