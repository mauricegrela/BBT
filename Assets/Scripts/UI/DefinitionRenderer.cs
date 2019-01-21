using System.Collections;
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
	}

}
