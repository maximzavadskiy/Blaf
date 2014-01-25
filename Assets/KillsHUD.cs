using UnityEngine;
using System.Collections;

public class KillsHUD : MonoBehaviour {

	public int kills = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Kills: " + (kills/2).ToString ();
	}
}
