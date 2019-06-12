using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextPositionEditMode : MonoBehaviour {


    SentenceRowContainer sentenceRowContainer;
    bool shouldFollow;

    private void Awake()
    {
        shouldFollow = false;
    }

    void Update () 
    {
        if (shouldFollow&& sentenceRowContainer != null)
        {
            if (gameObject.tag == "EnglishTextPosition")
            {
                sentenceRowContainer.gameObject.transform.position = transform.position;
            }

            if (gameObject.tag == "FrenchTextPosition")
            {
                sentenceRowContainer.gameObject.transform.position = transform.position;
            }

            if (gameObject.tag == "IndigenousTextPosition")
            {
                sentenceRowContainer.gameObject.transform.position = transform.position;
            }
        }
    }

    public void SetTextToFollowThisObject(SentenceRowContainer _sentenceRowContainer)
    {
        //called from storymanager
        sentenceRowContainer = _sentenceRowContainer;
        shouldFollow = true;
    }
}
