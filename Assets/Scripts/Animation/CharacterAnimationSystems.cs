using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterAnimationSystems : MonoBehaviour
{

	public int AnimationDelayTracker = 0;
	//public int AnimationDelay;
	public int InstancesToActivate;
    [SerializeField]
    private bool[] AnimationBool;
    [SerializeField]
    private Vector3[] CamPos;
	public string LastAnimation;
	// Use this for initialization

	void Start () {
		setUpCharacters (AnimationDelayTracker);
	}

	public void setUpCharacters(int trackerPosition)
	{
		
		AnimationDelayTracker = trackerPosition;


		if (GetComponent<Camera> () != null) 
		{//if I have a camera turn it on
			gameObject.GetComponent<Camera>().enabled = AnimationBool [AnimationDelayTracker];
		} 
		else if (GetComponent<Image> () != null) 
		{//if I'm part of a slide show, turn me on
			GetComponent<Image> ().enabled = AnimationBool [AnimationDelayTracker];
		} 
		else
		{//if I'm a static mesh, enable that
			GetComponent<Animator> ().enabled = AnimationBool [AnimationDelayTracker];
			foreach (Transform child in transform) 
			{//Turn on each of the skinned renderers
				if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
					child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = AnimationBool [AnimationDelayTracker];
			}
		}

		/*if (AnimationBool [AnimationDelayTracker] == true) 
		{			
			if (GetComponent<Camera> () != null) 
			{//if I have a camera turn it on
			gameObject.GetComponent<Camera>().enabled = true;
			} 
				else if (GetComponent<Image> () != null) 
				{//if I'm part of a slide show, turn me on
				GetComponent<Image> ().enabled = true;
				} 
					else
					{//if I'm a static mesh, enable that
					GetComponent<Animator> ().enabled = true;
						foreach (Transform child in transform) 
						{//Turn on each of the skinned renderers
						if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
						child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = true;
						}
					}
			

		} else {

			if (GetComponent<Camera> () != null) 
			{//if I have a camera, turn it off
			gameObject.GetComponent<Camera>().enabled = false;
			} 
				else if (GetComponent<Image> () != null) 
				{//if I'm part of a slide show, turn me off
				GetComponent<Image> ().enabled = false;
				} 
					else 
					{//if I'm a static mesh, enable that
					GetComponent<Animator> ().enabled = false;
						foreach (Transform child in transform) 
						{//Turn on each of the skinned renderers
							if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
							child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = false;
						}
					}

		}*/
	}

	public void InvokeNextAnimation (string AnimToSet)
	{	
		if (AnimationDelayTracker < AnimationBool.Length-1) 
		{
			AnimationDelayTracker++;
            ///Debug.Log(AnimToSet);
			if (AnimationBool [AnimationDelayTracker] == true) 
			{
				if (GetComponent<Camera> () != null) 
				{//if the thing to check has a camera.
					//gameObject.SetActive (true);
					//Debug.Log (AnimationDelayTracker +"///"+InstancesToActivate);
					if (GetComponent<CameraShake> () != null && AnimationDelayTracker == InstancesToActivate) 
					{
					GetComponent<CameraShake> ().activate ();
					//Debug.Log ("camera shakes");
					}
				gameObject.GetComponent<Camera> ().enabled = true;

					if (GetComponent<Animator> () != null) 
					{
                        //GetComponent<Animator> ().SetTrigger ("advance");

					GetComponent<Animator>().Play(AnimToSet, -1, 0f);
					}

					/*if(CamPos [AnimationDelayTracker] != new Vector3(0,0,0) && AnimationDelayTracker <=CamPos.Length-1)
					{gameObject.transform.position = CamPos [AnimationDelayTracker];}*/

				} 
					else{//Turn on the renderer

							if (GetComponent<Image> () != null) {
								GetComponent<Image> ().enabled = true;
							} else {

								GetComponent<Animator> ().enabled = true;
								foreach (Transform child in transform) {
									if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
										child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = true;
								}
								//Debug.Log(gameObject.name+"runing anim");
								//GetComponent<Animator> ().SetTrigger ("advance");
								GetComponent<Animator>().Play(AnimToSet, -1, 0f);
							}
						}

			} else {

				if (GetComponent<Camera> () != null) 
				{//if the thing to check has a camera.
					//Debug.Log(gameObject.name+"turn off");
					//gameObject.SetActive (false);
					gameObject.GetComponent<Camera> ().enabled = false;
				} else {//Turn off the renderer

					if (GetComponent<Image> () != null) 
					{
					GetComponent<Image> ().enabled = false;
					} 
					else 
					{
						gameObject.GetComponent<Animator> ().enabled = false;
							foreach (Transform child in transform) 
						{
							if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
								child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = false;
						}
					}
				}
			}
		}
		//Debug.Log(gameObject.name);
	}

	public void InvokePreviousAnimation (string AnimToSet)
	{
		if (AnimationDelayTracker > 0) {
			AnimationDelayTracker--;
			if (AnimationBool [AnimationDelayTracker] == true) {			

				if (GetComponent<Camera> () != null) 
				{//if the thing to check has a camera.


					if (GetComponent<CameraShake> () != null && AnimationDelayTracker == InstancesToActivate) {
						GetComponent<CameraShake> ().activate ();
						//Debug.Log ("camera shakes");
					}

					//gameObject.SetActive (true);
					gameObject.GetComponent<Camera>().enabled = true;
					if(GetComponent<Animator>() != null)
					{
						//GetComponent<Animator>().SetTrigger("goback");
						GetComponent<Animator>().Play(AnimToSet, -1, 0f);
					}
					if(CamPos [AnimationDelayTracker] != new Vector3(0,0,0) && AnimationDelayTracker <CamPos.Length-1)
					{gameObject.transform.position = CamPos [AnimationDelayTracker];}

				} 
				else 
				{//Turn on the renderer

					if (GetComponent<Image> () != null) {
						GetComponent<Image> ().enabled = true;
					} else {

						GetComponent<Animator> ().enabled = true;
						foreach (Transform child in transform) {
							if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
								child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = true;
						}

						//GetComponent<Animator> ().SetTrigger ("goback");
						GetComponent<Animator>().Play(AnimToSet, -1, 0f);
					}
				}
			} else {

				if (GetComponent<Camera> () != null) 
				{//if the thing to check has a camera.
					//Debug.Log(gameObject.name+"turn off");
					//gameObject.SetActive (false);
					gameObject.GetComponent<Camera>().enabled = false;
				} 
				else 
				{//Turn on the renderer

					if (GetComponent<Image> () != null) {
						GetComponent<Image> ().enabled = false;
					} else {

						gameObject.GetComponent<Animator> ().enabled = false;
						foreach (Transform child in transform) {
							if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
								child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = false;
						}
					}
				}
				//GetComponent<Animator> ().SetTrigger ("goback");
				}

		}
	}

	public void ResetToTheEnd ()
	{
		AnimationDelayTracker = AnimationBool.Length - 1;
		//Debug.Log(gameObject.name+"turn on");	
		if (AnimationBool [AnimationDelayTracker] == true) 
		{		
			
			if (GetComponent<Camera> () != null) 
			{//if the thing to check has a camera.
				if (GetComponent<CameraShake> () != null && AnimationDelayTracker == InstancesToActivate) {
					GetComponent<CameraShake> ().activate ();
					//Debug.Log ("camera shakes");
				}
				//gameObject.SetActive (true);
				gameObject.GetComponent<Camera>().enabled = true;
				if(GetComponent<Animator>() != null)
				{
					GetComponent<Animator>().SetTrigger(LastAnimation);
				}
			} 
			else 
			{
				if (GetComponent<Image> () != null) {
					GetComponent<Image> ().enabled = true;
				} else {
					GetComponent<Animator> ().enabled = true;
					foreach (Transform child in transform) {
						if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
							child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = true;
					}
					GetComponent<Animator> ().Play (LastAnimation);
				}
			}

		} else {

			if (GetComponent<Camera> () != null) 
			{//if the thing to check has a camera.
				//Debug.Log(gameObject.name+"turn off");
				//gameObject.SetActive (false);
				gameObject.GetComponent<Camera>().enabled = false;

			} 
			else 
			{//Turn on the renderer

				if (GetComponent<Image> () != null) {
					GetComponent<Image> ().enabled = true;
				} else {
					if(GetComponent<Animator>() != null)
					{
						GetComponent<Animator> ().enabled = true;
						//Debug.Log (gameObject.name);
						GetComponent<Animator>().SetTrigger(LastAnimation);
						GetComponent<Animator> ().Play (LastAnimation);
						GetComponent<Animator> ().enabled = false;
					}
					GetComponent<Animator> ().enabled = false;
					foreach (Transform child in transform) {
						if (child.gameObject.GetComponent<SkinnedMeshRenderer> () != null)
							child.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = false;
					}
				}
			}
		}

		//GetComponent<Animator> ().Play (LastAnimation);
	}

	private void CharacterTurnOff()
	{
		
	}
}
