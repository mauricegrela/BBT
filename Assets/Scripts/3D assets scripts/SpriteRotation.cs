﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
        /*target = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
