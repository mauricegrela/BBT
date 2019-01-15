using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGenerator : MonoBehaviour {

	public GameObject Dotref;
	public GameObject[] Dots;


	// Use this for initialization
	void Start () {
		Dots = new GameObject[2];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenrateTheDots(int buttons)
	{
		if (Dots [0] != null) {
			for (int i = 0; i <= Dots.Length-1; i++) 
			{
				//Debug.Log ("nuts");

					Destroy (Dots [i]);

			}
		}

		Dots = new GameObject[buttons];

		GameObject image; 
		for (int i = 0; i <= buttons-1; i++) {
			image = Instantiate(Dotref);
			image.transform.localScale = new Vector3 (1, 1, 1);
			image.transform.parent = gameObject.transform;
			Dots [i] = image;
		}
		Dots [0].transform.localScale = new Vector3 (1, 1, 1);
		//Dotref.SetActive (false);
	}

	public void updateDots(int AnimToTurnOn)
	{

		for (int i = 0; i  <= Dots.Length-1; i++) 
		{
			if (i == AnimToTurnOn) {
				Dots [i].transform.localScale = new Vector3 (1, 1, 1);
			} else {
				Dots [i].transform.localScale = new Vector3 (0.78125f, 0.78125f, 0.78125f);
			}
		}

	}
}
