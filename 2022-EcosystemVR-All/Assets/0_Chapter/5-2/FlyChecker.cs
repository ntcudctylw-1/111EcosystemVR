using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class FlyChecker : MonoBehaviour
{
    public bool flying;
    public bool flied;


    [SerializeField]
    VR_Gesture gesture;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || gesture.Is_Flapping)
        {
            flied = true;
            flying = true;
        }
        else
        {
            flying = false;
        }
    }
}
