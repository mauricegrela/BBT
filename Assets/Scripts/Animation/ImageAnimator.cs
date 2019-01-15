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
		//StartCoroutine("nukeMethod");
        /*if (isAnimated == true)
        { 
        StartCoroutine("nukeMethod");
        }*/
    }

    public IEnumerator nukeMethod()
    {
            for (int i = 0; i < sprites.Length; i++)
            {
                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
                

             
                yield return new WaitForSeconds(animationSpeed);

            }
        //isAnimating = false;
        if(IsLooping==true)
        {
        StartCoroutine("nukeMethod");   
        }
        else
        {
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
        //SFXSource.Play();
        SFXSource.loop = false;

        isAnimating = false;
        //gameObject.GetComponent<Image>().sprite = sprites[0];
    }

    public void ResetPosition()
    {
        transform.position = OGPose;
    }

    void OnEnable()
    {
        
        StartCoroutine("nukeMethod"); 
        //Debug.Log("Triggered");
    }

    void OnDisable()
    {
        StopAllCoroutines();
        //Debug.Log("Triggered");
    }

}
