using UnityEngine;
using System.Collections;

public class EnemyReplayVisibility : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("hero");
	}
	
	// Update is called once per frame
	void Update () {
		GetComponentInChildren<SpriteRenderer> ().enabled = player.GetComponent<InputVCR> ().mode == InputVCRMode.Playback;
	}
}
