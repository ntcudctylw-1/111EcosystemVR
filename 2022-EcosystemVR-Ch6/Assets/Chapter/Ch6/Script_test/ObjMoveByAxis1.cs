using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjMoveByAxis1 : MonoBehaviour
{

    private void Update()
    {


    }

    Vector3 ResetVectorY(Vector3 vector, float y)
    {
        vector.y = y;
        return vector;
    }
}
