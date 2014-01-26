using UnityEngine;
using System.Collections;

public class OutroChanger : MonoBehaviour 
{
	public float timeToShowScreenInSeconds = 2f;
	public float initialTimeout = 0.5f;
	public Texture2D[] slides;
	public float fadeTime;
	private float fadeTimer = 0;
	private float screenChangeTimer = -1;
	private float slideAlpha = 0;
	private bool outroDone = false;
	public float maxAlpha = 0.5f;
	private bool allDone = false;
	public float minAlpha = 0;
	private bool doLastFadeOut = false;
	private bool isFading = false;
	private bool fadesIn = true;
	private bool canClick = false;
	int currentSlide = -1;
	public float timeStep;

	// Use this for initialization
	void Start () 
	{
		screenChangeTimer = Time.realtimeSinceStartup;
		isFading = false;
	}
	
	void Update () 
	{
		Debug.Log ("isFading? " + currentSlide + ", " + outroDone);
		if (allDone) 
		{
			Application.LoadLevel(1); //start with the first level
			return;
		}
		if (outroDone && !doLastFadeOut) return;

		if (isFading)
		{
			if (fadesIn)
			{
				slideAlpha = Mathf.Lerp(slideAlpha, maxAlpha, timeStep);
				if (slideAlpha >= maxAlpha*0.99f)
				{
					slideAlpha = maxAlpha;
					screenChangeTimer = Time.realtimeSinceStartup;
					isFading = false;
				}
			}
			else //fades out
			{
				slideAlpha = Mathf.Lerp(slideAlpha, 0, timeStep);
				if (slideAlpha <= 0.01f*maxAlpha)
				{
					allDone = true;
					return;
				}
			}
			guiTexture.color = new Color(0.5f,0.5f,0.5f,slideAlpha);
		}
		if (currentSlide == -1)
		{
			if (Time.realtimeSinceStartup - screenChangeTimer > initialTimeout)
			{
				currentSlide++;
				guiTexture.texture = slides[0];
				fadesIn = true;
				isFading = true;
			}
		}
		else if (Time.realtimeSinceStartup - screenChangeTimer > timeToShowScreenInSeconds)
			canClick = true;

	}
	void OnMouseDown()
	{
		Debug.Log ("mouseDown and Done");
		if (canClick)
		{
			fadesIn = false;
			isFading = true;
			doLastFadeOut = true;
		}
	}

}
