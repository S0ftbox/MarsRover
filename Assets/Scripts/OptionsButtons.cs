using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsButtons : MonoBehaviour
{
    public GameObject resetButton, acceptButton;
    public MainMenu menu;

    void Start()
    {
        resetButton.GetComponent<Button>().onClick.AddListener(ResetProgress);
        acceptButton.GetComponent<Button>().onClick.AddListener(AcceptOptions);
    }

    void ResetProgress()
    {
        PlayerPrefs.SetInt("FinishedLevels", 0);
        PlayerPrefs.SetInt("analysis", 0);
        PlayerPrefs.SetInt("rockAnalysis", 0);
        PlayerPrefs.SetFloat("distance", 0);
    }

    void AcceptOptions()
    {
        SceneManager.LoadScene(0);
    }
}
