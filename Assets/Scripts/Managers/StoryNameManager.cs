using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class exists so while developing, you can define which story the scene is part of
/// </summary>
public class StoryNameManager : Singleton<StoryNameManager>
{
    [Tooltip("The name of the story in the assetbundle")]
    public string storyName;
}
