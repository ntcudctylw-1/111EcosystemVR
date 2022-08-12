using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_blance : MonoBehaviour
{
    Vector3 Head,Left,Right;
    public float Playerscope;
    public float Offset = 87;
    public Vector3 SetOffset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Head = GlobalSet.HeadSet.Position;
        Left = GlobalSet.LeftHand.Position;
        Right = GlobalSet.RightHand.Position;
        Vector3 HandCenter = (Left + Right) / 2;
        SetOffset = GlobalSet.HeadSet.Rotation *(Head - HandCenter) ;
        Playerscope = Vector2.SignedAngle( v3tov2(SetOffset, 1),Vector2.down) + 180 + Offset;
        if (Playerscope > 360) Playerscope = Playerscope - 360;
        //log(SetOffset);


    }
    Vector2 v3tov2(Vector3 vector3, int remove = 1)
    {
        if (remove == 1) return new Vector2(vector3.y, vector3.z);
        else if (remove == 2) return new Vector2(vector3.x, vector3.z);
        else return new Vector2(vector3.x, vector3.y);
    }

    void log(object message) => Debug.Log(message);

}
