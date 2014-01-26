using UnityEngine;
using System.Collections;

public class KittenDeath : MonoBehaviour {

	public GameObject enemyToSpawn;

	public GameObject deathParticlePrefab;


	bool delayedDeath = false;
	float timer = 0;

	void Update()
	{
		if (delayedDeath && (Time.realtimeSinceStartup - timer > 0.1f))
		{
			Instantiate (enemyToSpawn, transform.position, Quaternion.identity);
			if(deathParticlePrefab) Instantiate (deathParticlePrefab, transform.position, Quaternion.identity);
			
			GameObject.Destroy(gameObject);
			Score.instance.kittenKilled++;
			

		}
	}
	
	public void Die () {

		delayedDeath = true;
		timer = Time.realtimeSinceStartup;
		collider2D.enabled = false;


	}
}
