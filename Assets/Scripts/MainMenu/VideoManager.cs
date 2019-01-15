using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoManager : MonoBehaviour {

	public GameObject ImageRef;
	private GameObject Container;
	//public Sprite[] stills;
	public VideoClip[] videoClips;
	public VideoPlayer vidRef;
	private bool isSasOpen = false;
	private bool isLiLOpen = false;
	private bool isKalOpen = false;

	// Use this for initialization
	void Start () {
		GetComponent<VideoPlayer> ().loopPointReached  += CheckOver;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetStatic(Sprite image)
	{
		ImageRef.GetComponent<Image>().sprite = image;
	}

	public void ActivateContainer(GameObject containerRef)
	{
		if (Container != null) {
		Container.SetActive (false);
		}
		Container = containerRef;
	}

	public void ChangeSasSource()
	{

		if (isSasOpen == true) {
			isSasOpen = false;
			GetComponent<VideoPlayer>().clip = videoClips [3];
			GetComponent<VideoPlayer> ().Play ();
		} else {
			isSasOpen = true;
			isLiLOpen = false;
			isKalOpen = false;
			GetComponent<VideoPlayer>().clip = videoClips [4];
			GetComponent<VideoPlayer> ().Play ();
		}

	}

	public void ChangeLilSource()
	{
		if (isLiLOpen == true) {
			isLiLOpen = false;
			GetComponent<VideoPlayer>().clip = videoClips [1];
			GetComponent<VideoPlayer> ().Play ();
		} else {
			isLiLOpen = true;
			isSasOpen = false;
			isKalOpen = false;
			GetComponent<VideoPlayer>().clip = videoClips [2];
			GetComponent<VideoPlayer> ().Play ();
		}
	}

	public void ChangeKalSource()
	{
		if (isKalOpen == true) {
			isKalOpen = false;
			GetComponent<VideoPlayer>().clip = videoClips [5];
			GetComponent<VideoPlayer> ().Play ();
		} else {
			isKalOpen = true;
			isSasOpen = false;
			isLiLOpen = false;
			GetComponent<VideoPlayer>().clip = videoClips [6];
			GetComponent<VideoPlayer> ().Play ();
		}
	}

	void CheckOver(UnityEngine.Video.VideoPlayer vp)
	{
		print  ("Video Is Over");
		ImageRef.SetActive (true);
		Container.SetActive (true);
	}
}
