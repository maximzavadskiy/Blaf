using UnityEngine;
using System.Collections;

public class EnemyReplayVisibility : MonoBehaviour {

	GameObject player;
	public bool showEnemy = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("hero");
	}
	
	// Update is called once per frame
	void Update () {
		GetComponentInChildren<SpriteRenderer> ().enabled = (player.GetComponent<InputVCR> ().mode == InputVCRMode.Playback || showEnemy);
	}
}
