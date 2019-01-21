using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordText : MonoBehaviour
{
    internal Text text;
    internal RectTransform rt;

    public GameObject DefenitionPage;
    internal WordGroupObject wordGroup;

    // Use this for initialization
    void Awake()
    {
        rt = GetComponent<RectTransform>();
        text = GetComponent<Text>();

    }

    public void  DeployDefenitionPage()
    {
        //Debug.Log("Wokring");
        //GameObject DefenitionPage;
        DefenitionPage = GameObject.FindGameObjectWithTag("Canvas");//Find the story manager found in every level
        foreach (Transform child in DefenitionPage.transform)
        {  
            if (child.gameObject.CompareTag("DefinitionPage"))
            {

                child.gameObject.SetActive(true);
                child.gameObject.GetComponent<DefinitionRenderer>().SetUpText(GetComponent<Text>());
            }
                else
                {
                    //Debug.Log(child.gameObject.tag + "///" + "DefinitionPage");  
                }
        }
    }

}
