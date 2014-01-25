using UnityEngine;
using System.Collections;

public class EnemyMovementScript : MonoBehaviour 
{
	private bool facingRight = true;
	private Transform edgeRight = null;
	private Transform edgeLeft = null;
	public float speed = 1f;
	// Use this for initialization
	void Start () 
	{
		edgeRight = transform.FindChild("PlatformEdgeCheckerRight");
		edgeLeft = transform.FindChild("PlatformEdgeCheckerLeft");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		bool hasGroundInFront = Physics2D.Linecast (transform.position, 
		                                               facingRight ? edgeRight.position : edgeLeft.position,
		                                               1 << LayerMask.NameToLayer ("Ground"));
		if (!hasGroundInFront) 
		{
			facingRight = !facingRight;
			//TODO: delay? animation?
		}

		//Vector2 force = Vector2.right;
		//if (!facingRight)
		//	force *= -1;
		//force *= speed;
		//if (rigidbody2D.velocity.x* < maxSpeed)
		//	rigidbody2D.AddForce(force);
		Vector2 vel = rigidbody2D.velocity;
		vel.x = facingRight ? speed : -speed;
		rigidbody2D.velocity = vel;

	}
}
