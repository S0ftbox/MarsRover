using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Commands commands;
    public PanelRenderer panelRenderer;
    public TextInputRead distanceRead;
    public GameObject text;
    public GameObject ambience;
    public Text finishText;
    bool canNextLevel = false;
    public bool isGamePaused;
    string start, finish, levelName;
    int activeLevel, savedLevel, globalAnalysis, globalRockAnalysis;
    float globalDistance;

    void Start()
    {
        Time.timeScale = 1;
        activeLevel = SceneManager.GetActiveScene().buildIndex;
        Scene scene = SceneManager.GetActiveScene();
        levelName = scene.name;
        start = "Level " + levelName;
        finish = "Level finished!";
        finishText.text = start;
        finishText.CrossFadeAlpha(0, 3, false);
        savedLevel = PlayerPrefs.GetInt("FinishedLevels");
        if (activeLevel < 9)
        {
            RenderSettings.fog = false;
        }
        globalAnalysis = PlayerPrefs.GetInt("analysis");
        globalRockAnalysis = PlayerPrefs.GetInt("rockAnalysis");
        globalDistance = PlayerPrefs.GetFloat("distance");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;
            if(SceneManager.GetActiveScene().buildIndex < 5 || SceneManager.GetActiveScene().buildIndex > 8)
            {
                ambience.GetComponent<AudioSource>().Pause();
            }
            panelRenderer.pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            if (SceneManager.GetActiveScene().buildIndex < 5 || SceneManager.GetActiveScene().buildIndex > 8)
            {
                ambience.GetComponent<AudioSource>().Play();
            }
            panelRenderer.pauseMenu.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        commands.isFinish = true;
        text.SetActive(true);
        finishText.text = finish;
    }

    void OnTriggerStay(Collider collider)
    {
        if (!commands.doingCoroutine && commands.isFinish)
        {
            panelRenderer.panel.SetActive(false);
            finishText.CrossFadeAlpha(1, 3, false);
            canNextLevel = true;
            globalAnalysis += commands.howManyAnalysis;
            globalRockAnalysis += commands.stoneAnalysis;
            globalDistance += distanceRead.distance;
            PlayerPrefs.SetInt("analysis", globalAnalysis);
            PlayerPrefs.SetInt("rockAnalysis", globalRockAnalysis);
            PlayerPrefs.SetFloat("distance", globalDistance);
        }
        if(canNextLevel && Input.GetKeyDown(KeyCode.Return))
        {
            if (activeLevel >= savedLevel)
            {
                PlayerPrefs.SetInt("FinishedLevels", activeLevel);
            }
            if(activeLevel < 16)
            {
                SceneManager.LoadScene(activeLevel + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
