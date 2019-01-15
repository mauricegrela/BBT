using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicStaticMeshSystem : MonoBehaviour {


	public int AnimationDelayTracker = 0;
	//public int AnimationDelay;
	public int InstancesToActivate;
	public bool[] AnimationBool;
	public Vector3[] MeshPos;
	public Quaternion[] MeshRot;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(AnimationBool [AnimationDelayTracker]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveMeshForward()
	{
		AnimationDelayTracker++;
		Meshedit ();
	}

	public void MoveMeshBackward()
	{
		AnimationDelayTracker--;
		Meshedit ();
	}

	public void ResetToTheEnd()
	{
		AnimationDelayTracker = AnimationBool.Length - 1;
		Meshedit ();
	}

	void Meshedit()
	{
		/*
		gameObject.SetActive(AnimationBool [AnimationDelayTracker]);

		if (MeshPos [AnimationDelayTracker] != new Vector3 (0, 0, 0)) {
			transform.position = MeshPos [AnimationDelayTracker];
		}

		if (MeshRot [AnimationDelayTracker] != new Quaternion (0, 0, 0,0)) {
			transform.rotation = MeshRot [AnimationDelayTracker];
		}*/
	}

}
