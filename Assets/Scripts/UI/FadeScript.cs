using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour {
	private bool isActive = false;
	private bool isDelay = false;
	private bool isFadding = false;
	private bool isloaded = false;
	private bool isFaddingOut = false;
	private float timeCounter;
	private int Delayduration = 10;
	private int Fadeduration = 2;
	private int LoadedDuration = 3;
	private int FadeToBlackDuration = 2;
	//ForestRef
	private GameObject GM;
	public Color colorStart;
	public Color colorMid;
	public Color colorEnd;
	public GameObject ParentRef;

	void Start () {
		//colorStart = renderer.material.color;
		//colorEnd = Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);
		//FadeOut ();
		isDelay = true;
		isActive = true;
	}

	void Update ()
	{
		if (isActive == true) 
		{
			timeCounter += Time.deltaTime;
			//Debug.Log (timeCounter);
			if (isDelay == true) 
			{
				if (timeCounter >= Delayduration) {
					//Debug.Log (" fade in done");
					isDelay = false;
					isFadding = true;
					timeCounter = 0;
				}
			}
				else if (isFadding == true) 
				{
					//timeCounter += Time.deltaTime;
					//timeCounter = Mathf.Floor(timeCounter);
				GetComponent<Image> ().color = Color.Lerp (colorStart, colorMid, timeCounter / Fadeduration);
				if (timeCounter >= Fadeduration) {
						Debug.Log (" fade in done");
						isFadding = false;
						isloaded = true;
						timeCounter = 0;
					}
				} 
					else if (isloaded == true) 
					{
						//timeCounter += Time.deltaTime;
						//timeCounter = Mathf.Floor(timeCounter);
						if (timeCounter >= LoadedDuration) 
						{
							Debug.Log (" duration done");
							isloaded = false;
							isFaddingOut = true;
							timeCounter = 0;
						}
					} 
						else if (isFaddingOut == true) 
						{
							//timeCounter += Time.deltaTime;
							//timeCounter = Mathf.Floor(timeCounter);
							GetComponent<Image> ().color = Color.Lerp (colorMid, colorEnd, timeCounter / FadeToBlackDuration);
							if (timeCounter >= FadeToBlackDuration) 
							{
								SceneManager.LoadScene ("Menu");
							}
						}
		}
	}

	public void turnonfading()
	{
		isFadding = true;
		isActive = true;
		//GameObject RaycastEnding;
	}
}
