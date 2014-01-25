using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.


	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.

	public GameObject recordKeeperPrefab;


	private float jumpForce = 850f;			// Amount of force added when the player jumps.
	private float maxSpeed = 7.5f;				// The fastest the player can travel in the x axis.
	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.

	private bool useVCR;
	private InputVCR vcr;
	private int jumpCooldown = 0;

	private bool stuckOnUprightWall = false;

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = transform.FindChild("body").GetComponent<Animator>();
		
		Transform root = transform;
		while ( root.parent != null )
			root = root.parent;
		vcr = root.GetComponent<InputVCR>();
		useVCR = vcr != null;

		// Spawn record keeper if it doesn't exist
		GameObject recordKeeper = GameObject.Find ("RecordKeeper(Clone)");
		if (recordKeeper == null)
		{
			recordKeeper = Instantiate(recordKeeperPrefab) as GameObject;

		}

		// Playback on win
		if (recordKeeper.GetComponent<RecordKeeper>().recording != null)
		{
			vcr.Play(recordKeeper.GetComponent<RecordKeeper>().recording, 0);
		}
		else
		{
			// Record otherwise
			vcr.NewRecording();
		}
	}


	void Update()
	{
		if (GameObject.FindWithTag("Kitten") == null)
		{
			// WIN!
			GameObject recordKeeper = GameObject.Find ("RecordKeeper(Clone)");
			recordKeeper.GetComponent<RecordKeeper>().recording = vcr.GetRecording();

			Application.LoadLevel(Application.loadedLevel);
			return;
		}

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		// If the jump button is pressed and the player is grounded then the player should jump.
		if (grounded && !jump && jumpCooldown <= 0)
		{
			if (useVCR)
			{
				jump = vcr.GetButton("Jump");
				if (jump)
				{
					jumpCooldown = 5;
				}
			}
			else
			{
				jump = Input.GetButtonDown("Jump");
			}
		}
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		int upwardNormals = 0;
		foreach(ContactPoint2D point in collision.contacts)
		{
			float angle = Mathf.Atan2(point.normal.y, point.normal.x);
			if (angle > Mathf.PI/4 && angle < 3*Mathf.PI/4)
				upwardNormals++;
		}
		if (upwardNormals == 0)
			stuckOnUprightWall = true;
		else stuckOnUprightWall = false;
	}

	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = 0.0f;
		
		if ( useVCR )
			h = vcr.GetAxis( "Horizontal" );
		else
			h = Input.GetAxisRaw("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		//if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			//rigidbody2D.AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		//if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			//rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if (!stuckOnUprightWall) 
		{
			Vector2 current_velocity = rigidbody2D.velocity;
			current_velocity.x = h * maxSpeed;
			rigidbody2D.velocity = current_velocity;
		}
		else
		{
			stuckOnUprightWall = false;		
		}
		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		jumpCooldown--;
		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			// Play a random jump audio clip.
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	public IEnumerator Taunt()
	{
		// Check the random chance of taunting.
		float tauntChance = Random.Range(0f, 100f);
		if(tauntChance > tauntProbability)
		{
			// Wait for tauntDelay number of seconds.
			yield return new WaitForSeconds(tauntDelay);

			// If there is no clip currently playing.
			if(!audio.isPlaying)
			{
				// Choose a random, but different taunt.
				tauntIndex = TauntRandom();

				// Play the new taunt.
				audio.clip = taunts[tauntIndex];
				audio.Play();
			}
		}
	}


	int TauntRandom()
	{
		// Choose a random index of the taunts array.
		int i = Random.Range(0, taunts.Length);

		// If it's the same as the previous taunt...
		if(i == tauntIndex)
			// ... try another random taunt.
			return TauntRandom();
		else
			// Otherwise return this index.
			return i;
	}
}
