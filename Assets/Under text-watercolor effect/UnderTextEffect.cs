using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderTextEffect : MonoBehaviour {

    GameObject TextContainer;
	void Start () 
    {
        TextContainer = GameObject.FindGameObjectWithTag("TextPlacement");
        gameObject.transform.position = TextContainer.transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
