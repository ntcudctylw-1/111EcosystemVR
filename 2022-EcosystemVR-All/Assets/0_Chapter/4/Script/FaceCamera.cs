using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    GameObject cameraObject;
    private void Update()
    {
        if(cameraObject == null)
        {
            cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        }

        this.gameObject.transform.LookAt(cameraObject.transform);
    }
}
