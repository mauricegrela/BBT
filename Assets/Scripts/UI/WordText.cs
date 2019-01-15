using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordText : MonoBehaviour
{
    internal Text text;
    internal RectTransform rt;


    internal WordGroupObject wordGroup;

    // Use this for initialization
    void Awake()
    {
        rt = GetComponent<RectTransform>();
        text = GetComponent<Text>();

    }
	

}
