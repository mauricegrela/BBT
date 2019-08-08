using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextPositionEditMode : MonoBehaviour {


    SentenceRowContainer sentenceRowContainer;
    bool shouldFollow;
    static string language;

    private void Awake()
    {
        shouldFollow = false;
    }

    void Update () 
    {
        if (shouldFollow&& sentenceRowContainer != null)
        {
            //if (gameObject.tag == "EnglishTextPosition")
            //{
            //    sentenceRowContainer.gameObject.transform.position = transform.position;
            //}

            //if (gameObject.tag == "FrenchTextPosition")
            //{
            //    sentenceRowContainer.gameObject.transform.position = transform.position;
            //}

            //if (gameObject.tag == "IndigenousTextPosition")
            //{
            //    sentenceRowContainer.gameObject.transform.position = transform.position;
            //}

            if (gameObject.tag == "EnglishTextPosition" && language == "english")
            {
                sentenceRowContainer.gameObject.transform.position = transform.position;
                print("follow eng");
            }

            if (gameObject.tag == "FrenchTextPosition" && language == "French")
            {
                sentenceRowContainer.gameObject.transform.position = transform.position;
            }

            if (gameObject.tag == "IndigenousTextPosition" && language == "Indigenous")
            {
                sentenceRowContainer.gameObject.transform.position = transform.position;
                print("follow ind");

            }

        }
    }

    public void SetTextToFollowThisObject(SentenceRowContainer _sentenceRowContainer, string _language)
    {
        //called from storymanager
        sentenceRowContainer = _sentenceRowContainer;
        language = _language;
        shouldFollow = true;
        print(_language + "_language");
    }
}
