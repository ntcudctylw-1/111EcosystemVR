using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    Animator Animator;
    int key_L, key_R;
    Vector2 vector_L, vector_R;


    public float angle, persent;
    public int frame;
    public int framecount=32;
    private void Awake()
    {
        Animator = this.GetComponent<Animator>();

        
    }

    private int lastframe = 0;
    private void Update()
    {
        key_L = MovingPose.side_L;
        key_R = MovingPose.side_R;
        vector_L = MovingPose.L_key;
        vector_R = MovingPose.R_key;
        //  if (key_L == key_R) Animator.SetFloat("Speed", key_R);


        Vector2 a = new Vector2(GlobalSet.RightHand.Position.y, GlobalSet.RightHand.Position.z);
        
        Vector2 b = new Vector2(MovingPose.Base_Pos_R.y, MovingPose.Base_Pos_R.z);
        //Debug.Log(GlobalSet.RightHand.Position);
        float temp = (AngleBetweenVector2(a,b ) - 180) * -1;
        angle = temp;
        persent = temp / 360;
        frame = (int)(framecount * (1-persent));
        //frame = (int)(10000 *(1 - persent));
        // int frame = (int)(360 / 24 * (temp2 / 360));
        
        
        Animator.SetFloat("Time", (float)(frame * 0.0001));
        lastframe = frame ;
       //Animator.SetFloat("Time", (float)((10000 * (1 - persent)) * 0.0001));



    }

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
