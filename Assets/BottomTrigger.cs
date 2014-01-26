using UnityEngine;
using System.Collections;

public class BottomTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject.Find ("hero").GetComponent<PlayerHealth>().KillPlayer();
	}
}
