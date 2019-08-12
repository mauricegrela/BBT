using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuLanguageChange : MonoBehaviour {

    public GameObject PageManagerRef;
    public Color ButtonClickedColor;
    public Color ButtonDefualtColor;
    public Image[] LanguageButtonImages;
    public GameObject mainmenu_bg;

    bool defulteLanguageColorWasSet;
    //public Dropdown dropdownMenu;

    //public GameObject[] ChapterButtonGroup;

    //public string[] SasquatchChapters;

    //public string[] LittlePeopleChapters;

    // Use this for initialization
    void Start() {
		/*
		SasquatchChapters = new string[5];
		SasquatchChapters [0] = "1_11_sas_ext_cabin";
		SasquatchChapters [1] = "12_21_sas_ext_forest";
		SasquatchChapters [2] = "22_26_sas_ext_clearing";
		SasquatchChapters [3] = "27_32_sas_ext_beach";
		SasquatchChapters [4] = "33_57_sas_ext_beachclearing";

		LittlePeopleChapters = new string[5];
		LittlePeopleChapters [0] = "Littlepeople_start";
		LittlePeopleChapters [1] = "Littlepeople_S13_01";
		LittlePeopleChapters [2] = "Littlepeople_S19_03";
		LittlePeopleChapters [3] = "Littlepeople_S28_01-S29_04";
		LittlePeopleChapters [4] = "Littlepeople_S30_01-S38_02";

		Debug.Log (DataManager.currentStoryName);

		for (int ButtonCounter = 0; ButtonCounter < ChapterButtonGroup.Length; ButtonCounter++) {

			if (DataManager.currentStoryName == "sasquatch") {
				ChapterButtonGroup [ButtonCounter].GetComponentInChildren<Text> ().text = SasquatchChapters [ButtonCounter];

			} else if (DataManager.currentStoryName == "littlepeople") {
				ChapterButtonGroup [ButtonCounter].GetComponentInChildren<Text> ().text = LittlePeopleChapters[ButtonCounter];
			}

		}


        //TODO:Create a system which will allow players to change languages on the fly
        dropdownMenu = GetComponent<Dropdown>();
        for (int languageCount = 0; languageCount < DataManager.languageManager.Length; languageCount++)
        {
            dropdownMenu.options.Add(new Dropdown.OptionData() { text = DataManager.languageManager[languageCount] });
            //dropdownMenu.options[languageCount].text = "test";
            // dropdownMenu.value = languageCount;
            //dropdownMenu.value = languageCount;
            //dropdownMenu.options.Add(new Dropdown.OptionData(dropdownMenu.options[languageCount].text));
        }
		*/

        if(!defulteLanguageColorWasSet)
        {
            LanguageButtonImages[0].color = ButtonClickedColor;
            defulteLanguageColorWasSet = true;
        }
    }


	public void LanguageUpdate(string Language)
    {
        UpdateLanguageButtonsColors(Language);

        //Debug.Log(GetComponentInChildren<Text>().text);
        StartCoroutine(WaitForEndOfFrame(Language));
    }

    void UpdateLanguageButtonsColors(string Language)
    {
        for(int i=0;i< LanguageButtonImages.Length;i++)
        {
            LanguageButtonImages[i].color = ButtonDefualtColor;
        }

        if(Language== "English")
        {
            LanguageButtonImages[0].color = ButtonClickedColor;
        }

        if (Language == "French")
        {
            LanguageButtonImages[1].color = ButtonClickedColor;
        }

        if (Language == "Indigenous")
        {
            LanguageButtonImages[2].color = ButtonClickedColor;
        }

        if(Language == "Spanish")
        {
            LanguageButtonImages[3].color = ButtonClickedColor;

        }
    }

    IEnumerator WaitForEndOfFrame(string Language)
    {
        yield return (new WaitForEndOfFrame());
        print(Language + "Language");
        PageManagerRef.GetComponent<PageManager>().ChangeLanguage(Language);
        mainmenu_bg.SetActive(false);
    }
}
