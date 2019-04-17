using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStorySlide : MonoBehaviour
{
    //only middle story uses both CloseRectLeft and CloseRectRight
    RectTransform MyMaskRect;
    Image childStoryImage;

    public RectTransform CloseRectLeft; //mask object
    public RectTransform CloseRectRight; //mask object

    public RectTransform OpenedMaskRect;
    public RectTransform ChildImageRect;
    public RectTransform ChildImagedOpenedFixedRect;

    public RectTransform ChildImagedClosedRightFixedRect;//only middle story uses both ChildImagedClosedRightFixedRect and ChildImagedClosedLeftFixedRect
    public RectTransform ChildImagedClosedLeftFixedRect;

    public Color ClosedColor;

    private void Start()
    {
        MyMaskRect = GetComponent<RectTransform>();
        childStoryImage = ChildImageRect.gameObject.GetComponent<Image>();

        childStoryImage.color = ClosedColor;
    }

    public void StartClosing(bool _shouldCloseToLeft)
    {
        StopAllCoroutines();

        if (_shouldCloseToLeft)
        {
            StartCoroutine(LerpSizePos(0, 0, CloseRectLeft, 2));
            StartCoroutine(LerpChildImageSizePos(0, 0, ChildImagedClosedLeftFixedRect, 2));
        }
        else
        {
            StartCoroutine(LerpSizePos(0, 0, CloseRectRight, 2));
            StartCoroutine(LerpChildImageSizePos(0, 0, ChildImagedClosedRightFixedRect, 2));
        }

        StartCoroutine(LerpImageColor(0, 0, ClosedColor, 2));

    }

    public void OpenSlide()
    {
        StopAllCoroutines();
        StartCoroutine(LerpSizePos(0, 0, OpenedMaskRect, 2));
        StartCoroutine(LerpChildImageSizePos(0, 0, ChildImagedOpenedFixedRect, 2));
        StartCoroutine(LerpImageColor(0, 0, Color.white, 2));

    }

    IEnumerator LerpSizePos(float currentTime, float normalizedValue, RectTransform to, float timeOfTravel)
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            MyMaskRect.sizeDelta = Vector2.Lerp(MyMaskRect.sizeDelta, to.sizeDelta, normalizedValue);
            MyMaskRect.anchoredPosition = Vector2.Lerp(MyMaskRect.anchoredPosition, to.anchoredPosition, normalizedValue);

            yield return null;
        }
    }


    IEnumerator LerpChildImageSizePos(float currentTime, float normalizedValue, RectTransform to, float timeOfTravel)
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            ChildImageRect.sizeDelta = Vector2.Lerp(ChildImageRect.sizeDelta, to.sizeDelta, normalizedValue);
            ChildImageRect.anchoredPosition = Vector2.Lerp(ChildImageRect.anchoredPosition, to.anchoredPosition, normalizedValue);

            yield return null;
        }
    }

    IEnumerator LerpImageColor(float currentTime, float normalizedValue, Color ColorToChangeTo, float timeOfTravel)
    {

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            childStoryImage.color = Color.Lerp(childStoryImage.color, ColorToChangeTo, normalizedValue);

            yield return null;
        }
    }

}
