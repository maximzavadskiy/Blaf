﻿using UnityEngine;
using System.Collections;

public class RecordKeeper : MonoBehaviour {

	public Recording recording;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}