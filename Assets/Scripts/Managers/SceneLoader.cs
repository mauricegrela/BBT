using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //The scenes that get added to the MainStory scene, are the currentStoryName + these paths.
    //We need to call our scenes EXACTLY this, in order for this system to work.
    //The reason to have multiple scenes, is that now people can work on their own scene, without interfering with other peoples work
    string[] scenePaths = new string[]
    {
		"_environments"//,
        //"_environments"
    };

    void Awake()
    {
        LoadScenes();
    }

    void LoadScenes()
    {
        foreach (string scenePath in scenePaths)
        {
            string sceneName = "Chapter_1";//DataManager.currentStoryName+"_start";
			//Debug.Log (sceneName);
            Scene s = SceneManager.GetSceneByName(sceneName);
                
            if (!s.isLoaded)
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
	
}
