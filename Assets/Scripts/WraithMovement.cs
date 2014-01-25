using UnityEngine;
using System.Collections;

public class WraithMovement : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("hero");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPosition = transform.position;
		newPosition.y += (player.transform.position.y > newPosition.y ? 1 : -1) * 0.03f;

		float xMove = (player.transform.position.x > newPosition.x ? 1 : -1) * 0.05f;

		// Stay away
		if (Mathf.Abs(player.transform.position.y - newPosition.y) > 1)
		{
			// Go further away
			if (Mathf.Abs(player.transform.position.x - newPosition.x) < 10)
				newPosition.x -= xMove;

			GetComponent<CircleCollider2D>().enabled = false;
		}
		else
		{
			// Chase
			newPosition.x += xMove;

			GetComponent<CircleCollider2D>().enabled = true;
		}
		transform.position = newPosition;
	}
}
