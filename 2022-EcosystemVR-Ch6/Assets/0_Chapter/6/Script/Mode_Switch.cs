using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode_Switch : MonoBehaviour
{
    public GameObject[] OnlyVR, OnlyPC;

    private void Start()
    {
        if (GlobalSet.playMode == GlobalSet.PlayMode.PC)
        {
            foreach (GameObject gameObject in OnlyPC) gameObject.SetActive(true);
            foreach (GameObject gameObject in OnlyVR) gameObject.SetActive(false);
        }
        else
        {
            foreach (GameObject gameObject in OnlyPC) gameObject.SetActive(false);
            foreach (GameObject gameObject in OnlyVR) gameObject.SetActive(true);
        }
    }
}
