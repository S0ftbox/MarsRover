using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    string outputText;
    public bool isStoneNear = false;
    public bool isFinish = false;
    public bool doingCoroutine = false;
    bool turnLeft, forward;
    public TextOutput textOutput;
    public GameObject rover, start;
    public GameObject fl, fr, rl, rr;
    public GameObject driveSound, analyzeSound, telemetrySound;
    Vector3 startPos, newPos, currentPos;
    Quaternion startRot, newRot;
    public int howManyAnalysis;
    public int stoneAnalysis;

    void Start()
    {
        startPos = start.transform.position;
        startRot = start.transform.rotation;
        rover.transform.position = startPos;
        rover.transform.rotation = startRot;
    }

    public void RunForward(int value)
    {
        forward = true;
        newPos = rover.transform.position + transform.TransformDirection(Vector3.forward * value / 5);
        StartCoroutine(RoverMove(newPos));
        outputText = "forward " + value;
        textOutput.printOutupt(outputText);
    }

    public void RunBackward(int value)
    {
        forward = false;
        outputText = "backward " + value;
        newPos = rover.transform.position + transform.TransformDirection(Vector3.back * value / 5);
        StartCoroutine(RoverMove(newPos));
        textOutput.printOutupt(outputText);
    }

    public void TurnLeft(int value)
    {
        turnLeft = true;
        outputText = "left " + value;
        rover.transform.Rotate(0, -value, 0);
        newRot = transform.rotation;
        rover.transform.Rotate(0, value, 0);
        StartCoroutine(RoverRotate(newRot, value / 7));
        textOutput.printOutupt(outputText);
    }

    public void TurnRight(int value)
    {
        turnLeft = false;
        outputText = "right " + value;
        rover.transform.Rotate(0, value, 0);
        newRot = transform.rotation;
        rover.transform.Rotate(0, -value, 0);
        StartCoroutine(RoverRotate(newRot, value / 7));
        textOutput.printOutupt(outputText);
    }

    public void Telemetry(float distance)
    {
        outputText = "---telemetry---\ndistance: " + distance + "\nanalysis: " + howManyAnalysis + "\nrock analysis:\n" + stoneAnalysis + "\n---------------";
        textOutput.printOutupt(outputText);
        telemetrySound.GetComponent<AudioSource>().Play();
    }

    public void Data()
    {
        howManyAnalysis += 1;
        System.Random randomValue = new System.Random();
        if (isStoneNear)
        {
            stoneAnalysis += 1;
            int randomOutput = randomValue.Next(8);
            switch (randomOutput)
            {
                case 0:
                    outputText = "-----data------\nYup, that is an\nordinary stone.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 1:
                    outputText = "-----data------\nHey, there is a\nwater source.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 2:
                    outputText = "-----data------\nYup, that is an\nordinary stone.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 3:
                    outputText = "-----data------\nHey, there is a\nwater source.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 4:
                    outputText = "-----data------\nYup, that is an\nordinary stone.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 5:
                    outputText = "-----data------\nHey, there is a\nwater source.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 6:
                    outputText = "-----data------\nYup, that is an\nordinary stone.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 7:
                    outputText = "-----data------\nHey, there is a\nwater source.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
            }
            
        }
        else
        {
            int randomOutput = randomValue.Next(3);
            switch (randomOutput)
            {
                case 0:
                    outputText = "-----data------\nI see some dust\non my solar\npanels, gross!\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 1:
                    outputText = "-----data------\nNothing to find\nthere.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
                case 2:
                    outputText = "-----data------\nI am so alone,\nbring me home.\n---------------";
                    textOutput.printOutupt(outputText);
                    break;
            }
        }
        analyzeSound.GetComponent<AudioSource>().Play();
    }

    public void Reset()
    {
        if(doingCoroutine == false)
        {
            rover.transform.position = startPos;
            rover.transform.rotation = startRot;
        }
    }

    public void InvalidCommand()
    {
        outputText = "INVALID COMMAND!";
        textOutput.printOutupt(outputText);
    }

    public IEnumerator RoverMove(Vector3 targetPos)
    {
        doingCoroutine = true;
        driveSound.GetComponent<AudioSource>().Play();
        if(forward == true)
        {
            fl.GetComponent<Animation>().Play("LeftFWD");
            fr.GetComponent<Animation>().Play("RightFWD");
            rl.GetComponent<Animation>().Play("LeftFWD");
            rr.GetComponent<Animation>().Play("RightFWD");
        }
        else
        {
            fl.GetComponent<Animation>().Play("RightFWD");
            fr.GetComponent<Animation>().Play("LeftFWD");
            rl.GetComponent<Animation>().Play("RightFWD");
            rr.GetComponent<Animation>().Play("LeftFWD");
        }
        while ((transform.position.x != targetPos.x) && (transform.position.z != targetPos.z))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.75f * Time.deltaTime);
            yield return null;
        }
        fl.GetComponent<Animation>().Stop();
        fr.GetComponent<Animation>().Stop();
        rl.GetComponent<Animation>().Stop();
        rr.GetComponent<Animation>().Stop();
        driveSound.GetComponent<AudioSource>().Stop();
        doingCoroutine = false;
    }

    public IEnumerator RoverRotate(Quaternion targetRot, float duration)
    {
        doingCoroutine = true;
        driveSound.GetComponent<AudioSource>().Play();
        if (turnLeft == true)
        {
            fl.GetComponent<Animation>().Play("RightFWD");
            fr.GetComponent<Animation>().Play("RightFWD");
            rl.GetComponent<Animation>().Play("RightFWD");
            rr.GetComponent<Animation>().Play("RightFWD");
        }
        else
        {
            fl.GetComponent<Animation>().Play("LeftFWD");
            fr.GetComponent<Animation>().Play("LeftFWD");
            rl.GetComponent<Animation>().Play("LeftFWD");
            rr.GetComponent<Animation>().Play("LeftFWD");
        }
        float time = 0;
        Quaternion startRot = transform.rotation;

        if (duration < 10)
        {
            duration = 1;
        }

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRot, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRot;
        fl.GetComponent<Animation>().Stop();
        fr.GetComponent<Animation>().Stop();
        rl.GetComponent<Animation>().Stop();
        rr.GetComponent<Animation>().Stop();
        driveSound.GetComponent<AudioSource>().Stop();
        doingCoroutine = false;
    }

}
