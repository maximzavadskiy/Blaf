using UnityEngine;
using System.Collections;

public class IntroChanger : MonoBehaviour 
{
	public float timeToShowScreenInSeconds = 2f;
	public float initialTimeout = 0.5f;
	public Texture2D[] slides;
	public float fadeTime;
	private float fadeTimer = 0;
	private float screenChangeTimer = -1;
	private float slideAlpha = 0;

	public float maxAlpha = 0.5f;
	public float minAlpha = 0;
	private bool isFading = false;
	private bool fadesIn = true;
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
		Debug.Log ("isFading? " + Time.deltaTime);
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
					currentSlide++;
					if (currentSlide < slides.GetLength(0))
					{
						guiTexture.texture = slides[currentSlide];
					}
					else
					{
						Application.LoadLevel(1); //start with the first level
						return;
					}
					slideAlpha = 0f;
					screenChangeTimer = Time.realtimeSinceStartup;
					fadesIn = true;
				}
			}
			guiTexture.color = new Color(0.5f,0.5f,0.5f,slideAlpha);
		}
		if (currentSlide != -1)
		{
			Debug.Log ("show= " + (Time.realtimeSinceStartup - screenChangeTimer));
			if (Time.realtimeSinceStartup - screenChangeTimer > timeToShowScreenInSeconds)
			{
				fadesIn = false;
				isFading = true;
			}
		}
		else
		{
			if (Time.realtimeSinceStartup - screenChangeTimer > initialTimeout)
			{
				currentSlide++;
				if (currentSlide < slides.GetLength(0))
				{
					guiTexture.texture = slides[0];
				}
				else
				{
					Application.LoadLevel(1); //start with the first level
					return;
				}
				fadesIn = true;
				isFading = true;
			}
		}

	}
}
