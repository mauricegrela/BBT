using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StoryManager : MonoBehaviour {

	public int AudioIndexPosition; 
	public string LevelName;
	public int pagesPerScene;
	public string NextScene;
	public string LastScene;
	public bool isLastscene;
	public bool isFirstscene;
	public bool isLoadingLevel;
	public int StreamingAssetsCounter;
	public GameObject PageManager;
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
    public bool isPanningLeft = false;
    public bool isPanningRight = false;
    private float PanningCounter;
    private Transform panningtargetPosition;
    private int CurrentPage;

    [SerializeField]
    private GameObject Page37Panning;

    public AudioClip PageSong;
    public AudioClip PanningPageSong2;
    public float Volume = 0.2f;
    //
    private Vector3 DistanceCounter;

    private void Awake()
    {
        DefenitionPage = GameObject.FindGameObjectWithTag("Definition");//Find the story manager found in every level
        //DefenitionPage.SetActive(true);

        PageManager = GameObject.FindGameObjectWithTag("PageManager");
        if(PageManager.GetComponent<PageManager>().isLoading==true)
        {
            InitialSetUp();
            PageManager.GetComponent<PageManager>().isLoading = false;
            PageManager.GetComponent<PageManager>().StoryManager = gameObject;
            SceneManager.LoadScene(NextScene, LoadSceneMode.Additive);
                if(LastScene != "None")
                {
                    SceneManager.LoadScene(LastScene, LoadSceneMode.Additive);       
                }
            PageManager.GetComponent<PageManager>().PreviousLevelTracker = LastScene;

        }

        if(PageManager.GetComponent<PageManager>().isChapter3LoadedFromMenu == true)
        {
            GameObject Sound = GameObject.FindGameObjectWithTag("16_ThrusterSound");
            if (Sound != null)
            {
                Sound.GetComponent<AudioSource>().Play();
            }
            GameObject Fade = GameObject.FindGameObjectWithTag("16_PageFadeIn");
            if (Fade != null)
            {
                Fade.GetComponent<ImageFadeOut>().StartCo();
            }
            PageManager.GetComponent<PageManager>().isChapter3LoadedFromMenu = false;
        }
    }

    public void InitialSetUp()///Awake()
    {
        PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
        CameraRef = GameObject.FindGameObjectWithTag("MainCamera");
        OGCameraRefPosition = CameraRef.transform.position;
        TextPositions = new GameObject[transform.childCount];
        pagesPerScene = transform.childCount;
        for (int i = 0; i < transform.childCount; i++)
        {//Store all the pages
            TextPositions[i] = transform.GetChild(i).gameObject;
            //Debug.Log(transform.GetChild(i).name);
        }
        PageManager = GameObject.FindGameObjectWithTag("PageManager");


        PageManager.GetComponent<PageManager>().sentenceContainerCounter = 0;
        PageManager.GetComponent<PageManager>().sentenceContainerCurrent = 0;

        foreach (GameObject child in TextPositions)
        {//Store the First of the Text References                 
            child.SetActive(false);
        }

        int position;

        if(PageManager.GetComponent<PageManager>().isGoingBack == true)
        {
        TextPositions[TextPositions.Length - 1].SetActive(true);
        position = TextPositions.Length - 1;
        }
            else
            {
            TextPositions[0].SetActive(true);
            position = 0;
            }

        foreach (Transform child in TextPositions[position].transform)
        {//Store the First of the Text References 
            
            if (child.gameObject.tag == "TextPlacement")
            {
                PageManager.GetComponent<PageManager>().
                sentenceContainer[PageManager.GetComponent<PageManager>().sentenceContainerCounter] 
                = child.gameObject.GetComponent<SentenceRowContainer>();
                
                PageManager.GetComponent<PageManager>().sentenceContainerCounter++;

                //InitialTextPosition = child.gameObject;//GameObject.FindWithTag("TextPlacement"); 
                //Debug.Log("Working");
            }


        }


        //Set references 
       
        //PageManager.GetComponent<PageManager>().sentenceContainer[0] = InitialTextPosition.GetComponent<SentenceRowContainer>();

        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<Image>().enabled = true;
        if (isLoadingLevel == true && PageManager.GetComponent<PageManager>().isIniAudioLoaded == false)
        {//If this is going to load a different streaming package, load it here. 
            PageManager.GetComponent<PageManager>().audioIndex = 0;
            PageManager.GetComponent<PageManager>().isIniAudioLoaded = true;
            DataManager.LoadStory(DataManager.currentStoryName, StreamingAssetsCounter.ToString());
        }
        else if (StreamingAssetsCounter.ToString() != DataManager.CurrentAssetPackage.ToString())
        {//this condition will trigger when the player loads a level from the menu that requires a streaming asset that is not currently loaded.
            //DataManager.LoadStory(DataManager.currentStoryName, StreamingAssetsCounter.ToString());
        }

        CoroutineLoad();
        //SceneManager.SetActiveScene(NextScene)
    }

	// Use this for initialization
	public void CoroutineLoad()//Start () 
    {
		for(int i = 0; i < Canvas.transform.childCount; i++)
		{//This loop generates the book mark dots 
			if (Canvas.transform.GetChild (i).name == "UI Dots") {
				Canvas.transform.GetChild (i).GetComponent<DotGenerator> ().GenrateTheDots (pagesPerScene);
			}
		}

		if (PageManager.GetComponent<PageManager> ().isGoingBack == false) 
        {
        PageManager.GetComponent<PageManager>().AssetAssigner(LevelName, AudioIndexPosition);
        PageManager.GetComponent<PageManager>().GoToPage(AudioIndexPosition);
        PageManager.GetComponent<PageManager>().ChapterskipSetCharacters(0);
        PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
        GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
        if (AnimRef != null)
            AnimRef.GetComponent<Animator>().enabled = true;

        GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
        if (AnimatedObject != null)
            AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();
		} 
			else 
			{//If the player is going backwards
            PageManager.GetComponent<PageManager>().AssetAssigner(LevelName, AudioIndexPosition);
            PageManager.GetComponent<PageManager>().GoToPage(AudioIndexPosition);
            PageManager.GetComponent<PageManager>().ChapterskipSetCharacters(0);
            PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
            GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
            if (AnimRef != null)
                AnimRef.GetComponent<Animator>().enabled = true;

            GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
            if (AnimatedObject != null)
                AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();
            //coroutine = WaitGoingBack(0.0f);
            //StartCoroutine(coroutine);
			}

	}

    private IEnumerator WaitGoingBack(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (Counter == 0)
            {
                PageManager.GetComponent<PageManager>().AssetAssigner(LevelName, pagesPerScene - 1);
            }
            else if (Counter == 1)
            {
                
            }
            else if (Counter == 2)
            {
                PageManager.GetComponent<PageManager>().SetToLastPosition();
                PageManager.GetComponent<PageManager>().GetComponent<PageManager>().GoToPage(AudioIndexPosition + pagesPerScene - 1);
                PageManager.GetComponent<PageManager>().isGoingBack = false;

                PageManager.GetComponent<PageManager>().isGoingBack = false;
                PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
                GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
                if (AnimRef != null)
                AnimRef.GetComponent<Animator>().enabled = true;

                GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
                if (AnimatedObject != null)
                    AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();

                StopCoroutine(coroutine);
            }
            else
            {

                print("error");
            }
            Counter++;
        }
    }

    private IEnumerator WaitGoingForward(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (Counter == 0)
            {
                PageManager.GetComponent<PageManager> ().AssetAssigner (LevelName, AudioIndexPosition);
                PageManager.GetComponent<PageManager>().GoToPage(AudioIndexPosition);
                PageManager.GetComponent<PageManager>().ChapterskipSetCharacters(0);
                PageManager.GetComponent<PageManager>().LoadingScreen.GetComponent<LoadingScript>().VisualToggle(false);
                GameObject AnimRef = GameObject.FindGameObjectWithTag("LoadPageAnim");
                if (AnimRef != null)
                    AnimRef.GetComponent<Animator>().enabled = true;

                GameObject AnimatedObject = GameObject.FindGameObjectWithTag("AnimTurnOff");
                if (AnimatedObject != null)
                    AnimatedObject.GetComponent<AnimationTurnOff>().ActivateCountDown();

                StopCoroutine(coroutine);
            }
            else if (Counter == 1)
            {
                
            }
            else if (Counter == 2)
            {

            }
            else
            {

                print("error");
            }
            Counter++;
        }
    }

    public void PanRight()
    {

//        Debug.Log("Working");

        isPanningRight = true;
        CurrentPage = PageManager.GetComponent<PageManager>().sceneindex;
        CameraRef.transform.position = OGCameraRefPosition;
        if (TextPositions[CurrentPage].tag == "panning")
        {
            //Debug.Log("This is a specific panning script.");
            TextPositions[CurrentPage].SetActive(true);
            foreach (Transform child in TextPositions[CurrentPage].transform)
            {//Store the First of the Text References 

                if (child.gameObject.tag == "panning target")
                {
                    panningtargetPosition = child.gameObject.transform;
                }

            }
        }
            else
            {
                foreach (GameObject child in TextPositions)
                {//Store the First of the Text References                 
                    child.SetActive(false);
                }

                TextPositions[CurrentPage].SetActive(true);

                isPanningRight = false;
                PageManager.GetComponent<PageManager>().SetUpNewTextFoward(); 

                 //Debug.Log("Working?" + PageManager.GetComponent<PageManager>().audioIndex);
            if (PageManager.GetComponent<PageManager>().audioIndex == 37)
                {
                    
                    Page37Panning.GetComponent<Accelerometer_PageMoveDown>().StartPushDown();
                    //Debug.Log("Working");
                    //CameraRef.GetComponent<Camera_MouseMovement>().enabled = true;
                    //CameraRef.GetComponent<Accelerometer_SkyBox>().enabled = true;

                }
                   


            if (PageManager.GetComponent<PageManager>().audioIndex == 38)
                {

                CameraRef.GetComponent<Accelerometer_SkyBox>().StoryBook.GetComponent<Accelerometer_PageMoveDown>().Reset();
                    Debug.Log("Working?" + PageManager.GetComponent<PageManager>().audioIndex);
                    //CameraRef.GetComponent<CameraRef_MouseMovement>().enabled = false;
                    //CameraRef.GetComponent<Accelerometer_SkyBox>().enabled = false;
                    CameraRef.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }
    }

    public void PanLeft()
    {
        isPanningLeft = true;
        CameraRef.transform.position = OGCameraRefPosition;
    }

	// Update is called once per frame
	void Update () {
        
        if(isPanningRight == true && isPanningLeft == false)
        {
            float dist = Vector3.Distance(CameraRef.transform.position, panningtargetPosition.position);
            if (dist >= 0.1)
            {
                //CameraRef.transform.Translate(Vector3.right * (Time.deltaTime*2), Space.World);
                float step = 6 * Time.deltaTime;

                // Move our position a step closer to the target.
                CameraRef.transform.position = Vector3.MoveTowards(CameraRef.transform.position, panningtargetPosition.position, step);
            }
                else
                {
                    foreach (GameObject child in TextPositions)
                    {//Store the First of the Text References                 
                        child.SetActive(false);
                    }

                TextPositions[CurrentPage].SetActive(true);

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
                isPanningRight = false;
                PageManager.GetComponent<PageManager>().SetUpNewTextFoward();
                }
        }


        if (isPanningRight == false && isPanningLeft == true)
        {
            foreach (GameObject child in TextPositions)
            {//Store the First of the Text References                 
                child.SetActive(false);
            }
            CurrentPage = PageManager.GetComponent<PageManager>().sceneindex;

            TextPositions[CurrentPage].SetActive(true);
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
            isPanningLeft = false;
            PageManager.GetComponent<PageManager>().SetUpNewTextBack();

        }
	}

    public void SetToFinal()
    {
        Debug.Log("SET TO FINAL");
        foreach (GameObject child in TextPositions)
        {//Store the First of the Text References                 
            child.SetActive(false);
        }
        int CurrentPage = PageManager.GetComponent<PageManager>().sceneindex;
        TextPositions[CurrentPage].SetActive(true);  
    }
}
