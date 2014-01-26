using UnityEngine;
using System.Collections;

public class HeroDeath : MonoBehaviour {

	public GameObject deathParticlePrefab;
	private GameObject particleObject = null;
	float timer = -1f;

	public void showParticleEffect()
	{
		Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
		timer = Time.realtimeSinceStartup;
	}

	void Update()
	{
		if (timer > 0 && Time.realtimeSinceStartup - timer > 0.1f)
		{
			showParticleEffect();

			//Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
			//timer = -1;
		}
	}
}
