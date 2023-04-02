using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRendererMenu : MonoBehaviour
{
    public GameObject title, spacebarText, playButton, optionsButton, quitButton, earth, moon, marsDay, marsNight;
    static float width = Screen.width;
    static float height = Screen.height;
    public float titlepos = width / 6;
    float spacebarPos = height / 2;

    void Start()
    {
        RectTransform titleRect = title.GetComponent<RectTransform>();
        titleRect.localPosition = new Vector3(width / 5, 0, 0);

        RectTransform spacebarRect = spacebarText.GetComponent<RectTransform>();
        spacebarRect.localPosition = new Vector3(0, - spacebarPos + 50, 0);

        RectTransform playRect = playButton.GetComponent<RectTransform>();
        playRect.localPosition = new Vector3(-width / 5, 100, 0);

        RectTransform optionsRect = optionsButton.GetComponent<RectTransform>();
        optionsRect.localPosition = new Vector3(-width / 5, 0, 0);

        RectTransform quitRect = quitButton.GetComponent<RectTransform>();
        quitRect.localPosition = new Vector3(-width / 5, -100, 0);

        RectTransform earthRect = earth.GetComponent<RectTransform>();
        earthRect.sizeDelta = new Vector2(width, height / 4);
        earthRect.localPosition = new Vector3(0, spacebarPos - (height / 8), 0);

        RectTransform moonRect = moon.GetComponent<RectTransform>();
        moonRect.sizeDelta = new Vector2(width, height / 4);
        moonRect.localPosition = new Vector3(0, height / 8, 0);

        RectTransform marsDayRect = marsDay.GetComponent<RectTransform>();
        marsDayRect.sizeDelta = new Vector2(width, height / 4);
        marsDayRect.localPosition = new Vector3(0, -(height / 8), 0);

        RectTransform marsNightRect = marsNight.GetComponent<RectTransform>();
        marsNightRect.sizeDelta = new Vector2(width, height / 4);
        marsNightRect.localPosition = new Vector3(0, -(spacebarPos - (height / 8)), 0);
    }
}
