using UnityEngine;
using System.Collections;

public class FollowHero : MonoBehaviour {

	private GameObject hero;
	// Use this for initialization
	void Start () {
		hero = GameObject.Find ("hero");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 heroPos = hero.transform.position;
		heroPos.z = transform.position.z;
		transform.position = heroPos;
	}
}
