using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    public GameObject lightSource;
    public Commands rock;

    void Update()
    {
        if (rock.isStoneNear)
        {
            lightSource.SetActive(true);
        }
        else
        {
            lightSource.SetActive(false);
        }
    }
}
