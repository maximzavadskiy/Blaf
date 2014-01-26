using UnityEngine;
using System.Collections;

public class MonsterDeath : MonoBehaviour {

	public GameObject deathParticlePrefab;

	bool delayedDeath = false;
	float timer = 0;


	//called from SendMessage
	public void Die() 
	{
		delayedDeath = true;
		timer = Time.realtimeSinceStartup;
	}

	void Update()
	{
		if (delayedDeath && (Time.realtimeSinceStartup - timer > 0.2f))
		{
			Instantiate (deathParticlePrefab, transform.position, Quaternion.identity);
			GameObject.Destroy(gameObject);
			Score.instance.kills++;
		}
	}
}
