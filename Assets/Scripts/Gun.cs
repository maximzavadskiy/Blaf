﻿using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

	public float speed = 20f;				// The speed the rocket will fire at.

	private Rigidbody2D rocket;				// Prefab of the rocket.

	bool isShootingRight = true;
	private Animator anim;					// Reference to the Animator component.
	
	private InputVCR vcr;

	private int shootCooldown = 0;

	void Awake()
	{		
		Transform root = transform;
		while ( root.parent != null )
			root = root.parent;
		vcr = root.GetComponent<InputVCR>();

		// Setting up the references.
		//print (GameObject.Find ("RocketPrefab"));
		rocket = ((GameObject) Resources.Load("rocket")).GetComponent<Rigidbody2D>();
		anim = transform.root.gameObject.GetComponent<Animator>();
	}


	void Update ()
	{
		if (vcr.GetKey ("a"))
			isShootingRight = false;

		if (vcr.GetKey ("d"))
			isShootingRight = true;

		shootCooldown--;

		// If the fire button is pressed...
		//if(Input.GetButtonDown("Fire1"))
		if (shootCooldown <= 0 && (vcr.GetKey ("a") || vcr.GetKey ("d")))
		{
			shootCooldown = 20;

			// ... set the animator Shoot trigger parameter and play the audioclip.
			anim.SetTrigger("Shoot");
			audio.Play();

			// If the player is facing right...
			if(isShootingRight)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}
}
