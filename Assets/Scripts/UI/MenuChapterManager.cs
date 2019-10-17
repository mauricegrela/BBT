using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuChapterManager : MonoBehaviour {


	public string[] ButtonDescription;
    public Text[] ButtonDescriptionText;

    public string[] Translations;

    public GameObject[] buttons;
    private StoryObject currentStory
    {
        get
        {
            return DataManager.currentStory;
        }
    }
    
    public GameObject ButtonTemplate;


    public void ReturnToMainMenu()
    {
        //DataManager.currentLanguage = "English";
        SceneManager.LoadSceneAsync("Menu");
    }

    public void FrenchStructure()
    {
        for (int i = 0; i <= ButtonDescriptionText.Length-1; i++)
        {
            ButtonDescriptionText[i].text = Translations[i];//.ToString();
			Debug.Log (ButtonDescriptionText[i].text);
        }
        buttons[0].GetComponent<Outline>().enabled = false;
        buttons[1].GetComponent<Outline>().enabled = true;
        //buttons[2].GetComponent<Outline>().enabled = false;
        //buttons[3].GetComponent<Outline>().enabled = true;
    }


        public void ChapterINI()
    {

                
    }

}
