using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class MakeFolders : ScriptableObject {

    
    //unmark next lines to run this script from editor:
//    [MenuItem ("Assets/Make Sasquatch Text Position prefabs Folders")]
//    static void MenuMakeFolders()
//    {
//        CreateFolders();
//    }

    static void CreateFolders()
    {
//        string f = Application.dataPath+"/" +"Stories/sasquatch/TextPositionsPrefabs/";

//        string[] guids1 = AssetDatabase.FindAssets("l:Sasquatch", null);
//
//        foreach (string guid1 in guids1)
//        {
////            Directory.CreateDirectory(f+ AssetDatabase.GUIDToAssetPath(guid1)+"/ TextPositionPrefabs");
//
//            Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
//        }

        
        string f = Application.dataPath+"/" +"Stories/sasquatch/TextPositionsPrefabs/";

//        for(int i=1;i<=6;i++)
//        {
//            Directory.CreateDirectory(f+ "S03-0"+i +" text positions prefabs");
//        }

        for(int i=1;i<=1;i++)
        {
            Directory.CreateDirectory(f+ "S04-0"+i +" text positions prefabs");
        }

        for(int i=4;i<=5;i++)
        {
            Directory.CreateDirectory(f+ "S04-0"+i +" text positions prefabs");
        }
        
        
        
        for(int i=1;i<=2;i++)
        {
            Directory.CreateDirectory(f+ "S05-0"+i +" text positions prefabs");
        }
        
        
        for(int i=1;i<=5;i++)
        {
            Directory.CreateDirectory(f+ "S06-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=6;i++)
        {
            Directory.CreateDirectory(f+ "S07-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=6;i++)
        {
            Directory.CreateDirectory(f+ "S08-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=3;i++)
        {
            Directory.CreateDirectory(f+ "S09-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=4;i++)
        {
            Directory.CreateDirectory(f+ "S10-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=1;i++)
        {
            Directory.CreateDirectory(f+ "S11-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=1;i++)
        {
            Directory.CreateDirectory(f+ "S12-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=3;i++)
        {
            Directory.CreateDirectory(f+ "S13-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=3;i++)
        {
            Directory.CreateDirectory(f+ "S14-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=1;i++)
        {
            Directory.CreateDirectory(f+ "S15-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=2;i++)
        {
            Directory.CreateDirectory(f+ "S16-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=2;i++)
        {
            Directory.CreateDirectory(f+ "S17-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=4;i++)
        {
            Directory.CreateDirectory(f+ "S18-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=3;i++)
        {
            Directory.CreateDirectory(f+ "S19-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=4;i++)
        {
            Directory.CreateDirectory(f+ "S20-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=3;i++)
        {
            Directory.CreateDirectory(f+ "S21-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=2;i++)
        {
            Directory.CreateDirectory(f+ "S22-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=2;i++)
        {
            Directory.CreateDirectory(f+ "S23-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=1;i++)
        {
            Directory.CreateDirectory(f+ "S24-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=1;i++)
        {
            Directory.CreateDirectory(f+ "S25-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=3;i++)
        {
            Directory.CreateDirectory(f+ "S26-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=2;i++)
        {
            Directory.CreateDirectory(f+ "S27-0"+i +" text positions prefabs");
        }
        
        for(int i=1;i<=6;i++)
        {
            Directory.CreateDirectory(f+ "S28-0"+i +" text positions prefabs");
        }
        
        Debug.Log("create directories");
    }
//
//    [MenuItem("Example/FindAssets Example")]
//    {
//        static void ExampleScript()
//        {
//            string[] sasquatch_scenes = AssetDatabase.FindAssets("l:Sasquatch", null);
//        }
//    }
}
