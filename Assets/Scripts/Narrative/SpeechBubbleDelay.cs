using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using UnityEngine;

public class SpeechBubbleDelay : MonoBehaviour {

    //CoRoutine Loading
    private IEnumerator coroutine;
    private float SpeechDelay;
    private bool isCountingDown = false;
    private float timeCounter = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isCountingDown == true)
        {
            if(timeCounter<SpeechDelay)
            {
            timeCounter += Time.deltaTime;    
            }
                else
                {
                GetComponent<Canvas>().enabled = true;
                isCountingDown = false;
                }
        }
	}

    public void Acvivate_SpeechBuggle(float Delay)
    {
        isCountingDown = true;
        SpeechDelay = Delay;
    }

  /* public IEnumerator Acvivate_SpeechBuggle(float Delay)
    {
        yield return StartCoroutine("WaitAndPrint");
        SpeechDelay = Delay;
        Debug.Log(Delay);
       
    }

    IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(SpeechDelay);
        GetComponent<Canvas>().enabled = true;
        //print("WaitAndPrint " + Time.time);
    }*/
}
