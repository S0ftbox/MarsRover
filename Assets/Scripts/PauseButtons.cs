using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public GameObject mainMenuButton, continueButton, pausePanel;
    public Level level;

    void Start()
    {
        mainMenuButton.GetComponent<Button>().onClick.AddListener(BackToMenu);
        continueButton.GetComponent<Button>().onClick.AddListener(ContinueLevel);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("move", 1);
    }

    void ContinueLevel()
    {
        level.isGamePaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
