using UnityEngine;
using System.Collections;

public class WraithSpawnMovement : MonoBehaviour {
	
	public GameObject enemyToSpawn;
	private float timeAlive = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		pos.y += Time.deltaTime * 2;
		transform.position = pos;
		transform.renderer.material.color = new Color (timeAlive * 0.5f, timeAlive * 0.5f, 1.0f, 1 - timeAlive * 0.5f);
		transform.localScale = new Vector3 (timeAlive + 0.1f, timeAlive + 0.1f, timeAlive) * 0.12f;

		timeAlive += Time.deltaTime;
		if (timeAlive > 2.0f)
		{
			Debug.Log (Time.time);
			Instantiate (enemyToSpawn, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
