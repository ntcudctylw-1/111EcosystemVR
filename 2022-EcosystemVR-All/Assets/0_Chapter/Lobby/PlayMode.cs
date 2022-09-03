using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMode : MonoBehaviour
{
    public GameObject[] EnableOnVRMode;
    public GameObject[] EnableOnPCMode;

    private void Start()
    {
        bool VREnable = true;
        if (GlobalSet.playMode == GlobalSet.PlayMode.PC) VREnable = false;
        else if (GlobalSet.playMode == GlobalSet.PlayMode.VR) VREnable = true;

        foreach (GameObject @object in EnableOnPCMode) @object.SetActive(!VREnable);
        foreach (GameObject @object in EnableOnVRMode) @object.SetActive(VREnable);
    }
}
