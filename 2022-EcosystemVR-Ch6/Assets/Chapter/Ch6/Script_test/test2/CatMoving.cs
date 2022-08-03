using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoving : MonoBehaviour
{
    [SerializeField]GameObject MovingObj,pos,neg;
    int side = 0;
    public void Move(int key)
    {
        side = key;
    }

    private void Update()
    {
        if (side == 1)
            MovingObj.transform.position = Vector3.Lerp(MovingObj.transform.position, pos.transform.position, 0.1f);
        else if (side == 0) { }
        else
        {
            MovingObj.transform.position = Vector3.Lerp(MovingObj.transform.position, neg.transform.position, 0.1f);
        }

        //MovingObj.transform.LookAt(new Transform);
    }
}
