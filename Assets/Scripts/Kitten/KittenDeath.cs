using UnityEngine;
using System.Collections;

public class KittenDeath : MonoBehaviour {

	// Use this for initialization
	public void Die () {
		GameObject.Destroy(gameObject);
		Score.instance.kittenKilled++;
	}
}
