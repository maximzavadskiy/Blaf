using UnityEngine;
using System.Collections;

public class PlayerToCatDistance : MonoBehaviour {

	private Animator anim = null;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 toPlayer = transform.position - GameObject.Find ("hero").transform.position;
		anim.SetFloat("distance", toPlayer.sqrMagnitude);
	}
}
