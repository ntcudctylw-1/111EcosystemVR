using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VR_Gesture : MonoBehaviour
{
    public float Offset = 0.0001f;
    public Vector3 Arrow_L,Arrow_R;
    public bool Is_Walking;
    public bool Is_Flapping;
    private void Start()
    {
        
        Arrow_L = Vector3.zero;
        Arrow_R = Vector3.zero;
        
    }
    
    void Update()
    {
        Vector3 temp_L = Arrow_Ls(GetComponent<VR_Controller_Velocity>().Left.v);
        Vector3 temp_R = Arrow_Ls(GetComponent<VR_Controller_Velocity>().Right.v);
        Walk(temp_L);
        Flap(temp_L, temp_R);
        Arrow_L = temp_L;
        Arrow_R = temp_R;
    
}

    void Walk(Vector3 temp)
    {
        
        if (Arrow_L.y != temp.y || Arrow_L.z != temp.z) Is_Walking = true;
        //else if (Is_Walking) Invoke("StopWalking", 1);
        if (temp.y == 0 && temp.z == 0) Is_Walking = false;
    }


    Vector3 Arrow_Ls(Vector3 vector)
    {
        
        Vector3 Temp = Vector3.zero;
        if (vector.x > Offset) Temp += Vector3.right;
        else if (vector.x < -Offset) Temp += Vector3.left;
        if (vector.y > Offset) Temp += Vector3.up;
        else if (vector.y < -Offset) Temp += Vector3.down;
        if (vector.z > Offset) Temp += Vector3.forward;
        else if (vector.z < -Offset) Temp += Vector3.back;

        return -Temp;
    }

    void Flap(Vector3 vector_L, Vector3 vector_R)
    {
        if (vector_L.y > Offset && vector_R.y > Offset) Is_Flapping = true;
        else if (vector_L.y < -Offset && vector_R.y < -Offset) Is_Flapping = true;
        else Is_Flapping = false;

    }
}

