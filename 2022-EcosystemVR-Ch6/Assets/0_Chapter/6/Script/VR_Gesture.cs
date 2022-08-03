using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VR_Gesture : MonoBehaviour
{
    public float Offset = 0.0001f;
    public Vector3 Arrow;
    public bool Is_Walking;
    private void Start()
    {
        
        Arrow = Vector3.zero;
        
    }
    
    void Update()
    {
        Vector3 temp = Arrows();
        if (Arrow.y != temp.y || Arrow.z != temp.z) Is_Walking = true;
        //else if (Is_Walking) Invoke("StopWalking", 1);
        if(temp.y== 0 && temp.z==0) Is_Walking = false;

        Arrow = temp;

    }


    Vector3 Arrows()
    {
        Vector3 vector = GetComponent<VR_Controller_Velocity>().Left.v;
        Vector3 Temp = Vector3.zero;
        if (vector.x > Offset) Temp += Vector3.right;
        else if (vector.x < -Offset) Temp += Vector3.left;
        if (vector.y > Offset) Temp += Vector3.up;
        else if (vector.y < -Offset) Temp += Vector3.down;
        if (vector.z > Offset) Temp += Vector3.forward;
        else if (vector.z < -Offset) Temp += Vector3.back;

        return -Temp;
    }
}

