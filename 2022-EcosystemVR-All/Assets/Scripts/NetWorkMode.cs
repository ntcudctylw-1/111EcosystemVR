using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkMode : MonoBehaviour
{
    public Camera m_camera;
    bool check;
    float keepTime;
    private void Update()
    {
        if ((GlobalSet.LeftHand.ButtonA && GlobalSet.RightHand.ButtonA) || Input.GetKey(KeyCode.F1)) check = true;
        else check= false;

        if (check)
        {
            keepTime += Time.deltaTime;
            if (keepTime >= 3)
            {

                GlobalSet.NetworkMode = !GlobalSet.NetworkMode;
                if(GlobalSet.NetworkMode)m_camera.backgroundColor = Color.white;
                else m_camera.backgroundColor = Color.black;
                keepTime = 0;
                Debug.Log("Network Mode is " + GlobalSet.NetworkMode);
            }
        }else keepTime= 0;
    }

    private void Start()
    {
        Debug.Log("Network Mode is " + GlobalSet.NetworkMode);
    }

}
