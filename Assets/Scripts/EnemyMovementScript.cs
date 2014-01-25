using UnityEngine;
using System.Collections;

public class EnemyMovementScript : MonoBehaviour 
{
	private bool facingRight = false;


	private Transform edgeRight = null;
	private Transform edgeLeft = null;

	private Transform wallCheckRight = null;
	private Transform wallCheckLeft = null;
	//private Animator anim = null;

	public float speed = 1f;
	// Use this for initialization
	void Start () 
	{
		edgeRight = transform.FindChild("PlatformEdgeCheckerRight");
		edgeLeft = transform.FindChild("PlatformEdgeCheckerLeft");

		wallCheckRight = transform.FindChild("WallCheckerRight");
		wallCheckLeft = transform.FindChild("WallCheckerLeft");
		//anim = transform.FindChild("body").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		bool hasGroundInFront = Physics2D.Linecast (transform.position, edgeLeft.position, 1 << LayerMask.NameToLayer ("Ground"));
		                                               //facingRight ? edgeRight.position : edgeLeft.position,
		                                               //1 << LayerMask.NameToLayer ("Ground"));
		if (!hasGroundInFront) 
		{
			facingRight = !facingRight;
			
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		else 
		{
			bool hasWallInFront = Physics2D.Linecast (transform.position,wallCheckLeft.position,1 << LayerMask.NameToLayer ("Ground"));
	                                          //facingRight ? wallCheckRight.position : wallCheckLeft.position,
	                                            //1 << LayerMask.NameToLayer ("Ground"));
			if(hasWallInFront)
			{
				facingRight = !facingRight;
				
				// Multiply the player's x local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
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
