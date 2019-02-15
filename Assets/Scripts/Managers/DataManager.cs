using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Reflection.Emit;

public class DataManager
{
    public static string currentLanguage = "english";
    public static string currentStoryName = "littlepeople";
    public static bool isINISet = false;
    public static StoryObject currentStory;
    public static string[] languageManager;
	public static string[] SceneRef;
	public static int NarrativeCounter = 0;
	public static string CurrentAssetPackage;
	private static AssetBundle myLoadedAssetBundle;


	public static StoryObject LoadStory(string storyName, string packageToLoad)
    {
        UnloadAssetBundle();

		//Debug.Log (CombinePaths(Application.streamingAssetsPath, storyName, currentLanguage.ToLower() + "_" + packageToLoad.ToString()));


        myLoadedAssetBundle = AssetBundle.LoadFromFile(CombinePaths(Application.streamingAssetsPath, storyName, currentLanguage.ToLower() + "_" + packageToLoad.ToString())); 
     
       /*#if UNITY_IPHONE
        myLoadedAssetBundle = AssetBundle.LoadFromFile(CombinePaths(Application.streamingAssetsPath, storyName, currentLanguage.ToLower() + "_" + packageToLoad.ToString())); 
         #endif
         #if UNITY_ANDROID
        myLoadedAssetBundle = AssetBundle.LoadFromFile(CombinePaths(Application.streamingAssetsPath, storyName, currentLanguage.ToLower() + "_" + packageToLoad.ToString())); 
         #endif*/

 		

		CurrentAssetPackage = packageToLoad.ToString ();

		//AssetStreamingCounter++;
        //Debug.Log (CombinePaths(Application.streamingAssetsPath, storyName, currentLanguage.ToLower() + "_" + packageToLoad.ToString()));
			
        if (myLoadedAssetBundle == null)
        {
            //Debug.LogErrorFormat("Failed to load {0} assetbundle from story {1}", currentLanguage.ToLower(), storyName);
            return null;
        }

        StoryObject story = new StoryObject();

        string[] files = myLoadedAssetBundle.GetAllAssetNames();

		foreach (string file in files)
        {
            AddFileToStory(story, file); 
            Debug.Log (story+"//"+ file);
        }
        //Debug.Log(files.Length);
        UnloadAssetBundle();
        currentStory = story;
        return currentStory;

       
    }
		


    void OnDestroy()
    {
        UnloadAssetBundle();
    }

    //We have to unload our asset, since we can't load it twice
    public static void UnloadAssetBundle()
    {
        if (myLoadedAssetBundle != null)
        {
            myLoadedAssetBundle.Unload(false);

            myLoadedAssetBundle = null;
        }
    }

    private static void AddFileToStory(StoryObject story, string file)
    {
		

        int pathDepth = 2;
        string[] splitPath = file.Split('/');

        for (int i = 0; i < splitPath.Length; i++)
        {
			Debug.Log (splitPath[i]);
            if (splitPath[i] == currentStoryName)
            {
                if (i + pathDepth + 2 >= splitPath.Length)
                {
                    Debug.LogWarningFormat("Can't add file to story {0}", file);
                    return;
                }
                string pageName = splitPath[i + pathDepth + 1];
                //Get the page from the story
                PageObject page = story.GetPage(pageName);
				//Debug.Log (pageName);
				//page = null;
                //If the page wasn't in the story yet, create a new object
                if (page == null)
                {
                    page = new PageObject()
                    {
                        name = pageName
                    };
                    story.pageObjects.Add(page);  
                }

                //Get the audio from the page. The name is actually the foldername, not the file name of the audio
                string audioName = splitPath[i + pathDepth + 2];

                Debug.Log(audioName);
                //If the audio doesn't exist, craete a new one
                AudioObject audioObj = page.GetAudio(audioName);
                if (audioObj == null)
                {
                    audioObj = new AudioObject()
                    {
                        name = audioName
                    };
                    page.audioObjects.Add(audioObj);
                }

                Object fileObj = myLoadedAssetBundle.LoadAsset(file);
                AudioClip clip = fileObj as AudioClip;
                if (clip != null)
                {
                    audioObj.clip = clip;
                    return;
                }

                TextAsset txt = fileObj as TextAsset;

                if (txt != null)
                {
                    audioObj.sentence = GetSentence(txt.text);
                    return;
                }

                Debug.LogErrorFormat("File of type {0} detected inside the AssetBundle. It only supports AudioClips and TextAssets!", fileObj.GetType());

                return;
            }
        }

        //Debug.Log("Done");
    }

    private static SentenceObject GetSentence(string dataString)
    {
        SentenceObject so = new SentenceObject();
        string[] lines = Regex.Split(dataString, "\\n");
		//Debug.Log ("words.Length"+lines.Length);
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
                continue;
            
            string[] words = Regex.Split(line, "\\t");
            WordGroupObject obj = new WordGroupObject();
            float.TryParse(words[0], out obj.time);
            //This is index 1 or 2 (dependend if the time is defined twice or not)
            obj.text = words[words.Length - 1];
            so.wordGroups.Add(obj);
			//Debug.Log (line);
        }
        return so;
        //return JsonUtility.FromJson<SentenceObject>(dataString);
    }

    static string CombinePaths(params string[] paths)
    {
        if (paths == null)
        {
            return null;
        }
        string currentPath = paths[0];
        for (int i = 1; i < paths.Length; i++)
        {
            currentPath = Path.Combine(currentPath, paths[i]);
        }
        return currentPath;
    }
}
