using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextOutput : MonoBehaviour
{
    public GameObject finishGameObject;
    public Text outputTextField;
    public TextInputRead values;
    public Commands commands;
    int currentScene, resInfo, fontSize;
    string tutorialString;
    public bool isShown = false;
    int smallSize = 20;
    int largeSize = 30;

    void Start()
    {
        resInfo = PlayerPrefs.GetInt("Resolution");
        if(resInfo > 2)
        {
            outputTextField.fontSize = largeSize;
        }
        else
        {
            outputTextField.fontSize = smallSize;
        }
        currentScene = SceneManager.GetActiveScene().buildIndex;
        switch (currentScene)
        {
            case 1:
                tutorialString = "---------------\nHi! Welcome to\ntutorial level.\nYou will learn\nthe basics of\nrover steering.\nFirst, let's go\nforward with a\nsimple command:\n\nforward 'value'\n\nFor example:\n\nforward 25\n\nNow, let's try\nit by yourself!\n---------------";
                printOutupt(tutorialString);
                break;
            case 2:
                tutorialString = "---------------\nNow it's time\nto learn how to\nturn the rover.\nIn this case,\nyou will need\nto use one of\nthose commands:\n\nleft 'value'\nright 'value'\n\nFor example:\n\nleft 90\n\nRemember that\nthe value has\nto be given in\ndegrees. Let's\nmove forward\nand try to use\nit!\n---------------";
                printOutupt(tutorialString);
                break;
            case 3:
                finishGameObject.SetActive(false);
                tutorialString = "---------------\nNow it's time\nto study some\nrocks. In this\ncase let's use\nthis command:\n\nanalyze\n\nTo check if\nyou are close\nenough to rock\nwait until the\nantenna would\nswitch on.\nAfter analysis\nthe light will\nturn off. Try\nit by yourself.\n---------------";
                printOutupt(tutorialString);
                break;
            case 4:
                tutorialString = "---------------\nYou've learned\nall the basic\ncommands. It's\ntime to combine\nthem all and\ntake part in\nlast tutorial\nlevel. Good\nluck and have\nfun!\n---------------";
                printOutupt(tutorialString);
                break;
        }
    }

    void Update()
    {

        if (values.command == "forward" && values.value <= 150 && currentScene == 1 && isShown == false && commands.doingCoroutine == false)
        {
            tutorialString = "---------------\nExcellent! Now\nlet's repeat it\nto finish this\nlevel. You need\nonly " + (165-values.value) + " more\nunits to finish\nthe level. Use\nthis command\nagain but with\ngiven value.\n---------------";
            printOutupt(tutorialString);
            isShown = true;
        }

        if (values.command == "left" && currentScene == 2 && isShown == false && commands.doingCoroutine == false)
        {
            tutorialString = "---------------\nGreat! Follow\nthe path to end\nthis level.\n---------------";
            printOutupt(tutorialString);
            isShown = true;
        }

        if(values.command == "analyze" && currentScene == 3 && isShown == false)
        {
            if(commands.stoneAnalysis == 0)
            {
                tutorialString = "---------------\nYou know how to\nuse analysis.\nHowever, you\ndidn't analyze\nthe rock. Go\nback and study\nyour target.\n---------------";
                printOutupt(tutorialString);
                isShown = true;
            }

            if (commands.stoneAnalysis == 1)
            {
                finishGameObject.SetActive(true);
                tutorialString = "---------------\nGreat, you made\nthe analysis\ncorrectly. Now\nreturn to the\nstart position.\n---------------";
                printOutupt(tutorialString);
                isShown = true;
            }
        }
    }

    public void printOutupt(string outputText)
    {
        if(outputTextField.text != "")
        {
            outputTextField.text += "\n";
        }
        outputTextField.text += outputText;
    }
}
