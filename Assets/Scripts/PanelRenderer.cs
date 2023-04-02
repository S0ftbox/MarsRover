using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRenderer : MonoBehaviour
{
    public GameObject panel, textInput, textOutput, textInputField, textOutputField, finishText, pauseMenu, pauseText, volumeText, volumeSlider, mainMenuButt, continueButt;
    static float width = Screen.width;
    static float height = Screen.height;
    float panelPosX = width / 2;
    float panelSizeX = width / 3;
    float textInputPosY = height / 2;
    float textInputSizeY = 50;
    float textOutputPosY, textOutputSizeY, textInputFieldSizeX, textOutputFieldSizeY;
    float pauseSizeX = width * 2 / 3;
    float pauseSizeY = height / 3;
    // Start is called before the first frame update
    void Start()
    {
        panelPosX -= panelSizeX / 2;
        panelPosX *= -1;
        textInputPosY -= textInputSizeY / 2;
        textInputPosY *= -1;
        textOutputSizeY = height - textInputSizeY;
        textOutputPosY = textInputSizeY / 2;
        textInputFieldSizeX = panelSizeX - 20;
        textOutputFieldSizeY = textOutputSizeY - 20;

        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        panelRectTransform.sizeDelta = new Vector2(panelSizeX, height);
        panelRectTransform.localPosition = new Vector3(panelPosX, 0, 0);

        RectTransform textInputRectTransform = textInput.GetComponent<RectTransform>();
        textInputRectTransform.sizeDelta = new Vector2(panelSizeX, textInputSizeY);
        textInputRectTransform.localPosition = new Vector3(0, textInputPosY, 0);

        RectTransform textOutputRectTransform = textOutput.GetComponent<RectTransform>();
        textOutputRectTransform.sizeDelta = new Vector2(panelSizeX, textOutputSizeY);
        textOutputRectTransform.localPosition = new Vector3(0, textOutputPosY, 0);

        RectTransform textInputFieldRectTransform = textInputField.GetComponent<RectTransform>();
        textInputFieldRectTransform.sizeDelta = new Vector2(textInputFieldSizeX, 37);

        RectTransform textOutputFieldRectTransform = textOutputField.GetComponent<RectTransform>();
        textOutputFieldRectTransform.sizeDelta = new Vector2(textInputFieldSizeX, textOutputFieldSizeY);

        RectTransform finishTextRectTransform = finishText.GetComponent<RectTransform>();
        finishTextRectTransform.sizeDelta = new Vector2(width, height);
        
        RectTransform pauseRect = pauseMenu.GetComponent<RectTransform>();
        pauseRect.sizeDelta = new Vector2(pauseSizeX, pauseSizeY);

        pauseText.GetComponent<RectTransform>().localPosition = new Vector3(0, pauseSizeY * 3 / 8, 0);
        volumeText.GetComponent<RectTransform>().localPosition = new Vector3(-pauseSizeX / 5, pauseSizeY / 8, 0);
        volumeSlider.GetComponent<RectTransform>().localPosition = new Vector3(pauseSizeX / 5, pauseSizeY / 8, 0);
        mainMenuButt.GetComponent<RectTransform>().localPosition = new Vector3(0, -pauseSizeY / 8, 0);
        continueButt.GetComponent<RectTransform>().localPosition = new Vector3(0, -pauseSizeY * 3 / 8, 0);
    }
    
}
