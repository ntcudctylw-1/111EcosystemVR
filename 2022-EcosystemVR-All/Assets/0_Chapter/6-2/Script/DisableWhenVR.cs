using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenVR : MonoBehaviour
{
    public static bool IsVR = false;
    public static bool IsPC = false;
#if UNITY_ANDROID
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(false);
    }
#endif
}
