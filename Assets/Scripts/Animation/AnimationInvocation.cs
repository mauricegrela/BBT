using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationInvocation : MonoBehaviour {

   public GameObject[] charactersToAnimate;
   public string[] animationsToPlay;

    Animator anim;

    // Use this for initialization
    void Start () {
        Character_SetUp();
        //anim = GetComponent<Animator>()
        //InitiateAnimation();
    }

    private void Character_SetUp()
    {
        /*foreach (Transform child in transform)
        {
            if(child.GetComponent<BoxCollider>)
            //child is your child transform
        }*/

    }

    private void InitiateAnimation()
    {
     for(int i = 0; i<charactersToAnimate.Length;i++)
        {
            //charactersToAnimate[i].GetComponent<Animator>().
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }

    }
}
