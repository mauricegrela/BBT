using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuManager : MonoBehaviour
{
    public MenuStorySlide MenuStorySlide_Sasquatch;
    public MenuStorySlide MenuStorySlide_LittlePepole;
    public MenuStorySlide MenuStorySlide_Kalkalilh;

    public MenuStoryObjects MenuStoryObjects_Sasquatch;
    public MenuStoryObjects MenuStoryObjects_LittlePepole;
    public MenuStoryObjects MenuStoryObjects_kalkalilh;

    private void Start()
    {
        MenuStorySlide_Sasquatch.gameObject.SetActive(true);
        MenuStorySlide_LittlePepole.gameObject.SetActive(true);
        MenuStorySlide_Kalkalilh.gameObject.SetActive(true);

        MenuStoryObjects_Sasquatch.gameObject.SetActive(true);
        MenuStoryObjects_LittlePepole.gameObject.SetActive(true);
        MenuStoryObjects_kalkalilh.gameObject.SetActive(true);
    }

    public void ClickedToOpenSasquatchSlide()
    {
        MenuStorySlide_Sasquatch.OpenSlide();
        MenuStorySlide_LittlePepole.StartClosing(false);
        MenuStorySlide_Kalkalilh.StartClosing(false);

        MenuStoryObjects_Sasquatch.SlideOpened();
        MenuStoryObjects_LittlePepole.SlideClosed(false);
        MenuStoryObjects_kalkalilh.SlideClosed(false);
    }

    public void ClickedToOpenLittleFrineds()
    {
        MenuStorySlide_Sasquatch.StartClosing(true);
        MenuStorySlide_LittlePepole.OpenSlide();
        MenuStorySlide_Kalkalilh.StartClosing(false);

        MenuStoryObjects_Sasquatch.SlideClosed(true);
        MenuStoryObjects_LittlePepole.SlideOpened();
        MenuStoryObjects_kalkalilh.SlideClosed(false);

    }

    public void ClickedToOpenKalkalilh()
    {
        MenuStorySlide_Sasquatch.StartClosing(true);
        MenuStorySlide_LittlePepole.StartClosing(true);
        MenuStorySlide_Kalkalilh.OpenSlide();

        MenuStoryObjects_Sasquatch.SlideClosed(true);
        MenuStoryObjects_LittlePepole.SlideClosed(true);
        MenuStoryObjects_kalkalilh.SlideOpened();
    }
}

