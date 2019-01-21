using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordText : MonoBehaviour
{
    internal Text text;
    internal RectTransform rt;


    internal WordGroupObject wordGroup;

    // Use this for initialization
    void Awake()
    {
        rt = GetComponent<RectTransform>();
        text = GetComponent<Text>();

    }

    public void  DeployDefenitionPage()
    {
        Debug.Log("Wokring");
        GameObject DefenitionPage;
        DefenitionPage = GameObject.FindGameObjectWithTag("StoryManager");//Find the story manager found in every level
        DefenitionPage.SetActive(false);
    }

}
