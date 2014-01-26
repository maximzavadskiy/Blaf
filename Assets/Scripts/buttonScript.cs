using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour 
{
	public Texture2D hilight;
	public Texture2D normal;
	public int buttonId; 
	int timer;
	// Use this for initialization
	void Start () 
	{
	
	}

	void OnGUI()
	{
		GUI.depth = 1;
	}

	void Update()
	{
	//	Debug.Log("udpate");
		if (timer > 0)
		{
			if (--timer <= 0)
				guiTexture.texture = normal;
		}
	}

	// Update is called once per frame
	void OnMouseDown()
	{
		Debug.Log ("buttonDown: " + buttonId);
		guiTexture.texture = hilight;
		transform.root.FindChild ("menuDimmer").GetComponent<MenuScript3>().StartAction(buttonId);
		timer = 15;
	}
}
