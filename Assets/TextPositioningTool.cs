//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public enum Languages { English, French, Indigenous}
//public class TextPositioningTool : MonoBehaviour {

//    public Languages CurrentLanguege;

//    public int sentenceContainerCounter;
//    public int sentenceContainerCurrent = 0;
//    public SentenceRowContainer[] sentenceContainer;

//    public void ButtonClicked()
//    {
//        //PageManagerRef.GetComponent<PageManager>().ChangeLanguage(Language);
//        StopAllCoroutines();
//        //audioSource.Stop();
//        Resources.UnloadUnusedAssets();
//        sentenceContainerCounter = 0;
//        sentenceContainerCurrent = 0;

//        sentenceContainer = GetComponentsInChildren<SentenceRowContainer>();
//        foreach (SentenceRowContainer Child in sentenceContainer)
//        {
//            if (Child != null)
//                Child.Clear();
//        }
//        //Debug.Log(newLanguage);

//        DataManager.currentLanguage = CurrentLanguege.ToString();
//        //DataManager.LoadStory(DataManager.currentStoryName, DataManager.CurrentAssetPackage);


//        //PreviousSentence (true);
//        //AudioObject currentAudio = currentPage.audioObjects[audioIndex];

//        //WordGroupParser();

//        //StartCoroutine(RunSequence(currentAudio));
//        //Debug.Log(audioIndex + "/" + pageIndex);
//        //Scenetext.GetComponent<Text> ().text =currentAudio.name;
//    }

//    public void WordGroupParser()
//    {

//        //Debug.Log(currentPage.audioObjects[audioIndex].sentence.wordGroups.ToString());

//        //foreach (WordGroupObject wordGroup in currentPage.audioObjects[audioIndex].sentence.wordGroups)
//        //{


//        //    //Debug.Log(wordGroup.text);
//        //    if (wordGroup.text.Contains("speaker"))
//        //    {//Get The Narrator
//        //        //Speaker = wordGroup.text;
//        //        //Speaker = Speaker.Remove(0, 10);
//        //        //Debug.Log(Speaker);
//        //    }
//        //    else if (wordGroup.text.Contains("///"))
//        //    {//Get The Narrator

//        //        sentenceContainerCurrent += 1;
//        //        /*
//        //        if (sentenceContainer[sentenceContainerCurrent].GetComponentInParent<SpeechBubbleDelay>())
//        //        {
//        //            sentenceContainer[sentenceContainerCurrent].GetComponentInParent<SpeechBubbleDelay>().Acvivate_SpeechBuggle(PreviousWordTime);
//        //        }*/
//        //    }
//        //    else
//        //    {
//        //        // PreviousWordTime = wordGroup.time;
//        //        sentenceContainer[sentenceContainerCurrent].AddText(wordGroup);
//        //    }
//        //}
//    }
//}

