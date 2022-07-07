using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject Spawn_XR, XR_Spawn;
    GameObject XR;

    public bool LeftController;
    public bool RightController;


    private void Start()
    {
        XR = GameObject.Find("XR Origin");
        //SceneManager.MoveGameObjectToScene(XR, SceneManager.GetActiveScene());
        XR.transform.parent = Spawn_XR.transform;
        do
        {
            XR.transform.localPosition = Vector3.zero;
        }
        while (XR.transform.localPosition != Vector3.zero);
        XR_Spawn.transform.parent = GameObject.Find("Main Camera").transform;
        do
        {
            XR_Spawn.transform.localPosition = Vector3.zero;
            Spawn_XR.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        while (XR_Spawn.transform.localPosition != Vector3.zero);
        if (!LeftController)GameObject.Find("LeftHand Controller").SetActive(false);
        if (!RightController)GameObject.Find("RightHand Controller").SetActive(false);

    }

    public void unload()
    {
        Spawn_XR.transform.parent = XR_Spawn.transform;
    }
}
