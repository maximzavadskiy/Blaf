﻿using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int kills = 0;

	public int kittenSaved = 0;
	public int kittenKilled = 0;

	//singleton, resets every level

	public static Score instance;

	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Kills: " + (kills/2).ToString () + "\nKitten saved :" + kittenSaved + "\nKitten lost :" + kittenKilled;
	}
}