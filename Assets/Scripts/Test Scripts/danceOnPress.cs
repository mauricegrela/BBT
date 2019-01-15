using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danceOnPress : MonoBehaviour {

    public Animator anim;

    public KeyCode dance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(dance))
            anim.SetTrigger("Dance");
		
	}
}
