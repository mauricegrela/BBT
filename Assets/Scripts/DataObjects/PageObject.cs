using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageObject
{
    public string name;
    public List<AudioObject> audioObjects = new List<AudioObject>();

    public AudioObject GetAudio(string name)
    {
        foreach (AudioObject a in audioObjects)
        {
            if (a.name == name)
            {
                return a;
            }
        }
        return null;
    }

    public string[] GetAudioNames()
    {
        List<string> audioNames = new List<string>();
        foreach (AudioObject a in audioObjects)
        {
            audioNames.Add(a.name);
        }
        return audioNames.ToArray();
    }
}
