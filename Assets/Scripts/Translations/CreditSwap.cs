using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSwap : MonoBehaviour {

	public GameObject En_Credits;
	public GameObject Fr_Credits;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreditTranslationSwap()
	{
		if(DataManager.currentLanguage == "French")
		{
			En_Credits.SetActive(false);
			Fr_Credits.SetActive(true);
		}
		else
		{
			Fr_Credits.SetActive(false);
			En_Credits.SetActive(true);
		}
	}
}
