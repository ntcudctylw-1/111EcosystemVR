using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    public static GameObject XR;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(XR);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
