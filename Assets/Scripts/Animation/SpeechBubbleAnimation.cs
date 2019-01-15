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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setActive()
    {
        GetComponentInChildren<Image>().enabled = true;
        GetComponentInChildren<Text>().enabled = true;
        textComp = GetComponentInChildren<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
        //Debug.Log("Working");
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            //if (typeSound1 && typeSound2)
                //SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            yield return 0;
            yield return new WaitForSeconds(0.000000000002f);
        }
    }
}
