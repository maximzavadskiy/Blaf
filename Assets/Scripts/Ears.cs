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
			//if raycast only hits the enemy we are checking - then nothing in betweeen!
			GameObject hittedObject = Physics2D.Raycast(transform.position, enemy.transform.position - transform.position, float.PositiveInfinity, playerLayerMask).collider.gameObject;

			if( hittedObject == enemy) {
				enemy.GetComponent<AudioSource>().mute = false;
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
