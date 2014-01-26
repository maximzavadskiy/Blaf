using UnityEngine;
using System.Collections;

public class PlayerToCatDistance : MonoBehaviour {

	private Animator anim = null;

	// Use this for initialization
	void Start () 
	{
		anim = transform.FindChild ("body").GetComponent<Animator>();
		audio.volume = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 toPlayer = transform.position - GameObject.Find ("hero").transform.position;
		anim.SetFloat("distance", toPlayer.sqrMagnitude);
		audio.mute = toPlayer.sqrMagnitude > 100;
		audio.volume = (1 - (toPlayer.sqrMagnitude/100))*0.2f;
	}
}
