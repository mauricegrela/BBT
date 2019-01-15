using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.CodeDom.Compiler;

[System.Serializable]
public class StoryObject
{
    public List<PageObject> pageObjects = new List<PageObject>();

    public PageObject GetPage(string name)
    {
        foreach (PageObject p in pageObjects)
        {
            if (p.name == name)
            {
                return p;
            }
        }
        return null;
    }

    public string[] GetPageNames()
    {
        List<string> pageNames = new List<string>();
        foreach (PageObject p in pageObjects)
        {
            pageNames.Add(p.name);
        }
        return pageNames.ToArray();
    }
}
