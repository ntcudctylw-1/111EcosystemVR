using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenPC : MonoBehaviour
{
    public static bool IsVR = false;
    public static bool IsPC = false;
#if UNITY_STANDALONE_WIN
    // Start is called before the first frame update
    void Start()
    {
        IsPC = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(false);
    }
#endif
}
