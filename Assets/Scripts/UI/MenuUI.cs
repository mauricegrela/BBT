using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Dropdown languageDropdown;
    public Dropdown storyDropdown;

    //TODO Dry this code up

    public Sprite[] FrenchTransAssetsINI;

    public Image[] AssetsINIRef;
    // In this example we show how to invoke a coroutine and
    // continue executing the function in parallel.

    private IEnumerator coroutine;

	public GameObject English_Button;
	public GameObject French_Button;

	public Vector3 English_Button_Pos;
	public Vector3 French_Button_Pos;

    void Awake()
    {
		English_Button_Pos = English_Button.transform.position;
		French_Button_Pos = French_Button.transform.position;


		if (DataManager.isINISet == true) {
			if (DataManager.currentLanguage == "French") {
				English_Button.transform.position = French_Button_Pos;
				French_Button.transform.position = English_Button_Pos;
			} else {
				English_Button.transform.position = English_Button_Pos;
				French_Button.transform.position =  French_Button_Pos;
			}
		}

        //This checks if your computer's operating system is in the French language
        if (Application.systemLanguage == SystemLanguage.English && DataManager.isINISet == false)
        {
            DataManager.currentLanguage = "english";
            DataManager.isINISet = true;
        }
        //Otherwise, if the system is English, output the message in the console
        else if (Application.systemLanguage == SystemLanguage.French && DataManager.isINISet == false)
        {

			English_Button.transform.position = French_Button_Pos;
			French_Button.transform.position = English_Button_Pos;
            DataManager.currentLanguage = "French";
            DataManager.isINISet = true;
            AssetsINIRef[0].sprite = FrenchTransAssetsINI[0];
            AssetsINIRef[1].sprite = FrenchTransAssetsINI[1];
        }




    }

    public void StartGame(string LeveltoLoad)
    {
        Debug.Log(LeveltoLoad);
        DataManager.currentStoryName = LeveltoLoad;
        if(LeveltoLoad== "sasquatch")
        {
        SceneManager.LoadScene("S01-01");    
        }

        if (LeveltoLoad == "littlepeople")
        {
            SceneManager.LoadScene("lp01-01");
        }

        if (LeveltoLoad == "kalkalilh")
        {
            SceneManager.LoadScene("kk01-01");
        }

    }

    public void LoadNewLanguage(string LeveltoLoad)
    {
        DataManager.currentLanguage = LeveltoLoad;
        SceneManager.LoadScene("Menu");

    }


    public void SkyboxTest()
    {
        //Debug.Log("Working");
        SceneManager.LoadScene("Accelerometer_Test");
    }
  
    public void GoToMenu()
    {
        //Debug.Log("Working");
        SceneManager.LoadScene("Menu");
    }
  

}
