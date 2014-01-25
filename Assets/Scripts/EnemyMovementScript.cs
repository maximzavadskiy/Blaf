using UnityEngine;
using System.Collections;

public class EnemyMovementScript : MonoBehaviour 
{
	private bool facingRight = true;


	private Transform edgeRight = null;
	private Transform edgeLeft = null;

	private Transform wallCheckRight = null;
	private Transform wallCheckLeft = null;

	public float speed = 1f;
	// Use this for initialization
	void Start () 
	{
		edgeRight = transform.FindChild("PlatformEdgeCheckerRight");
		edgeLeft = transform.FindChild("PlatformEdgeCheckerLeft");

		wallCheckRight = transform.FindChild("WallCheckerRight");
		wallCheckLeft = transform.FindChild("WallCheckerLeft");;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		bool hasGroundInFront = Physics2D.Linecast (transform.position, 
		                                               facingRight ? edgeRight.position : edgeLeft.position,
		                                               1 << LayerMask.NameToLayer ("Ground"));
		if (!hasGroundInFront) {
						facingRight = !facingRight;
						//TODO: delay? animation?
			//don't have ground in the front then let's check if we face a wall
				} else {
					bool hasWallInFront = Physics2D.Linecast (transform.position, 
			                                          facingRight ? wallCheckRight.position : wallCheckLeft.position,
			                                            1 << LayerMask.NameToLayer ("Ground"));
					if(hasWallInFront)
						facingRight = !facingRight;
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
