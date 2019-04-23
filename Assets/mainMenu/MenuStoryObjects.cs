using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStoryObjects : MonoBehaviour {

    public Image Title;
    public Image Logo;
    public Image Description;

    RectTransform TitleRect;

    public RectTransform TitleClosedPosRectLeft;
    public RectTransform TitleClosedPosRectRight;

    public GameObject PlayButton;
    Image PlayButtonImage;

    public GameObject UnlockContentButton;
    Image UnlockContentButtonImage;

    public GameObject UnlockContentQuastionScreen;
    Image UnlockContentQuastionScreenImage;

    public RectTransform CommingSoonRect;

    public RectTransform CommingSoonRectCloseRectLeft;
    public RectTransform CommingSoonRectCloseRecRight;

    public GameObject CorrectTextObject;

    private void Start()
    {
        Title.gameObject.SetActive(true);
        Logo.gameObject.SetActive(true);
        Description.gameObject.SetActive(true);
        
        if (PlayButton != null)
        {
            PlayButton.gameObject.SetActive(false);
            PlayButtonImage = PlayButton.GetComponent<Image>();
            SetImageAlpha(PlayButtonImage, 0);
        }

        if(UnlockContentButton != null)
        {
            UnlockContentButton.SetActive(false);
            UnlockContentButtonImage = UnlockContentButton.GetComponent<Image>();
            SetImageAlpha(UnlockContentButtonImage, 0);
        }

        if (UnlockContentQuastionScreen != null)
        {
            UnlockContentQuastionScreen.SetActive(false);
            UnlockContentQuastionScreenImage = UnlockContentQuastionScreen.GetComponent<Image>();
            SetImageAlpha(UnlockContentQuastionScreenImage, 0);

            CorrectTextObject.SetActive(false);
        }

        SetImageAlpha(Logo, 0);
        SetImageAlpha(Description, 0);

        TitleRect = Title.gameObject.GetComponent<RectTransform>();
    }

    void SetImageAlpha(Image _image, float _alpha)
    {
        _image.color = new Color(_image.color.r, Logo.color.g, _image.color.b, _alpha);
    }

    public void SlideOpened()
    {
        StopAllCoroutines();
        StartCoroutine(LerpLogoAlpha(0, 0, 1, 2, Logo));
        StartCoroutine(LerTitleAlpha(0, 0, 1, 2, Description));
        StartCoroutine(LerpDescriptionAlpha(0, 0, 0, 2, Title));

        if(PlayButton!=null)
        {
            PlayButton.SetActive(true);
            StartCoroutine(LerpLogoAlpha(0, 0, 1, 2, PlayButtonImage));
        }

        if (UnlockContentButton != null)
        {
            UnlockContentButton.SetActive(true);
            StartCoroutine(LerpLogoAlpha(0, 0, 1, 2, UnlockContentButtonImage));
        }
    }

    public void SlideClosed(bool _shouldCloseToLeft)
    {
        StopAllCoroutines();
        StartCoroutine(LerpLogoAlpha(0, 0, 0, 2, Logo));
        StartCoroutine(LerTitleAlpha(0, 0, 0, 2, Description));
        StartCoroutine(LerpDescriptionAlpha(0, 0, 1, 2, Title));

        if (_shouldCloseToLeft)
        {
            if(CommingSoonRectCloseRectLeft!=null)
            {
                StartCoroutine(LerpComingSoonPos(0, 0, CommingSoonRect, CommingSoonRectCloseRectLeft, 2));
            }

            StartCoroutine(LerpTitlePos(0, 0, TitleRect, TitleClosedPosRectLeft, 2));
        }
        else
        {
            if (CommingSoonRectCloseRecRight != null)
            {
                StartCoroutine(LerpComingSoonPos(0, 0, CommingSoonRect, CommingSoonRectCloseRecRight, 2));
            }

            StartCoroutine(LerpTitlePos(0, 0, TitleRect, TitleClosedPosRectRight, 2));
        }

        if (PlayButton!=null)
        {
            PlayButton.SetActive(false);
            StartCoroutine(LerpLogoAlpha(0, 0, 0, 2, PlayButtonImage));
        }

        if (UnlockContentButton != null)
        {
            UnlockContentButton.SetActive(false);
            StartCoroutine(LerpLogoAlpha(0, 0, 0, 2, UnlockContentButtonImage));
        }

        if (UnlockContentQuastionScreen != null)
        {
            UnlockContentQuastionScreen.SetActive(false);
            StartCoroutine(LerpLogoAlpha(0, 0, 0, 2, UnlockContentQuastionScreenImage));

            CorrectTextObject.SetActive(false);
        }
    }

    public void ClickedUnlockContentButton()
    {
        if (UnlockContentQuastionScreen != null)
        {
            UnlockContentQuastionScreen.SetActive(true);
            SetImageAlpha(UnlockContentQuastionScreenImage, 1);
        }
    }

    public void ClickedCorrectAnswer()
    {
        CorrectTextObject.SetActive(true);

    }

    IEnumerator LerpLogoAlpha(float currentTime, float normalizedValue, float _alphaValueToChangeTo, float timeOfTravel,Image _image)
    {

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            _image.color = new Color(_image.color.r, Logo.color.g, _image.color.b, Mathf.Lerp(_image.color.a, _alphaValueToChangeTo, normalizedValue));

            yield return null;
        }
    }

    IEnumerator LerpDescriptionAlpha(float currentTime, float normalizedValue, float _alphaValueToChangeTo, float timeOfTravel, Image _image)
    {

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.Lerp(_image.color.a, _alphaValueToChangeTo, normalizedValue));

            yield return null;
        }
    }

    IEnumerator LerTitleAlpha(float currentTime, float normalizedValue, float _alphaValueToChangeTo, float timeOfTravel, Image _image)
    {

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.Lerp(_image.color.a, _alphaValueToChangeTo, normalizedValue));

            yield return null;
        }
    }

    IEnumerator LerpTitlePos(float currentTime, float normalizedValue, RectTransform _rect, RectTransform to, float timeOfTravel)
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            //ChildImageRect.sizeDelta = Vector2.Lerp(ChildImageRect.sizeDelta, to.sizeDelta, normalizedValue);
            _rect.anchoredPosition = Vector2.Lerp(_rect.anchoredPosition, to.anchoredPosition, normalizedValue);

            yield return null;
        }
    }

    IEnumerator LerpComingSoonPos(float currentTime, float normalizedValue, RectTransform _rect, RectTransform to, float timeOfTravel)
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            //ChildImageRect.sizeDelta = Vector2.Lerp(ChildImageRect.sizeDelta, to.sizeDelta, normalizedValue);
            _rect.anchoredPosition = Vector2.Lerp(_rect.anchoredPosition, to.anchoredPosition, normalizedValue);

            yield return null;
        }
    }
}
