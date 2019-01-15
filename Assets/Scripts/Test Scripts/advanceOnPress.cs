//meaningless comment to make a change
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class advanceOnPress : MonoBehaviour {

    public Animator anim;
    public KeyCode advance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(advance))
            anim.SetTrigger("advance");
		
	}
}
