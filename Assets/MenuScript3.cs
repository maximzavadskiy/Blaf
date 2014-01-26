using UnityEngine;
using System.Collections;

public class MenuScript3 : MonoBehaviour 
{
	public string[] membersString;
	bool isCredits = false;
	public GameObject play;
	public GameObject credits;
	public GameObject members;
	public GameObject header;
	public GameObject logo;
	// Use this for initialization
	void Awake()
	{
		//GameObject.Find ("Recording").SetActive(false);
	}
	void Start () 
	{
		Debug.Log("level: " + Application.loadedLevelName);
		header.SetActive(false);
		members.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if (isCredits)
			leaveCredits ();
	}

	void leaveCredits()
	{
		isCredits = false;
		credits.SetActive(true);
		play.SetActive(true);
		header.SetActive(false);
		members.SetActive(false);
	}

	void goToCredits()
	{
		isCredits = true;
		credits.SetActive(false);
		play.SetActive(false);
		header.SetActive(true);
		Color col = new Color(1,1,1,1);
		header.guiText.color = col;
		members.guiText.color = col;
		string comboString = "";
		for (int i = 0; i < membersString.GetLength(0); i++)
		{
			comboString += membersString[i] + '\n';
		}
		members.guiText.text = comboString;
		members.SetActive(true);
	}

	public void StartAction(int id)
	{
		switch(id)
		{
		case 0: 
			//play
			logo.SetActive(false);
			transform.root.gameObject.SetActive(false);
			GameObject.Find ("hero").GetComponent<PlayerControl>().enableControls();
			break;
		case 1:
			goToCredits();
			break;
		case 2:
			//exit
			Application.Quit();
			break;
		}
	}
}
