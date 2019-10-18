using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StoryManager : MonoBehaviour {

	public int AudioIndexPosition; 
	public string LevelName;
    //public string SceneEnvironment;
	public int pagesPerScene;
	public string NextScene;
	public string LastScene;  //this is the previes scene name.
	public bool isLastscene; // is it the Last scene in the story- check in ispector if so.
	public bool isFirstscene;
	public bool isLoadingLevel;
	public int StreamingAssetsCounter;
	public GameObject PageManagerObj;
    PageManager pageManagerSctipt;
	private GameObject Canvas;
    [SerializeField]
    public GameObject CameraRef;
    public Vector3 OGCameraRefPosition;
    public GameObject[] TextPositions;
    public GameObject InitialTextPosition;
    public GameObject DefenitionPage;
    //CoRoutine Loading
    private IEnumerator coroutine =null;
    private int Counter = 0;

    //Panning Variable
    //public bool isPanningLeft = false;
    //public bool isPanningRight = false;
    //private float PanningCounter;
    //private Transform panningtargetPosition;
    //private int CurrentPage;

    //[SerializeField]
    //private GameObject Page37Panning;

    public AudioClip PageSong;
    public AudioClip PanningPageSong2;
    public float Volume = 0.2f;
    //
    private Vector3 DistanceCounter;
    private bool IsMainStoryLoaded = false;
    private bool IsEnviroLoaded = false;
    private bool IsScriptLoadingScene = false;

    public GameObject WaterColorEffectObject;
    WaterColorEffect waterColorEffectScript;

    public GameObject EndScreen;
    //GameObject englishTexPositionGameobject;
    //GameObject frenchTexPositionGameobject;
    //GameObject indigenousTexPositionGameobject;
    //GameObject textContainer;
     
    private void Awake()
    {
        //shoulFollow = false;

        StreamingAssetsCounter = 0;
        //SceneEnvironment = "Exterior";
        Scene currentScene = SceneManager.GetActiveScene();
        string FirstTwo = currentScene.name.Substring(0, 1);
        Debug.Log(FirstTwo);

        if(FirstTwo == "L")
        {
            DataManager.currentStoryName = "littlepeople";
        }
            else if(FirstTwo == "K")
            {
            DataManager.currentStoryName = "kalkalilh";
            }
                else if(FirstTwo == "S")
                {
                DataManager.currentStoryName = "sasquatch";
                }
        /*if(currentScene.name != "MainStory")
        {
            SceneManager.LoadScene("MainStory", LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainStory"));
        }*/

 
        for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
            var scene = SceneManager.GetSceneAt(i);

                if (scene.name == "MainStory")
                {
                IsMainStoryLoaded = true;//the scene is already loaded

                }

            //if(scene.name == SceneEnvironment)
                //{
                //IsEnviroLoaded = true;
                //}
            }
       if(IsMainStoryLoaded == false)
        {
            if (!isLastscene)
            {
                SceneManager.LoadScene(NextScene, LoadSceneMode.Additive);
            }

            if (LastScene != "None")
            {
                SceneManager.LoadScene(LastScene, LoadSceneMode.Additive);
            }

            SceneManager.LoadScene("MainStory", LoadSceneMode.Additive);
                
            //if (IsMainStoryLoaded == false)
            //{
            //SceneManager.LoadScene(SceneEnvironment, LoadSceneMode.Additive);
            //}

            IsMainStoryLoaded = true;
            IsScriptLoadingScene = true;
        }

        DefenitionPage = GameObject.FindGameObjectWithTag("Definition");//Find the story manager found in every level

    }

    public void InitialSetUp()///Awake()
    {
        print("InitialSetUp");
        PageManagerObj = GameObject.FindGameObjectWithTag("PageManager");
        pageManagerSctipt = PageManagerObj.GetComponent<PageManager>();

        //if(PageManager.GetComponent<PageManager>().StringPreviousLevel != SceneEnvironment &&PageManager.GetComponent<PageManager>().StringPreviousLevel != "empty")
        //{
        //    SceneManager.UnloadScene(PageManager.GetComponent<PageManager>().StringPreviousLevel);
        //    SceneManager.LoadScene(SceneEnvironment, LoadSceneMode.Additive);   
        //}

        //if (PageManager.GetComponent<PageManager>().StringPreviousLevel != "empty")
        //{
        //    SceneManager.UnloadScene(PageManager.GetComponent<PageManager>().StringPreviousLevel);
        //}

        //PageManager.GetComponent<PageManager>().StringPreviousLevel = SceneEnvironment;
        //SceneEnvironment = PageManager.GetComponent<StoryManager>().SceneEnvironment;
        if (pageManagerSctipt.isLoading == true)
        {
            //InitialSetUp();
            pageManagerSctipt.isLoading = false;
            pageManagerSctipt.StoryManager = gameObject;
                
            if (!isLastscene)
            {
                SceneManager.LoadScene(NextScene, LoadSceneMode.Additive);
            }

            if (LastScene != "None")
            {
            SceneManager.LoadScene(LastScene, LoadSceneMode.Additive);
            }

            pageManagerSctipt.PreviousLevelTracker = LastScene;

        }


        //pageManagerSctipt.LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
        CameraRef = GameObject.FindGameObjectWithTag("MainCamera");
        CameraRef.GetComponent<Camera>().enabled = true;
        //OGCameraRefPosition = CameraRef.transform.position;
        TextPositions = new GameObject[transform.childCount];
        //pagesPerScene = transform.childCount;
        for (int i = 0; i < transform.childCount; i++)
        {//Store all the pages
            TextPositions[i] = transform.GetChild(i).gameObject;
            //Debug.Log(transform.GetChild(i).name);
        }


        //PageManager = GameObject.FindGameObjectWithTag("PageManager"); // marked this- why is this done again?


        pageManagerSctipt.sentenceContainerCounter = 0;
        pageManagerSctipt.sentenceContainerCurrent = 0;

        foreach (GameObject child in TextPositions)
        {//Store the First of the Text References                 
            child.SetActive(true);
        }

        int position;

        /*if(PageManager.GetComponent<PageManager>().isGoingBack == true)
        {
        TextPositions[TextPositions.Length - 1].SetActive(true);
        position = TextPositions.Length - 1;
        }
            else
            {
            TextPositions[0].SetActive(true);
            position = 0;
            }*/



        for (int i = 0; i < TextPositions.Length; ++i)
        {
            foreach (Transform child in TextPositions[i].transform)
            {//Store the First of the Text References 
                if (child.gameObject.tag == "TextPlacement")
                {
                    pageManagerSctipt.
                    sentenceContainer[pageManagerSctipt.sentenceContainerCounter]
                    = child.gameObject.GetComponent<SentenceRowContainer>();

                    PageManagerObj.GetComponent<PageManager>().sentenceContainerCounter++;
                }
            }  
        }


        //Set references 
       
        //PageManager.GetComponent<PageManager>().sentenceContainer[0] = InitialTextPosition.GetComponent<SentenceRowContainer>();

        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        //PageManagerObj.GetComponent<PageManager>().LoadingScreen.GetComponent<Image>().enabled = true;
        if (isLoadingLevel == true && PageManagerObj.GetComponent<PageManager>().isIniAudioLoaded == false)
        {//If this is going to load a different streaming package, load it here. 
            pageManagerSctipt.audioIndex = 0;
            pageManagerSctipt.isIniAudioLoaded = true;
            DataManager.LoadStory(DataManager.currentStoryName, StreamingAssetsCounter.ToString());
        }


        if(IsScriptLoadingScene == true)
        {
            pageManagerSctipt.audioIndex = 0;
            pageManagerSctipt.isIniAudioLoaded = true;
            DataManager.LoadStory(DataManager.currentStoryName, StreamingAssetsCounter.ToString());
        }

    CoroutineLoad();
        //SceneManager.SetActiveScene(NextScene)
    }

	// Use this for initialization
	public void CoroutineLoad()//Start () 
    {

		if (pageManagerSctipt.isGoingBack == false) 
        {
            pageManagerSctipt.AssetAssigner(LevelName, AudioIndexPosition);
            pageManagerSctipt.GoToPage(AudioIndexPosition);
            pageManagerSctipt.ChapterskipSetCharacters(0);
           //pageManagerSctipt.LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
        GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
        if (AnimRef != null)
            AnimRef.GetComponent<Animator>().enabled = true;

        GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
        if (AnimatedObject != null)
            AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();
		} 
			else 
			{//If the player is going backwards
            pageManagerSctipt.AssetAssigner(LevelName, AudioIndexPosition);
            pageManagerSctipt.GoToPage(AudioIndexPosition);
            pageManagerSctipt.ChapterskipSetCharacters(0);
            //pageManagerSctipt.LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
            GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
            if (AnimRef != null)
                AnimRef.GetComponent<Animator>().enabled = true;

            GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
            if (AnimatedObject != null)
                AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();
            //coroutine = WaitGoingBack(0.0f);
            //StartCoroutine(coroutine);
			}


        positionTextAccordingLanguage();
        CallWaterColorEffect();
    }

    void CallWaterColorEffect()
    {
        WaterColorEffectObject = GameObject.FindWithTag("WaterColorEffect");
        if (WaterColorEffectObject != null)
        {
            waterColorEffectScript = WaterColorEffectObject.GetComponent<WaterColorEffect>();
            waterColorEffectScript.ActivateEffect();
        }
    }

    TextPositionEditMode[] textPositionEditModeAll;
    SentenceRowContainer sentenceRowContainer;

    //bool shoulFollow = false;


    TextPositionEditMode EngTextPositionScript;
    TextPositionEditMode FraTextPositionScript;
    TextPositionEditMode IndTextPositionScript;

    //private void OnEnable()
    //{
    //    PageManager.OnLanguageChangeWasUpdate += positionTextAccordingLanguage;
    //}

    //private void OnDisable()
    //{
    //    PageManager.OnLanguageChangeWasUpdate += positionTextAccordingLanguage;
    //}
    public void positionTextAccordingLanguage()
    {
        //print("positionTextAccordingLanguage");
        //is called from child sentenceRowContainer from AddText() and from this script's CoroutineLoad().
        sentenceRowContainer = GetComponentInChildren<SentenceRowContainer>();

        textPositionEditModeAll = GetComponentsInChildren<TextPositionEditMode>();


        //for (int i = 0; i < textPositionEditModeAll.Length; i++)
        //{
        //    if (textPositionEditModeAll[i].tag == "EnglishTextPosition")
        //    {
        //        EngTextPositionScript = textPositionEditModeAll[i];
        //        //EngTextPositionObj = textPositionEditModeAll[i].gameObject;
        //    }
        //    else if(textPositionEditModeAll[i].tag == "FrenchTextPosition")
        //    {
        //        FraTextPositionScript = textPositionEditModeAll[i];
        //        //FraTextPositionObj = textPositionEditModeAll[i].gameObject;
        //    }
        //    else if(textPositionEditModeAll[i].tag == "IndigenousTextPosition")
        //    {
        //        IndTextPositionScript = textPositionEditModeAll[i];
        //        //IndTextPositionObj = textPositionEditModeAll[i].gameObject;
        //    }
        //}

        //if (DataManager.currentLanguage == "english")
        //{
        //    sentenceRowContainer.gameObject.transform.position = EngTextPositionScript.gameObject.transform.position;
        //}
        //else if(DataManager.currentLanguage == "French")
        //{
        //    sentenceRowContainer.gameObject.transform.position = FraTextPositionScript.gameObject.transform.position;

        //}
        //else if (DataManager.currentLanguage == "Indigenous")
        //{
        //    sentenceRowContainer.gameObject.transform.position = IndTextPositionScript.gameObject.transform.position;
        //}



        print(DataManager.currentLanguage + "Current language");

        for (int i=0;i< textPositionEditModeAll.Length;i++)
        {
            //textPositionEditModeAll[i].enabled = false;

            if (textPositionEditModeAll[i].gameObject.tag== "EnglishTextPosition")
            {
                if(DataManager.currentLanguage== "English" || DataManager.currentLanguage=="english")
                {
                    sentenceRowContainer.gameObject.transform.position = textPositionEditModeAll[i].gameObject.transform.position;

                    if(Application.isEditor)
                    {
                        //textPositionEditModeAll[i].enabled = true;

                        textPositionEditModeAll[i].SetTextToFollowThisObject(sentenceRowContainer, "english");
                    }
                }
            }
            else if(textPositionEditModeAll[i].gameObject.tag == "FrenchTextPosition")
            {
                if (DataManager.currentLanguage == "French")
                {
                    sentenceRowContainer.gameObject.transform.position = textPositionEditModeAll[i].gameObject.transform.position;

                    if (Application.isEditor)
                    {
                        //textPositionEditModeAll[i].enabled = true;

                        textPositionEditModeAll[i].SetTextToFollowThisObject(sentenceRowContainer, "French");
                    }
                }
            }
            else if (textPositionEditModeAll[i].gameObject.tag == "IndigenousTextPosition")
            {
                //print("IndigenousTextPosition TAG");

                if (DataManager.currentLanguage == "Indigenous")
                {
                    print("place at Indigenous position " + textPositionEditModeAll[i].gameObject.name);
                    sentenceRowContainer.gameObject.transform.position = textPositionEditModeAll[i].gameObject.transform.position;

                    if (Application.isEditor)
                    {
                        //textPositionEditModeAll[i].enabled = true;

                        textPositionEditModeAll[i].SetTextToFollowThisObject(sentenceRowContainer, "Indigenous");
                    }
                }
            }
            else if (textPositionEditModeAll[i].gameObject.tag == "SpanishTextPosition")
            {
                //print("IndigenousTextPosition TAG");

                if (DataManager.currentLanguage == "Spanish")
                {
                    print("place at spanish position " + textPositionEditModeAll[i].gameObject.name);
                    sentenceRowContainer.gameObject.transform.position = textPositionEditModeAll[i].gameObject.transform.position;

                    if (Application.isEditor)
                    {
                        //textPositionEditModeAll[i].enabled = true;

                        textPositionEditModeAll[i].SetTextToFollowThisObject(sentenceRowContainer, "Spanish");
                    }
                }
            }

        }
    }

    public void ShowEndScreen()
    {
        //called from pageManager script GotoNext() when is LastScene

        //EndScreen.gameObject.SetActive(true);
        EndScreen.gameObject.GetComponent<EndScreen>().ShowEndScreen();
    }

    //private IEnumerator WaitGoingBack(float waitTime)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //        if (Counter == 0)
    //        {
    //            PageManager.GetComponent<PageManager>().AssetAssigner(LevelName, pagesPerScene - 1);
    //        }
    //        else if (Counter == 1)
    //        {

    //        }
    //        else if (Counter == 2)
    //        {
    //            PageManager.GetComponent<PageManager>().SetToLastPosition();
    //            PageManager.GetComponent<PageManager>().GetComponent<PageManager>().GoToPage(AudioIndexPosition + pagesPerScene - 1);
    //            PageManager.GetComponent<PageManager>().isGoingBack = false;

    //            PageManager.GetComponent<PageManager>().isGoingBack = false;
    //            PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
    //            GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
    //            if (AnimRef != null)
    //            AnimRef.GetComponent<Animator>().enabled = true;

    //            GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
    //            if (AnimatedObject != null)
    //                AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();

    //            StopCoroutine(coroutine);
    //        }
    //        else
    //        {

    //            print("error");
    //        }
    //        Counter++;
    //    }
    //}

    //private IEnumerator WaitGoingForward(float waitTime)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //        if (Counter == 0)
    //        {
    //            PageManager.GetComponent<PageManager> ().AssetAssigner (LevelName, AudioIndexPosition);
    //            PageManager.GetComponent<PageManager>().GoToPage(AudioIndexPosition);
    //            PageManager.GetComponent<PageManager>().ChapterskipSetCharacters(0);
    //            PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
    //            GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
    //            if (AnimRef != null)
    //                AnimRef.GetComponent<Animator>().enabled = true;

    //            GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
    //            if (AnimatedObject != null)
    //                AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();

    //            StopCoroutine(coroutine);
    //        }
    //        else if (Counter == 1)
    //        {

    //        }
    //        else if (Counter == 2)
    //        {

    //        }
    //        else
    //        {

    //            print("error");
    //        }
    //        Counter++;
    //    }
    //}

    //public void PanRight()
    //{

    //    isPanningRight = true;
    //    CurrentPage = PageManager.GetComponent<PageManager>().sceneindex;
    //    //CameraRef.transform.position = OGCameraRefPosition;
    //    if (TextPositions[CurrentPage].tag == "panning")
    //    {
    //        //Debug.Log("This is a specific panning script.");
    //        TextPositions[CurrentPage].SetActive(true);
    //        foreach (Transform child in TextPositions[CurrentPage].transform)
    //        {//Store the First of the Text References 

    //            if (child.gameObject.tag == "panning target")
    //            {
    //                panningtargetPosition = child.gameObject.transform;
    //            }

    //        }
    //    }
    //        else
    //        {
    //            foreach (GameObject child in TextPositions)
    //            {//Store the First of the Text References                 
    //                child.SetActive(false);
    //            }

    //            //TextPositions[CurrentPage].SetActive(true);

    //            isPanningRight = false;
    //            PageManager.GetComponent<PageManager>().SetUpNewTextFoward(); 


    //        }
    //}

    //public void PanLeft()
    //{
    //    isPanningLeft = true;
    //    //CameraRef.transform.position = OGCameraRefPosition;
    //}

    // Update is called once per frame
    //void Update () {

    //       if(isPanningRight == true && isPanningLeft == false)
    //       {
    //           float dist = Vector3.Distance(CameraRef.transform.position, panningtargetPosition.position);
    //           if (dist >= 0.1)
    //           {
    //               //CameraRef.transform.Translate(Vector3.right * (Time.deltaTime*2), Space.World);
    //               float step = 6 * Time.deltaTime;

    //               // Move our position a step closer to the target.
    //               //CameraRef.transform.position = Vector3.MoveTowards(CameraRef.transform.position, panningtargetPosition.position, step);
    //           }
    //               else
    //               {
    //                   foreach (GameObject child in TextPositions)
    //                   {//Store the First of the Text References                 
    //                       child.SetActive(false);
    //                   }

    //               //TextPositions[CurrentPage].SetActive(true);

    //               GameObject[] AnimRef = GameObject.FindGameObjectsWithTag("LoadPageAnim");

    //                foreach (GameObject child in AnimRef)
    //                {
    //                    if (child.gameObject.GetComponent<SpriteRenderer>())
    //                    {
    //                        child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    //                    }

    //                    if (child.gameObject.GetComponent<Animator>())
    //                    {
    //                        child.gameObject.GetComponent<Animator>().enabled = true;
    //                    }
    //                }
    //               isPanningRight = false;
    //               PageManager.GetComponent<PageManager>().SetUpNewTextFoward();
    //               }
    //       }


    //       if (isPanningRight == false && isPanningLeft == true)
    //       {
    //           foreach (GameObject child in TextPositions)
    //           {//Store the First of the Text References                 
    //               child.SetActive(false);
    //           }
    //           CurrentPage = PageManager.GetComponent<PageManager>().sceneindex;

    //           TextPositions[CurrentPage].SetActive(true);
    //           GameObject[] AnimRef = GameObject.FindGameObjectsWithTag("LoadPageAnim");

    //           foreach (GameObject child in AnimRef)
    //           {
    //               if (child.gameObject.GetComponent<SpriteRenderer>())
    //               {
    //                   child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    //               }

    //               if (child.gameObject.GetComponent<Animator>())
    //               {
    //                   child.gameObject.GetComponent<Animator>().enabled = true;
    //               }
    //           }
    //           isPanningLeft = false;
    //           PageManager.GetComponent<PageManager>().SetUpNewTextBack();

    //       }
    //}

    //public void SetToFinal()
    //{
    //    Debug.Log("SET TO FINAL");
    //    foreach (GameObject child in TextPositions)
    //    {//Store the First of the Text References                 
    //        child.SetActive(false);
    //    }
    //    //int CurrentPage = PageManager.GetComponent<PageManager>().sceneindex;
    //    TextPositions[CurrentPage].SetActive(true);  
    //}
}
