﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefinitionRenderer : MonoBehaviour {

	public Text title;
	public Text TextTranslation;
	public Text TextBody;


	public Image RenderPlacement;
	public AudioSource audioEmitter;

	public string[] def_wordSas;
	public string[] def_wordSasTranslation;
	public Sprite [] def_wordSasPhotos;
	public string[] def_BodySasEnglish;
	public AudioClip[] def_WordSas_Audio;  

	public string[] def_wordLilPpl;
	public string[] def_wordLilPplTranslation;
	public Sprite [] def_wordLilPplPhotos;
	public string[] def_BodyLilPplEnglish;
    public AudioClip[] def_WordLil_Audio; 

    public string[] def_wordKal;
    public string[] def_wordKalTranslation;
    public Sprite [] def_wordKalPhotos;
    public string[] def_BodyKalEnglish;
    public AudioClip[] def_WordKal_Audio; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetUpText (Text Definition) 
	{
		if (DataManager.currentStoryName == "sasquatch") {
			for (int i = 0; i < def_wordSas.Length; i++) {

                Debug.Log(Definition.text.ToLower()+"\\\\"+def_wordSas[i].ToLower());

				if (Definition.text.ToLower ().Equals (def_wordSas [i].ToLower ())) {
					title.text = def_wordSas [i];
					TextTranslation.text = def_wordSasTranslation [i];
					RenderPlacement.sprite = def_wordSasPhotos [i];
					TextBody.text = def_BodySasEnglish [i];
					audioEmitter.clip = def_WordSas_Audio [i];
                    Debug.Log(Definition.text.ToLower());
					//audioEmitter.Play ();
				} 
			}
		}
            else if(DataManager.currentStoryName == "littlepeople") {
                for (int i = 0; i < def_wordLilPpl.Length; i++)
                {

                    Debug.Log(Definition.text.ToLower() + "\\\\" + def_wordLilPpl[i].ToLower());

                    if (Definition.text.ToLower().Equals(def_wordLilPpl[i].ToLower()))
                    {
                        title.text = def_wordLilPpl[i];
                        TextTranslation.text = def_wordLilPplTranslation[i];
                        RenderPlacement.sprite = def_wordLilPplPhotos[i];
                        TextBody.text = def_BodyLilPplEnglish[i];
                        audioEmitter.clip = def_WordLilPpl_Audio[i];
                        Debug.Log(Definition.text.ToLower());
                        //audioEmitter.Play ();
                    }
                }
            }
                else if(DataManager.currentStoryName == "kalkalilh") {
            for (int i = 0; i < def_wordKal.Length; i++)
                    {

                Debug.Log(Definition.text.ToLower() + "\\\\" + def_wordKal[i].ToLower());

                if (Definition.text.ToLower().Equals(def_wordKal[i].ToLower()))
                        {
                            title.text = def_wordKal[i];
                            TextTranslation.text = def_wordKalTranslation[i];
                            RenderPlacement.sprite = def_wordKalPhotos[i];
                            TextBody.text = def_BodyKalEnglish[i];
                            audioEmitter.clip = def_WordKal_Audio[i];
                            Debug.Log(Definition.text.ToLower());
                            //audioEmitter.Play ();
                        }
                    }
                } 

	}

}
