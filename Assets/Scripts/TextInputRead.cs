using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInputRead : MonoBehaviour
{
    public InputField textInputField;
    public GameObject textOutputField;
    public Commands commandList;
    Text outputText;
    string inputText;
    public string command;
    public int value;
    public float distance;

    void Update()
    {
        inputText = textInputField.text;
        outputText = textOutputField.GetComponent<Text>();
        if (Input.GetKeyDown(KeyCode.Return) && !commandList.doingCoroutine)
        {
            string[] komenda = inputText.Split(' ');
            if (komenda.Length == 2)
            {
                command = komenda[0];
                value = int.Parse(komenda[1]);
                if(command == "forward")
                {
                    commandList.RunForward(value);
                    distance += value;
                }
                else if (command == "backward")
                {
                    commandList.RunBackward(value);
                    distance += value;
                }
                else if (command == "left")
                {
                    if(value < 180)
                    {
                        commandList.TurnLeft(value);
                    }
                    else
                    {
                        commandList.TurnRight(value);
                    }
                }
                else if (command == "right")
                {
                    if (value < 180)
                    {
                        commandList.TurnRight(value);
                    }
                    else
                    {
                        commandList.TurnLeft(value);
                    }
                }
                else
                {
                    commandList.InvalidCommand();
                }
            }
            else if(komenda.Length == 1)
            {
                command = komenda[0];
                if(command == "telemetry")
                {
                    commandList.Telemetry(distance);
                }
                else if (command == "analyze")
                {
                    commandList.Data();
                }
                else if (command == "reset")
                {
                    commandList.Reset();
                }
                else
                {
                    commandList.InvalidCommand();
                }
            }
            else
            {
                inputText = "INVALID COMMAND!";
            }
            textInputField.text = "";
        }
    }
}
