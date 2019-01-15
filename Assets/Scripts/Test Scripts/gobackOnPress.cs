//meaningless comment to make a change
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gobackOnPress : MonoBehaviour {

    public Animator anim;
    public KeyCode goback;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(goback))
            anim.SetTrigger("goback");
		
	}
}
