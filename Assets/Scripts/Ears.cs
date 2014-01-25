using UnityEngine;
using System.Collections;

public class Ears : MonoBehaviour {

	// Use this for initialization

	private float muteSmoothingFactor = 2f;

	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int playerLayerMask = ~(1 << LayerMask.NameToLayer ("Player"));

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		foreach (GameObject enemy in enemies) {
			GameObject hittedObject = null;
			//if raycast only hits the enemy we are checking - then nothing in betweeen!
			if (enemy.name != "Wraith" || enemy.GetComponent<CircleCollider2D>().enabled)
				hittedObject = Physics2D.Raycast(transform.position, enemy.transform.position - transform.position, float.PositiveInfinity, playerLayerMask).collider.gameObject;

			if( hittedObject == enemy) {
				enemy.GetComponent<AudioSource>().mute = false;
				enemy.GetComponent<AudioSource>().volume = Mathf.Clamp01(1 - Mathf.Abs(transform.position.y - enemy.transform.position.y) * 0.3f);
			}
			else
				enemy.GetComponent<AudioSource>().mute = true;
		}
	}

//	IEnumerator SetMuteSmoothly(AudioSource audio) {
//		if (audio) {
//			//if(audio)
//		}
//	}
}
