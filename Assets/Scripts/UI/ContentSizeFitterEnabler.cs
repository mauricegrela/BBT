using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script exists because in the editor the ContentSizeFitters are disabled. This is because otherwise Unity keeps marking the scene as modified.
/// </summary>
[RequireComponent(typeof(ContentSizeFitter))]
public class ContentSizeFitterEnabler : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        GetComponent<ContentSizeFitter>().enabled = true;
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }
}
