using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Commands commands;
    public bool isAnalyzed = false;
    GameObject rockCollider;
    public TextInputRead textInputRead;
    public TextOutput output;
    string whatObjectName;

    void Start()
    {
        rockCollider = gameObject;
    }

    void Update()
    {
        if(textInputRead.command == "analyze" && commands.isStoneNear == true)
        {
            isAnalyzed = true;
        }
        if (isAnalyzed)
        {
            rockCollider.SetActive(false);
            commands.isStoneNear = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        commands.isStoneNear = true;
        output.isShown = false;
    }

    void OnTriggerExit(Collider collider)
    {
        commands.isStoneNear = false;
    }
}
