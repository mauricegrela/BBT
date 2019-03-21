using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefinitionRenderer : MonoBehaviour {

	//This code will be called when the player pressed a word with a linked definition 
	
	public Text title;
	public Text TextTranslation;
	public Text TextBody;

	public Image RenderPlacement;
	public AudioSource audioEmitter;

	public string[] def_wordSas;
	public string[] def_wordSasFR;
	public string[] def_wordSasTranslation;
	public Sprite[] def_wordSasPhotos;
	public string[] def_BodySasEnglish;
    public string[] def_BodySasFrench;
	public AudioClip[] def_WordSas_Audio;  

	public string[] def_wordLilPpl;
    public string[] def_wordLilPplFR;
	public string[] def_wordLilPplTranslation;
	public Sprite[] def_wordLilPplPhotos;
	public string[] def_BodyLilPplEnglish;
    public string[] def_BodyLilPplFrench;
    public AudioClip[] def_WordLilPpl_Audio; 

    public string[] def_wordKal;
    public string[] def_wordKalFR;
    public string[] def_wordKalTranslation;
    public Sprite[] def_wordKalPhotos;
    public string[] def_BodyKalEnglish;
    public string[] def_BodyKalFrench;
    public AudioClip[] def_WordKal_Audio;

    private string RefWorld;
    private string RefWorldBody;
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

                if(DataManager.currentLanguage == "english")
                {
                RefWorld = def_wordSas[i].ToLower();
                RefWorldBody = def_BodySasEnglish[i];    
                }
                    else if (DataManager.currentLanguage == "french")
                    {
                        RefWorld = def_wordSas[i].ToLower();
                        RefWorldBody = def_BodySasEnglish[i];
                    }

                if (Definition.text.ToLower ().Equals (RefWorld)) 
                {
                    title.text = RefWorld;
					TextTranslation.text = def_wordSasTranslation [i];
					RenderPlacement.sprite = def_wordSasPhotos [i];
                    TextBody.text = RefWorldBody;
					audioEmitter.clip = def_WordSas_Audio [i];
				} 
			}
		}
            else if(DataManager.currentStoryName == "littlepeople") {
                for (int i = 0; i < def_wordLilPpl.Length; i++)
                {

                    if (DataManager.currentLanguage == "english")
                    {
                    RefWorld = def_wordLilPpl[i].ToLower();
                    RefWorldBody = def_BodyLilPplEnglish[i];
                    }
                        else if (DataManager.currentLanguage == "french")
                        {
                        RefWorld = def_wordLilPplFR[i].ToLower();
                        RefWorldBody = def_BodyLilPplFrench[i];
                        }
                Debug.Log(Definition.text.ToLower() + "//" + RefWorld);
                if (Definition.text.ToLower().Equals(RefWorld))
                {
                        title.text = RefWorld;
                        TextTranslation.text = def_wordLilPplTranslation[i];
                        RenderPlacement.sprite = def_wordLilPplPhotos[i];
                        TextBody.text = RefWorldBody;
                        audioEmitter.clip = def_WordLilPpl_Audio[i];
                        Debug.Log(Definition.text.ToLower());
                        //audioEmitter.Play ();
                    }
                }
            }
                else if(DataManager.currentStoryName == "kalkalilh") {
            for (int i = 0; i < def_wordKal.Length; i++)
            {

                if (DataManager.currentLanguage == "english")
                {
                    RefWorld = def_wordKal[i].ToLower();
                    RefWorldBody = def_BodyKalEnglish[i];
                }
                    else if (DataManager.currentLanguage == "french")
                    {
                    RefWorld = def_wordKalFR[i].ToLower();
                    RefWorldBody = def_BodyKalFrench[i];
                    }
                Debug.Log(Definition.text.ToLower()+"//"+RefWorld);
                if (Definition.text.ToLower().Equals(RefWorld))
                {
                title.text = RefWorld;
                TextTranslation.text = def_wordKalTranslation[i];
                RenderPlacement.sprite = def_wordKalPhotos[i];
                TextBody.text = RefWorldBody;
                audioEmitter.clip = def_WordKal_Audio[i];
                Debug.Log(Definition.text.ToLower());
                //audioEmitter.Play ();
                }
            }
        } 

	}

}
