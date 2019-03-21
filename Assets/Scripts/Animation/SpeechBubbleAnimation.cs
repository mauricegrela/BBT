using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleAnimation : MonoBehaviour {

    public float letterPause = 1;
    public AudioClip typeSound1;
    public AudioClip typeSound2;
    string message;
    Text textComp;

  	//This code will create a fill out animation on the text of the component its attached to 
	
    public void setActive()
    {
        GetComponentInChildren<Image>().enabled = true;
        GetComponentInChildren<Text>().enabled = true;
        textComp = GetComponentInChildren<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(0.000000000002f);
        }
    }
}
