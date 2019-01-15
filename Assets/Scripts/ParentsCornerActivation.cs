using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ParentsCornerActivation : MonoBehaviour {


    public string[] BootColNames;
    public string[] FrenchBootColNames;
    public Sprite[] BootCols;
    public Image BootImg;
    public InputField InputRef;
    public GameObject[] Locks;
    public Image[] IMGRef;
    public Color Unlocked;
    public GameObject Unlock;
    public GameObject ParentsCorner;
    private int CorrectAnswerIndex;

	// Use this for initialization
	void Start () {
        //SetNewImage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNewImage()
    {
        Debug.Log("Setting New Image");
        CorrectAnswerIndex = Random.Range(0, BootColNames.Length );
        Debug.Log(BootColNames[CorrectAnswerIndex]);
        BootImg.sprite = BootCols[CorrectAnswerIndex];

    }


    public void CheckIfAnswerRight(string Answer)
    {
        Debug.Log(InputRef.text.ToLower() +"///////"+ BootColNames[CorrectAnswerIndex]);


        if(InputRef.text.ToLower() == BootColNames[CorrectAnswerIndex]||InputRef.text.ToLower() == FrenchBootColNames[CorrectAnswerIndex])
        {//If the correct answer is input
            gameObject.SetActive(false);
            UnlockGame();
            /*for (int i = 0; i <= Locks.Length - 1; i++)
            {
                Locks[i].SetActive(false);

            }

            for (int i = 0; i <= IMGRef.Length - 1; i++)
            {
                IMGRef[i].color = Unlocked;
            }*/
//            Unlock.GetComponent<MyIAPManager>().BuyNonConsumable();
        }
    }

    public void UnlockGame()
    {
        ParentsCorner.SetActive(true);
        /*gameObject.SetActive(false);
        for (int i = 0; i <= Locks.Length - 1; i++)
        {
            Locks[i].SetActive(false);

        }

        for (int i = 0; i <= IMGRef.Length - 1; i++)
        {
            IMGRef[i].color = Unlocked;
        }*/
        //Unlock.GetComponent<MyIAPManager>().BuyNonConsumable();
    }
    public void redirect()
    {
        if(DataManager.currentLanguage == "English")
        {
            Application.OpenURL("http://asc-csa.gc.ca/eng/missions/expedition58-59");    
        }
            else
            {
            Application.OpenURL("http://asc-csa.gc.ca/fra/missions/expedition58-59");      
            }
            
    }
}
