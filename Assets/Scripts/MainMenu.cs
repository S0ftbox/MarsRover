using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject startPos, finishPos, blackPanel, hitSpaceText, Rover;
    public GameObject playButton, optionsButton, quitButton, levels, titlePanel, optionsPanel;
    public GameObject resText, resDrop, volText, volSlide, resetButton, acceptButton;
    public Text titleText, softboxText;
    public Button[] levelButtons;
    public Text[] buttonTexts;
    public Text[] levelSections;
    public PanelRendererMenu menuRender;
    public bool isTitleScreen;
    bool isLevelListVisible;
    public static bool isRestarted = false;
    Vector3 finishTransform, roverTransform;
    int savedLevel, resolution;
    float w, h, musicVolume;

    void Awake()
    {
        Time.timeScale = 1;
        resolution = PlayerPrefs.GetInt("Resolution");
        if(resolution > 2)
        {
            titleText.fontSize = 100;
        }
        else
        {
            titleText.fontSize = 70;
        }
        w = Screen.width * 2 / 3;
        h = Screen.height / 3;
        blackPanel.GetComponent<Image>().CrossFadeAlpha(0, 3, false);
        isTitleScreen = true;
        savedLevel = PlayerPrefs.GetInt("FinishedLevels");
        finishTransform = finishPos.transform.position;
        roverTransform = Rover.transform.position;
        playButton.GetComponent<Button>().onClick.AddListener(Play);
        optionsButton.GetComponent<Button>().onClick.AddListener(Options);
        quitButton.GetComponent<Button>().onClick.AddListener(Quit);

        optionsPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
        resText.GetComponent<RectTransform>().localPosition = new Vector3(-w / 5, h * 3 / 8, 0);
        resDrop.GetComponent<RectTransform>().localPosition = new Vector3(w / 5, h * 3 / 8, 0);
        volText.GetComponent<RectTransform>().localPosition = new Vector3(-w / 5, h / 8, 0);
        volSlide.GetComponent<RectTransform>().localPosition = new Vector3(w / 5, h / 8, 0);
        resetButton.GetComponent<RectTransform>().localPosition = new Vector3(0, -h / 8, 0);
        acceptButton.GetComponent<RectTransform>().localPosition = new Vector3(0, -h * 3 / 8, 0);
        softboxText.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 4 / 15, Screen.height / 8);
        softboxText.GetComponent<RectTransform>().localPosition = new Vector3(-Screen.width / 3, -Screen.height * 7 / 16, 0);
        softboxText.fontSize = Screen.height / 25;
        
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = musicVolume;

        foreach(Text buttonText in buttonTexts)
        {
            buttonText.fontSize = Screen.height / 18;
        }

        foreach(Text selector in levelSections)
        {
            selector.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 4 / 15, Screen.height / 4);
            selector.GetComponent<RectTransform>().localPosition = new Vector3(-Screen.width / 3, 0, 0);
            selector.fontSize = Screen.height / 17;
        }

        foreach (Button button in levelButtons)
        {
            RectTransform buttonRect = button.GetComponent<RectTransform>();
            buttonRect.sizeDelta = new Vector2(Screen.width / 7, Screen.height / 6);
            button.interactable = false;
        }
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(savedLevel >= i)
            {
                levelButtons[i].interactable = true;
            }
        }
        for(int i = 0; i < levelButtons.Length; i += 4)
        {
            levelButtons[i].GetComponent<RectTransform>().localPosition = new Vector3(-Screen.width / 12, 0, 0);
            levelButtons[i+1].GetComponent<RectTransform>().localPosition = new Vector3(Screen.width / 12, 0, 0);
            levelButtons[i+2].GetComponent<RectTransform>().localPosition = new Vector3(Screen.width / 4, 0, 0);
            levelButtons[i+3].GetComponent<RectTransform>().localPosition = new Vector3(Screen.width * 5 / 12, 0, 0);
        }
        levelButtons[0].onClick.AddListener(Play1);
        levelButtons[1].onClick.AddListener(Play2);
        levelButtons[2].onClick.AddListener(Play3);
        levelButtons[3].onClick.AddListener(Play4);
        levelButtons[4].onClick.AddListener(Play5);
        levelButtons[5].onClick.AddListener(Play6);
        levelButtons[6].onClick.AddListener(Play7);
        levelButtons[7].onClick.AddListener(Play8);
        levelButtons[8].onClick.AddListener(Play9);
        levelButtons[9].onClick.AddListener(Play10);
        levelButtons[10].onClick.AddListener(Play11);
        levelButtons[11].onClick.AddListener(Play12);
        levelButtons[12].onClick.AddListener(Play13);
        levelButtons[13].onClick.AddListener(Play14);
        levelButtons[14].onClick.AddListener(Play15);
        levelButtons[15].onClick.AddListener(Play16);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTitleScreen == true)
        {
            isTitleScreen = false;
            StartCoroutine(RoverMove());
            blackPanel.SetActive(false);
            hitSpaceText.SetActive(false);
            playButton.SetActive(true);
            optionsButton.SetActive(true);
            quitButton.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && isLevelListVisible == true)
        {
            titlePanel.SetActive(true);
            levels.SetActive(false);
            isLevelListVisible = false;
        }
    }

    void Play()
    {
        levels.SetActive(true);
        titlePanel.SetActive(false);
        isLevelListVisible = true;
    }

    void Options()
    {
        optionsPanel.SetActive(true);
        titlePanel.SetActive(false);
    }

    void Quit()
    {
        Application.Quit();
    }

    void Play1()
    {
        SceneManager.LoadScene(1);
    }
    void Play2()
    {
        SceneManager.LoadScene(2);
    }
    void Play3()
    {
        SceneManager.LoadScene(3);
    }
    void Play4()
    {
        SceneManager.LoadScene(4);
    }
    void Play5()
    {
        SceneManager.LoadScene(5);
    }
    void Play6()
    {
        SceneManager.LoadScene(6);
    }
    void Play7()
    {
        SceneManager.LoadScene(7);
    }
    void Play8()
    {
        SceneManager.LoadScene(8);
    }
    void Play9()
    {
        SceneManager.LoadScene(9);
    }
    void Play10()
    {
        SceneManager.LoadScene(10);
    }
    void Play11()
    {
        SceneManager.LoadScene(11);
    }
    void Play12()
    {
        SceneManager.LoadScene(12);
    }
    void Play13()
    {
        SceneManager.LoadScene(13);
    }
    void Play14()
    {
        SceneManager.LoadScene(14);
    }
    void Play15()
    {
        SceneManager.LoadScene(15);
    }
    void Play16()
    {
        SceneManager.LoadScene(16);
    }

    public IEnumerator RoverMove()
    {
        Vector3 targetPos = finishPos.transform.position;
        while ((Rover.transform.position.x != targetPos.x) && (Rover.transform.position.z != targetPos.z))
        {
            Rover.transform.position = Vector3.MoveTowards(Rover.transform.position, targetPos, 0.75f * Time.deltaTime);
            yield return null;
        }
    }
}
