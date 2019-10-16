using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PageManager : Singleton<PageManager>
{
    //public static event Action<string,string> onSentenceChange;

    private StoryObject currentStory
    {
        get
        {
            return DataManager.currentStory;
            Debug.Log(currentStory);
        }
    }

    private PageObject currentPage
    {
        get
        {
            //Debug.Log(currentStory.pageObjects[pageIndex]);
            return currentStory.pageObjects[pageIndex];
        }
    }

    //PageKeepers
    private int pageIndex;
    public int audioIndex;
    //public int sceneindex;
    /// <summary>/// /////TURN THIS PRIVATE/// </summary>
    private int LastPageLoader;
    public bool isGoingBack = false;
    public int ChapterOffSet = 0;

    //Technicals
    private AudioSource audioSource;
    [SerializeField]
    public SentenceRowContainer[] sentenceContainer;
    public int sentenceContainerCounter;
    public int sentenceContainerCurrent = 0;
    private bool isForward = true;
    [SerializeField]
    private GameObject[] Characters;
    [SerializeField]
    private GameObject[] DynamicProps;
    public bool isLoading = false;
    private string CurrentLevel;
    private string PreviousLevel;
    private string StringCurrentLevel;
    public string StringPreviousLevel = "empty";


    //Narrative Manager vars
    public GameObject StoryManager;
    StoryManager storyManagerScript;
    [SerializeField]
    private string EnvironmentTracker;// scene name
    [SerializeField]
    public string PreviousLevelTracker;
    public GameObject TextBody;
    private Vector3 OG_PostitionTextBody;
    public float IsReadingAlong = 1.0f;

    //Camera Variables
    private Vector3 cameraPreviousPosition;
    public Transform cameraTransformTracker;
    private bool isCamMoving = false;

    //Menu Variables
    public bool isMenuDeployed = false;

    //Mouse Tracking Variabels
    private bool CanSwipe = true;
    private Vector2 mouseStartPosition;
    private float mouseDistance;
    private float mouseoffset;
    private bool isMouseMoving;
    private Vector2 mouseEndPosition;
    private GameObject MountainTest;
    private GameObject CharacterCoin;
    private string Speaker;
    private int narrativeCounter = 1;

    //UI Assets
    public GameObject UIDots;
    public GameObject ScentenceContainer;
    public Image LoadingScreen;
    [SerializeField]
    private GameObject BackButton;
    [SerializeField]
    private GameObject NextButton;
    [SerializeField]
    private GameObject FrenchCorrection;
    public bool isChapter3LoadedFromMenu = false;
    public GameObject DefenitionPage;
    public bool isIniAudioLoaded = false;
    //Audio Vars
    [SerializeField]
    private AudioClip[] OST;
    [SerializeField]
    private AudioClip PageDone;
    //Debuging Vars
    public GameObject Scenetext;

    private GameObject TextPositionref;

    [SerializeField]
    public GameObject ScenetextContainer;

    private bool LevelsLoaded = false;

    private float isAutoChapterSkip = 0.0f;



    protected override void Awake()
    {
        base.Awake();
        //sentenceContainer = FindObjectOfType<SentenceRowContainer>();
        audioSource = GetComponent<AudioSource>();
    }


    // Use this for initialization
    IEnumerator Start()
    {//Initiage the story
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainStory"));
        LevelJugler();

        yield return null;
    }

    public void LevelJugler()
    {
        StoryManager = GameObject.FindGameObjectWithTag("StoryManager");//Find the story manager found in every level
        storyManagerScript = StoryManager.GetComponent<StoryManager>(); //added this

        //CurrentLevel = StoryManager.GetComponent<StoryManager>().SceneEnvironment;
        if (LevelsLoaded == false)
        {
            LevelsLoaded = true;
            //SceneManager.LoadScene(StoryManager.GetComponent<StoryManager>().NextScene, LoadSceneMode.Additive);
            storyManagerScript.InitialSetUp();
            PreviousLevelTracker = storyManagerScript.LastScene;
        }
    }

    public void AssetAssigner(string CurrentLevel, int lastPage)
    {//when ever a level is loaded, this code will run to store all of the relative data
        Resources.UnloadUnusedAssets();
        EnvironmentTracker = CurrentLevel;
        StoryManager = GameObject.FindGameObjectWithTag("StoryManager");//Find the story manager found in every level
        Debug.Log("Working");



        if (isGoingBack == true)
        {
            //sceneindex = lastPage;
            //
        }


    }

    public void ChapterskipSetCharacters(int StartingPosition)
    {

    }

    public void ChapterSkip(String LevelToLoad)
    {//Launches when the player skips to a chapter through clicking on the book mark
        StopAllCoroutines();

        StoryManager = GameObject.FindGameObjectWithTag("StoryManager");//Find the story manager found in every level
        storyManagerScript = StoryManager.GetComponent<StoryManager>(); //added this

        //LoadingScreen.GetComponent<LoadingScript>().VisualToggle(true);
        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.Clear();
        }
        isLoading = true;

        //storyManagerScript = StoryManager.GetComponent<StoryManager>();
        storyManagerScript.CameraRef.transform.position = storyManagerScript.OGCameraRefPosition;

        //StoryManager = GameObject.FindGameObjectWithTag("StoryManager");// marked this- why doing this here?


        Resources.UnloadUnusedAssets();

        if (storyManagerScript.NextScene != "None")
        {
            SceneManager.UnloadScene(storyManagerScript.NextScene);
        }

        if (StoryManager.GetComponent<StoryManager>().LastScene != "None")
        {
            SceneManager.UnloadScene(storyManagerScript.LastScene);
        }

        if (PreviousLevelTracker != EnvironmentTracker)
        {
            SceneManager.UnloadScene(EnvironmentTracker);
        }

        StartCoroutine(LoadLevel(LevelToLoad));

        //SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Additive);

        //PreviousLevelTracker = EnvironmentTracker;

        //StoryManager = GameObject.FindGameObjectWithTag("StoryManager");
        //print(StoryManager.GetComponent<StoryManager>().LevelName);
        //StoryManager.GetComponent<StoryManager>().InitialSetUp();

        //GameObject[] storyManagers = GameObject.FindGameObjectsWithTag("StoryManager");



        //storyManagers[] storyManagers = storyManagers[].GetComponent<StoryManager>();


        //SceneManager.LoadScene(StoryManager.GetComponent<StoryManager>().NextScene, LoadSceneMode.Additive);
        //SceneManager.LoadScene(StoryManager.GetComponent<StoryManager>().LastScene, LoadSceneMode.Additive);

        //sceneindex = 0;


    }

    AsyncOperation asyncLoadLevel;

    IEnumerator LoadLevel(string LevelToLoad)
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync(LevelToLoad, LoadSceneMode.Additive);

        while (!asyncLoadLevel.isDone)
        {
            print("Loading the Scene");
            yield return null;

        }

        GameObject[] storyManagers = GameObject.FindGameObjectsWithTag("StoryManager");

        //storyManagers[] storyManagers = storyManagers[].GetComponent<StoryManager>();
        for (int i = 0; i < storyManagers.Length; i++)
        {
            //StoryManagers.Add(storyManagers[i].GetComponent<StoryManager>());
            StoryManager a = storyManagers[i].GetComponent<StoryManager>();
            //print("lvlName");
            //print(a.LevelName);

            if (a.LevelName == LevelToLoad)
            {
                EnvironmentTracker = LevelToLoad;
                //PreviousLevelTracker = EnvironmentTracker;
                StoryManager = a.gameObject;
                //SceneManager.LoadScene(StoryManager.GetComponent<StoryManager>().NextScene, LoadSceneMode.Additive);

                a.InitialSetUp();


            }
        }
    }



    //public void ChapterSkipToTheEnd(String LevelToLoad)
    //{

    //    Resources.UnloadUnusedAssets();
    //    //SceneManager.UnloadSceneAsync(EnvironmentTracker);
    //    //SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Additive);
    //    //Resetting logic for finding the 
    //    sentenceContainerCounter = 0;
    //    sentenceContainerCurrent = 0;
    //    //GameObject TextPositionref;
    //    SpeechBubbleStorage();

    public void GotoNext()
    {
        //sceneindex++;
        //bool isloadingScene;

        string NextScene;
        StoryManager = GameObject.FindGameObjectWithTag("StoryManager");//Find the story manager found in every level
        storyManagerScript = StoryManager.GetComponent<StoryManager>(); //added this

        NextScene = storyManagerScript.NextScene;

        //StoryManager.GetComponent<StoryManager>().CameraRef.transform.position = StoryManager.GetComponent<StoryManager>().OGCameraRefPosition;
        //StoryManager.GetComponent<StoryManager>().isPanningLeft = false; //old stuff- 
        //StoryManager.GetComponent<StoryManager>().isPanningRight = false;//old stuff- 
        //if (sceneindex >= StoryManager.GetComponent<StoryManager>().pagesPerScene) /-- old stuff for when there was more then a page per scene
        //{//If the player is at the last page of the scene

        // = true;
        audioSource.Stop();

            Resources.UnloadUnusedAssets();
            SceneManager.UnloadScene(EnvironmentTracker);

            if (PreviousLevelTracker != EnvironmentTracker && PreviousLevelTracker != "None")
            {
                //Debug.Log(PreviousLevelTracker.ToString());
                SceneManager.UnloadScene(PreviousLevelTracker);
            }

            isGoingBack = false;
            //sceneindex = 0;


            PreviousLevelTracker = EnvironmentTracker;
            //PreviousLevelTracker- previous scene
            //EnvironmentTracker- next scene

            StoryManager = GameObject.FindGameObjectWithTag("StoryManager"); //marked this, why do this again?
            storyManagerScript = StoryManager.GetComponent<StoryManager>(); //added this

        if (storyManagerScript.NextScene != "None")
            {
                SceneManager.LoadScene(storyManagerScript.NextScene, LoadSceneMode.Additive);
            }

            SceneManager.LoadScene(EnvironmentTracker, LoadSceneMode.Additive);
            storyManagerScript.InitialSetUp();



            //Resetting logic for finding the 
            sentenceContainerCounter = 0;
            sentenceContainerCurrent = 0;

        //}
        //else
        //{
        //    StoryManager.GetComponent<StoryManager>().PanRight();
        //}
        SetAudioTrack();
    }

    public void SetUpNewTextFoward()
    {
        //Set Story Variables
        isGoingBack = false;
        isForward = true;
        transform.hasChanged = false;
        //UI Dots
        //UIDots.GetComponent<DotGenerator>().updateDots(sceneindex);

        foreach (SentenceRowContainer Child in sentenceContainer)
        {//Disable all the Text Containers
            if (Child != null)
            Child.gameObject.SetActive(false);
        }

        GameObject[] AnimRef = GameObject.FindGameObjectsWithTag("LoadPageAnim");

        foreach (GameObject child in AnimRef)
        {
            if (child.gameObject.GetComponent<SpriteRenderer>())
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (child.gameObject.GetComponent<Animator>())
            {
                child.gameObject.GetComponent<Animator>().enabled = true;
            }
        }




        for (int i = 0; i < sentenceContainer.Length; i++)
        {//Set all the containers back to null
            sentenceContainer[i] = null;
        }


        sentenceContainerCounter = 0;
        sentenceContainerCurrent = 0;

        //SpeechBubbleStorage();

        NextSentence(isForward);
    }

    public void GotoPrevious()
    {
        //sceneindex--;

        //Debug.Log(sceneindex);
        //bool isloadingScene;

        StoryManager = GameObject.FindGameObjectWithTag("StoryManager");//Find the story manager found in every level
        storyManagerScript = StoryManager.GetComponent<StoryManager>(); //added this

        string LastScene;
        LastScene = storyManagerScript.LastScene;

        //if (sceneindex < 0)
        //{//If the player is at the last page of the scene
            //isloadingScene = true;
            //sceneindex = 0;
            Debug.Log(EnvironmentTracker);

            audioSource.Stop();

            //StoryManager = GameObject.FindGameObjectWithTag("StoryManager"); // marked this- why do this here?
            //storyManagerScript = StoryManager.GetComponent<StoryManager>(); //added this

        Resources.UnloadUnusedAssets();
            //Debug.Log(StoryManager.GetComponent<StoryManager>().NextScene);
            if (storyManagerScript.NextScene != "None")
            {
                SceneManager.UnloadScene(storyManagerScript.NextScene);
            }
            SceneManager.UnloadScene(EnvironmentTracker);

        //print("EnvironmentTracker"+EnvironmentTracker);

        StoryManager = GameObject.FindGameObjectWithTag("StoryManager"); //marked this- why do this here again?
        storyManagerScript = StoryManager.GetComponent<StoryManager>(); //added this

        storyManagerScript.InitialSetUp();

            //Debug.Log(StoryManager.GetComponent<StoryManager>().NextScene);

            if (storyManagerScript.NextScene != "None")
            {
                SceneManager.LoadScene(storyManagerScript.NextScene, LoadSceneMode.Additive);
            }
            if (storyManagerScript.LastScene != "None")
            {
                SceneManager.LoadScene(storyManagerScript.LastScene, LoadSceneMode.Additive);
            }
            PreviousLevelTracker = StoryManager.GetComponent<StoryManager>().LastScene;
        //}
        //else
        //{
            //StoryManager.GetComponent<StoryManager>().PanLeft();
        //}
        SetAudioTrack();
    }

    public void SetUpNewTextBack()
    {
        //Set Story Variables
        isGoingBack = true;
        isForward = false;

        GameObject[] AnimRef = GameObject.FindGameObjectsWithTag("LoadPageAnim");

        foreach (GameObject child in AnimRef)
        {
            if (child.gameObject.GetComponent<SpriteRenderer>())
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            child.gameObject.GetComponent<Animator>().enabled = true;
        }


        for (int i = 0; i < sentenceContainer.Length; i++)
        {//Set all the containers back to null
            sentenceContainer[i] = null;
        }


        sentenceContainerCounter = 0;
        sentenceContainerCurrent = 0;

        //SpeechBubbleStorage();

        PreviousSentence(isGoingBack);

    }

    public void SetAudioTrack()
    {
        //StoryManager.GetComponent<StoryManager>().
        GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");

        if (storyManagerScript.PageSong == Cam.GetComponent<AudioSource>().clip)
        {//if current track is the same as the previous  dont change it

        }
        else
        {
            if (storyManagerScript.PageSong != null)
            {
                Cam.GetComponent<AudioSource>().clip = StoryManager.GetComponent<StoryManager>().PageSong;
                Cam.GetComponent<AudioSource>().volume = StoryManager.GetComponent<StoryManager>().Volume;
                Cam.GetComponent<AudioSource>().Play();
            }
            else
            {
                Cam.GetComponent<AudioSource>().clip = null;
                Cam.GetComponent<AudioSource>().Stop();
            }
        }
        //if (sceneindex == 1 && StoryManager.GetComponent<StoryManager>().PanningPageSong2 != null)
        //{
        //    StoryManager.GetComponent<StoryManager>().PageSong = StoryManager.GetComponent<StoryManager>().PanningPageSong2;
        //    Cam.GetComponent<AudioSource>().clip = StoryManager.GetComponent<StoryManager>().PanningPageSong2;
        //    Cam.GetComponent<AudioSource>().volume = StoryManager.GetComponent<StoryManager>().Volume;
        //    Cam.GetComponent<AudioSource>().Play();
        //}
    }

    //public void SetToLastPosition()
    //{//This function goes through all the dynamic instances in the scene and sets their location to the last memeber of the array

    //    //UIDots.GetComponent<DotGenerator>().updateDots(sceneindex);
    //}

    private void LanguageMenuDeploy()
    {
        GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject text = GameObject.FindGameObjectWithTag("DebugText");
        //Canvas Positions
        Vector3 OGPosition = text.transform.position;
        Vector3 Position = text.transform.position;
        for (int languageCount = 0; languageCount < DataManager.languageManager.Length; languageCount++)
        {
            GameObject LanguageButton = Instantiate(text) as GameObject;
            //Attributes
            LanguageButton.GetComponent<Button>().GetComponentInChildren<Text>().text = DataManager.languageManager[languageCount];
            LanguageButton.GetComponent<Button>().GetComponent<Image>().color = Color.blue;
            LanguageButton.transform.SetParent(Canvas.transform, false);
            Position = new Vector3(Position.x + 100, Position.y, Position.z);
            LanguageButton.transform.position = Position;
            LanguageButton.GetComponent<Button>().onClick.AddListener(() => OnUIButtonClick_Language(LanguageButton.GetComponent<Button>()));
        }
    }

    private void OnUIButtonClick_Language(Button button)
    {//when the player clicks a button
     //Debug.Log("OnUIButtonClick_Language: " + button.gameObject.GetComponentInChildren<Text>().text);
        ChangeLanguage(button.gameObject.GetComponentInChildren<Text>().text);
    }

    private void OnUIButtonClick_Menu(Button button)
    {//when the player clicks a button
        Debug.Log("OnUIButtonClick_Menu: " + button.gameObject.GetComponentInChildren<Text>().text);
        int Page = int.Parse(button.gameObject.GetComponentInChildren<Text>().text);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    public void ChangeLanguage(string newLanguage)
    {
        //print("Before Load");
        StopAllCoroutines();
        audioSource.Stop();
        Resources.UnloadUnusedAssets();
        sentenceContainerCounter = 0;
        sentenceContainerCurrent = 0;

        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.Clear();
        }
        //Debug.Log(newLanguage);

        DataManager.currentLanguage = newLanguage;
        print("data manager language change" + newLanguage);
        //languageChangeWasUpdate();

        DataManager.LoadStory(DataManager.currentStoryName, DataManager.CurrentAssetPackage);
        //PreviousSentence (true);
        AudioObject currentAudio = currentPage.audioObjects[audioIndex];

        WordGroupParser();

        StartCoroutine(RunSequence(currentAudio));
        Debug.Log(audioIndex + "/" + pageIndex);
        //Scenetext.GetComponent<Text> ().text =currentAudio.name;
    }

    //public delegate void LanguageChangeWasUpdate ();     //public static event LanguageChangeWasUpdate OnLanguageChangeWasUpdate;      //void languageChangeWasUpdate()     //{     //    if (OnLanguageChangeWasUpdate != null)     //    {     //        OnLanguageChangeWasUpdate();     //    }     //} 
    public void KillCurrentCoroutines()
    {
        //isMenuDeployed = true;
        StopAllCoroutines();
        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.Clear();
        }
    }

    public void ReactivateCurrentCoroutine()
    {
        //isMenuDeployed = false;
        StopAllCoroutines();
        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.Clear();
        }
        sentenceContainerCounter = 0;
        sentenceContainerCurrent = 0;

        WordGroupParser();

        StartCoroutine(RunSequence(currentPage.audioObjects[audioIndex]));
    }

    public void GoToPage(int i)
    {
        StopAllCoroutines();
        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.Clear();
        }
        audioIndex = i;
        WordGroupParser();
        StartCoroutine(RunSequence(currentPage.audioObjects[audioIndex]));
    }

    void PreviousSentence(bool playFromLast)
    {//Turn off the current passage and prep for the next passage
        StopAllCoroutines();
        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.Clear();
        }
        if (pageIndex >= currentStory.pageObjects.Count)
        {//when the player reaches the end of the narrative
            Debug.Log("Story ended! Back to menu...");
            //SceneManager.LoadScene("Menu");
            return;
        }

        AudioObject currentAudio = currentPage.audioObjects[audioIndex];

        PlayPreviousSentence();

    }

    void PlayPreviousSentence()
    {

        if (audioIndex > 0)
        {//reduce the passage book mark
            audioIndex--;
        }
        AudioObject currentAudio = currentPage.audioObjects[audioIndex];
        WordGroupParser();
        StartCoroutine(RunSequence(currentAudio));

    }


    void NextSentence(bool playFromLast)
    {//Move the narrative forward
     //Debug.Log("working");
        StopAllCoroutines();
        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.Clear();
        }
        if (pageIndex >= currentStory.pageObjects.Count)
        {//when the player reaches the end of the narrative
            Debug.Log("Story ended! Back to menu...");
            //SceneManager.LoadScene("Menu");
            return;
        }

        AudioObject currentAudio = currentPage.audioObjects[audioIndex];


        PlayCurrentSentence();
        if (playFromLast == false)
        {
            NextSentence(true);
        }
    }


    void PlayCurrentSentence()
    {
        audioIndex++;
        AudioObject currentAudio = currentPage.audioObjects[audioIndex];
        WordGroupParser();
        StartCoroutine(RunSequence(currentAudio));
    }

    IEnumerator RunSequence(AudioObject obj)
    {
        //.Log(obj.clip);

        //if(audioIndex == 0)\
        if (audioIndex == 0)
        {
            BackButton.GetComponent<Image>().enabled = false;
        }
        else
        {
            BackButton.GetComponent<Image>().enabled = true;
        }

        //if (audioIndex == 38)
        if (audioIndex == 38)
        {
            //NextButton.GetComponent<Image>().enabled = false;
        }
        else
        {
           // NextButton.GetComponent<Image>().enabled = true;
        }

        AudioObject currentAudio = currentPage.audioObjects[audioIndex];
        Scenetext.GetComponent<Text>().text = currentAudio.name;


        if (obj.clip != null)
        {
            audioSource.clip = obj.clip;
            audioSource.Play();
        }

        //highlight the proper wordgroups
        int i = 0;
        WordGroupObject prevWordGroup = null;
        while (i < obj.sentence.wordGroups.Count)
        {
            WordGroupObject wordGroup = obj.sentence.wordGroups[i];
            foreach (SentenceRowContainer Child in sentenceContainer)
            {
                if (Child != null)
                {
                    Child.HighlightWordGroup(wordGroup);
                }
            }

            float waitTime = wordGroup.time;

            if (audioIndex == 13 && i == 0)
            {

                WordGroupObject wordGroupnext = obj.sentence.wordGroups[i + 1];
                waitTime = wordGroupnext.time - wordGroup.time;

            }

            //We calculate it like this because the times given are actually absolute times, not times per word

            if (prevWordGroup != null && i > 1)
            {
                if (i == obj.sentence.wordGroups.Count - 1)
                {
                    waitTime = obj.clip.length - wordGroup.time;
                }
                else
                {
                    waitTime -= prevWordGroup.time;
                }

            }

            if (audioIndex == 37 && StoryManager.GetComponent<StoryManager>().pagesPerScene == 1)
            {
                waitTime = 4.0f;
            }
            i++;
            yield return new WaitForSeconds(waitTime);
            if (audioIndex == 36 && StoryManager.GetComponent<StoryManager>().pagesPerScene == 2)
            {
                NextButton.SetActive(true);
                BackButton.SetActive(true);
                isAutoChapterSkip = 0;
            }
            prevWordGroup = wordGroup;
        }
        //EffectedRow.HighlightWordGroup(null);


        //Debug.Log("PointReached");
        //sentenceContainer.HighlightWordGroup(null);
        foreach (SentenceRowContainer Child in sentenceContainer)
        {
            if (Child != null)
                Child.HighlightWordGroup(null);
        }

        if (isAutoChapterSkip == 0)
        {

            //audioSource.clip = PageDone;
            //audioSource.Play ();
        }

        if (isAutoChapterSkip == 1 && audioIndex != 38)
        {

            GotoNext();
        }
    }

    public static List<T> FindObjectsOfTypeAll<T>()
    {
        List<T> results = new List<T>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var s = SceneManager.GetSceneAt(i);
            if (s.isLoaded)
            {
                var allGameObjects = s.GetRootGameObjects();
                for (int j = 0; j < allGameObjects.Length; j++)
                {
                    var go = allGameObjects[j];
                    results.AddRange(go.GetComponentsInChildren<T>(true));
                }
            }
        }
        return results;
    }

    public void ChangeMusic(Slider newMusicVolume)
    {
        Debug.Log("newMusicVolume" + newMusicVolume.value);
        audioSource.volume = newMusicVolume.value;
    }

    public void ChangeNarrative(Slider newNarrativeVolume)
    {
        Debug.Log("newNarrativeVolume" + newNarrativeVolume.value);
        audioSource.volume = newNarrativeVolume.value;
        IsReadingAlong = newNarrativeVolume.value;
        if (newNarrativeVolume.value == 0.0f)
        {
            NextButton.SetActive(true);
            BackButton.SetActive(true);
        }
    }

    public void ChangeTextStyle(Slider newTextStyle)
    {
        Debug.Log("newTextStyle" + newTextStyle.value);
        isAutoChapterSkip = newTextStyle.value;
        if (newTextStyle.value == 1.0f)
        {
            NextButton.SetActive(false);
            BackButton.SetActive(false);
        }
        else
        {
            NextButton.SetActive(true);
            BackButton.SetActive(true);
        }


    }

    //public void SpeechBubbleStorage()
    //{
    //    Debug.Log("Passing through here");
    //    foreach (Transform child in StoryManager.GetComponent<StoryManager>().TextPositions[sceneindex].transform)
    //    {
            
    //        // do whatever you want with child transform object here
    //        if (child.gameObject.tag == "TextPlacement")
    //        {
    //            sentenceContainer[sentenceContainerCounter] = child.gameObject.GetComponent<SentenceRowContainer>(); ;
    //            sentenceContainerCounter++;
    //            TextPositionref = child.gameObject;//GameObject.FindWithTag("TextPlacement"); 
    //            //Debug.Log("Working");
    //        }

    //        if (child.gameObject.tag == "SpeechBubble")
    //        {

    //            foreach (Transform Kiddo in child)
    //            {
    //                // do whatever you want with child transform object here
    //                if (Kiddo.gameObject.tag == "TextPlacement")
    //                {
    //                    sentenceContainer[sentenceContainerCounter] = Kiddo.gameObject.GetComponent<SentenceRowContainer>(); ;
    //                    sentenceContainerCounter++;
    //                    TextPositionref = Kiddo.gameObject;//GameObject.FindWithTag("TextPlacement"); 
    //                                                       //Debug.Log("Working");
    //                }
    //            }
    //        }

    //    }

    //}

    public void WordGroupParser()
    {

        print("Number of words" + currentPage.audioObjects[audioIndex].sentence.wordGroups.Count);
        //Debug.Log(currentPage.audioObjects[audioIndex].sentence.wordGroups.ToString());

        foreach (WordGroupObject wordGroup in currentPage.audioObjects[audioIndex].sentence.wordGroups)
        {

            //Debug.Log(wordGroup.text);

            if (wordGroup.text.Contains("speaker"))
            {//Get The Narrator
            print("1");

                Speaker = wordGroup.text;
                Speaker = Speaker.Remove(0, 10);
                Debug.Log(Speaker);

                //sentenceContainer[sentenceContainerCurrent].AddText(wordGroup); //added 
            }
            else if (wordGroup.text.Contains("///"))
            {//Get The Narrator
                            print("2");

                sentenceContainerCurrent += 1;
                /*
                if (sentenceContainer[sentenceContainerCurrent].GetComponentInParent<SpeechBubbleDelay>())
                {
                    sentenceContainer[sentenceContainerCurrent].GetComponentInParent<SpeechBubbleDelay>().Acvivate_SpeechBuggle(PreviousWordTime);
                //}*/
            }
            else
            {
            print("3");

                // PreviousWordTime = wordGroup.time;
                //print("Number of words" + currentPage.audioObjects[audioIndex].sentence.wordGroups.Count);
                sentenceContainer[sentenceContainerCurrent].AddText(wordGroup);
            }
        }
    }

    public void changeClickDragFunctionality(bool state)
    {
        CanSwipe = state;
    }

    public void chapter3MenuFix()
    {

        isChapter3LoadedFromMenu = true;

    }

}