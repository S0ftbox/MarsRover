using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMusic : MonoBehaviour
{
    public AudioListener audioListener;
    public Slider slider;
    float musicVolume;

    void Start()
    {
        audioListener = GetComponent<AudioListener>();
        slider = GetComponent<Slider>();
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        slider.value = musicVolume;
        slider.onValueChanged.AddListener(delegate { changeValue(); });
    }

    void changeValue()
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }
}
