using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    public Dropdown resolution;
    public MainMenu main;
    public int savedRes;

    void Start()
    {
        resolution = GetComponent<Dropdown>();
        savedRes = PlayerPrefs.GetInt("Resolution");
        resolution.value = savedRes;
        resolution.onValueChanged.AddListener(delegate { SelectResolution(resolution.value); });
    }

    void SelectResolution(int value)
    {
        switch (value){
            case 0:
                Screen.SetResolution(1024, 768, true);
                PlayerPrefs.SetInt("Resolution", 0);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                PlayerPrefs.SetInt("Resolution", 1);
                break;
            case 2:
                Screen.SetResolution(1280, 768, true);
                PlayerPrefs.SetInt("Resolution", 2);
                break;
            case 3:
                Screen.SetResolution(1280, 960, true);
                PlayerPrefs.SetInt("Resolution", 3);
                break;
            case 4:
                Screen.SetResolution(1366, 768, true);
                PlayerPrefs.SetInt("Resolution", 4);
                break;
            case 5:
                Screen.SetResolution(1600, 900, true);
                PlayerPrefs.SetInt("Resolution", 5);
                break;
            case 6:
                Screen.SetResolution(1920, 1080, true);
                PlayerPrefs.SetInt("Resolution", 6);
                break;
        }
    }
}
