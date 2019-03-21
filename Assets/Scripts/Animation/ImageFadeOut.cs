using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFadeOut : MonoBehaviour {
    
    public void StartCo()
    {
        StartCoroutine(FadeTo(0.0f, 1.5f));
    }
    
    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}
