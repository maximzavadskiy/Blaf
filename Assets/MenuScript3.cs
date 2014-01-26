using UnityEngine;
using System.Collections;

public class MenuScript3 : MonoBehaviour {
	// Use this for initialization
	void Awake()
	{
		//GameObject.Find ("Recording").SetActive(false);
	}
	void Start () 
	{
		Debug.Log("level: " + Application.loadedLevelName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartAction(int id)
	{
		switch(id)
		{
		case 0: 
			//play
			transform.root.gameObject.SetActive(false);
			GameObject.Find ("hero").GetComponent<PlayerControl>().enableControls();
			break;
		case 1:
			//credits
			break;
		case 2:
			//exit
			Application.Quit();
			break;
		}
	}
}
