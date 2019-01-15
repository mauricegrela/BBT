using System.Collections;
using UnityEngine;

public class lightEnable : MonoBehaviour 

{

	private Light myLight;

	void start() 
	{
		myLight = GetComponent<Light> ();
	}

	void OnMouseDown ()
	{
		myLight.enabled = !myLight.enabled ;
	}
}
