using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public float shotAngle = 20f;
	public float shotReach = 3f;

	public float shotReloadTime = 0.5f;

	public int linecastsAmount = 10;

	public GameObject deathParticlePrefab;

	bool isShootingRight = true;
	private Animator anim;					// Reference to the Animator component.
	
	private InputVCR vcr;

	private int shootCooldown = 0;

	private float lastShotTime;

	void Awake()
	{		
		Transform root = transform;
		while ( root.parent != null )
			root = root.parent;
		vcr = root.GetComponent<InputVCR>();
		
		anim = transform.root.transform.FindChild ("body").GetComponent<Animator>();

		lastShotTime = -shotReloadTime;
	}


	void Update ()
	{
		if (transform.root.GetComponent<PlayerControl>().controlsDisabled) return;
		if (vcr.GetKey ("a"))
			isShootingRight = false;

		if (vcr.GetKey ("d"))
			isShootingRight = true;
	

		// If the fire button is pressed...
		//if(Input.GetButtonDown("Fire1"))
		if (Time.time > lastShotTime + shotReloadTime && (vcr.GetKey ("a") || vcr.GetKey ("d")))
		{
			lastShotTime = Time.time;
			// ... set the animator Shoot trigger parameter and play the audioclip.
		//	anim.SetTrigger("Shoot");
			audio.Play();

			ShotGunShoot();
		}
	}

	private void ShotGunShoot() {

		int playerLayerMask = ~(1 << LayerMask.NameToLayer ("Player"));
		Instantiate (deathParticlePrefab, transform.position, isShootingRight ? Quaternion.identity:Quaternion.Euler (0,0,180f));
		ArrayList toKills = new ArrayList();

		for (float angle = -shotAngle; angle <= shotAngle; angle += shotAngle/(linecastsAmount-1)) {
			Vector2 frontDirection = isShootingRight ? Vector2.right : - Vector2.right;
			Vector2 raycastVector = Quaternion.Euler(0,0,angle) * frontDirection ;

			Debug.DrawLine(transform.position,new Vector2(transform.position.x, transform.position.y) + raycastVector * shotReach , Color.red, 0.5f);

			RaycastHit2D newHit = Physics2D.Raycast(transform.position, raycastVector, shotReach, playerLayerMask);

			bool alreadyExist = false;
			foreach (RaycastHit2D prevHit in toKills)
			{
				if(prevHit.collider == newHit.collider) {
					alreadyExist = true;
					break;
				}
			}

			if(!alreadyExist)
				toKills.Add(newHit);
		}

		foreach(RaycastHit2D toKill in toKills) {
			//print (toKill.)
			//RaycastHit2D toKill = (RaycastHit2D )obj;
			if(toKill.collider != null) {

				//print (Vector2.Angle(isShootingRight ? Vector2.right : - Vector2.right, toKill.collider.transform.position - transform.position) );
				toKill.collider.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
		
}
