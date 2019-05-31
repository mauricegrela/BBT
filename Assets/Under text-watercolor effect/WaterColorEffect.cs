using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterColorEffect : MonoBehaviour
{
    SpriteMask spriteMask;
    //  bool isLarping;
    public float EffectTimeSpan;

    void Start()
    {
        spriteMask = GetComponent<SpriteMask>();
        //StartCoroutine(LerpAlphaCutOff(0, 0, EffectTimeSpan));
    }

    //void Update()
    //{
    //    if(Input.GetKeyDown("x"))
    //    {
    //        StopAllCoroutines();
    //        StartCoroutine(LerpAlphaCutOff(0,0,1));
    //    }
    //}

    //public void ClickedButtonToShowEffect()
    //{
    //    StartCoroutine(LerpAlphaCutOff(0, 0, 1));
    //}

    public void ActivateEffect()
    {
        if(spriteMask==null)
        {
            spriteMask = GetComponent<SpriteMask>();
        }
        //called from story manager
        StartCoroutine(LerpAlphaCutOff(0, 0, 1));
    }



    IEnumerator LerpAlphaCutOff(float currentTime, float normalizedValue, float timeOfTravel)
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            spriteMask.alphaCutoff = Mathf.Lerp(1,0, normalizedValue);

            yield return null;
        }
    }
}
