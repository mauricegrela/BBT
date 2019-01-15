using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gotopage : MonoBehaviour {

	public void pageLoad ()
    {
        Debug.Log(gameObject.name);
        //PageManager.instance.GoToPage(pageTarget);
    }
    public void setPageTarget(int page)
    {
		Debug.Log("Working");
    }

	public void GoToChapter()
	{
		PageManager.instance.ChapterSkip (GetComponentInChildren<Text>().text);
		Debug.Log(GetComponentInChildren<Text>().text);
	}
}
