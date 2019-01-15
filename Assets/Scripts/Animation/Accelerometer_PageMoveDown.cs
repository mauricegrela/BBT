using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer_PageMoveDown : MonoBehaviour {

    private bool IsMovingDown = false;
    private Vector3 OGPose;
	// Use this for initialization
	void Start () {
        OGPose = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if(IsMovingDown)
        {
            transform.Translate(Vector3.down* (Time.deltaTime*5));

        }
	}

    public void StartPushDown()
    {
        IsMovingDown = true;
        Debug.Log("Working");
    }

    public void Reset()
    {
        IsMovingDown = false;
        transform.localPosition = OGPose;
        Debug.Log("Working");
    }
}
