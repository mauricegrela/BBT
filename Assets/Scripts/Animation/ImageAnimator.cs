using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImageAnimator : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;
    public float animationSpeed = 0.02f;
    public bool IsLooping = true;
    private bool isAnimating = false;
    private Vector3 OGPose;
    public AudioSource SFXSource;
    public AudioClip PlaceSound;

    void Start()
    {
        OGPose = transform.position;
    }

    public IEnumerator nukeMethod()
    {
	for (int i = 0; i < sprites.Length; i++)
	{
	gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
	yield return new WaitForSeconds(animationSpeed);
	}
	    
	if(IsLooping==true)
	{//if the animation is one that loops start up the co routine again.
	StartCoroutine("nukeMethod");   
	}
		else
		{//Stop it
		    StopAllCoroutines();
		} 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isAnimating == false)
        {
            SFXSource.clip = PlaceSound;
            SFXSource.Play();
            SFXSource.loop = true;
            isAnimating = true;
            StartCoroutine("nukeMethod"); //Debug.Log("Triggered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        SFXSource.loop = false;
        isAnimating = false;
    }

    public void ResetPosition()
    {
        transform.position = OGPose;
    }

    void OnEnable()
    {
        StartCoroutine("nukeMethod"); 
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

}
