using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenPC : MonoBehaviour
{

#if UNITY_STANDALONE_WIN
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
