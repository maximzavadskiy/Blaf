using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int kills = 0;

	public int kittenSaved = 0;
	public int kittenKilled = 0;
	private int totalKittens;

	//singleton, resets every level

	public static Score instance;

	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}

	void Start()
	{
		totalKittens = GameObject.FindGameObjectsWithTag("Kitten").GetLength(0);
	}

	// Update is called once per frame
	void Update () {
		guiText.text = "Kills: " + kills.ToString () + "\nKittens saved: " + kittenSaved + "/" + totalKittens;
	}
}
