using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMoveController_Ch4 : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) transform.localPosition = new Vector3(0, 0, 0.4f);
        if (Input.GetKeyDown(KeyCode.S)) transform.localPosition = new Vector3(0, 0, -0.4f);
        if (Input.GetKeyDown(KeyCode.A)) transform.localPosition = new Vector3(-0.4f, 0, 0);
        if (Input.GetKeyDown(KeyCode.D)) transform.localPosition = new Vector3(0.4f, 0, 0);

    }
}
