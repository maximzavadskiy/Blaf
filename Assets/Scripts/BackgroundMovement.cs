using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xOffset = -transform.parent.transform.position.x * 0.1f;
		float yOffset = -transform.parent.transform.position.y * 0.1f + 5;
		Vector3 newPos = new Vector3 (xOffset, yOffset, transform.localPosition.z);
		transform.localPosition = newPos;
	}
}
