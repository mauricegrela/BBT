using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public GameObject EndScreenFrameCanvas;
    //is set active from GotoNext
    void Start () {
        gameObject.SetActive(false);
        EndScreenFrameCanvas.SetActive(false);

    }

    public void ShowEndScreen()
    {
        //called from storyManager script's ShowEndScreen();
        gameObject.SetActive(true);
        EndScreenFrameCanvas.SetActive(true);
    }

    public void LoadMainManu()
    {
        //called from home button
        print("load scene");
        SceneManager.LoadSceneAsync("Menu");
    }

}
