using UnityEngine;
using System.Collections;

public class MonsterSound : MonoBehaviour {

	public AudioClip farSound;
	public AudioClip closeSound;
	public float closeDistance = 2f;
	public float maxYDiffForCloseSound = 0.5f;

	Transform playerTrans;
	// Use this for initialization
	void Start () {
		playerTrans = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTrans) {
			if(((playerTrans.position - transform.position).magnitude < closeDistance) && (Mathf.Abs(transform.position.y - playerTrans.position.y) < maxYDiffForCloseSound)) {
				audio.clip = closeSound;

			}
			else 
				audio.clip = farSound;

			if(!audio.isPlaying) audio.Play();
			//1 - Mathf.Abs(transform.position.y - enemy.transform.position.y) * 0.3f
		}
	}
}
