using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SpeakerUIAssign : MonoBehaviour {

	public Sprite[] Speakers;

	public void ImageAssign(string FileName)
	{		
		foreach (Sprite image in Speakers) {			
			if (FileName == image.name) {
				//Debug.Log (FileName);
				GetComponent<Image> ().sprite = image;
			} 
		}
	}
}
