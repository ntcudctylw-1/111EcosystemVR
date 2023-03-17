using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ch4PcVrMode : MonoBehaviour
{
#if UNITY_ANDROID 
    [SerializeReference]
    private float UiOffset = -0.37f;

#endif

#if UNITY_STANDALONE_WIN 
    [SerializeReference]
    private float UiOffset = -0.05f;
#endif



    private void Start()
    {
        FindObjectOfType<C4_UIStartSetHeight>().GetComponent<C4_UIStartSetHeight>().offset = UiOffset;
    }
}
