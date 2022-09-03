using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeDisable : MonoBehaviour
{

    public GameObject[] HideWhenVR;
    public GameObject[] HideWhenPC;
    void Start()
    {
        if(GlobalSet.playMode == GlobalSet.PlayMode.PC)
        {
            for (int i = 0; i < HideWhenPC.Length; i++)
            {
                if(HideWhenPC[i] != null) HideWhenPC[i].SetActive(false);
            }
        }
        else if (GlobalSet.playMode == GlobalSet.PlayMode.VR)
        {
            for (int i = 0; i < HideWhenVR.Length; i++)
            {
                if (HideWhenVR[i] != null) HideWhenVR[i].SetActive(false);
            }
        }
    }

}
