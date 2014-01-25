using UnityEngine;
using System.Collections;

public class MonsterDeath : MonoBehaviour {

	//called from SendMessage
	public void Die() {
		GameObject.Destroy(gameObject);
		Score.instance.kills++;
	}
}
