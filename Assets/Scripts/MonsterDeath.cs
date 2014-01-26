using UnityEngine;
using System.Collections;

public class MonsterDeath : MonoBehaviour {

	public GameObject deathParticlePrefab;

	//called from SendMessage
	public void Die() 
	{
		Instantiate (deathParticlePrefab, transform.position, Quaternion.identity);
		GameObject.Destroy(gameObject);
		Score.instance.kills++;
	}
}
