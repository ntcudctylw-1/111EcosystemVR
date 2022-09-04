using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAccelator : MonoBehaviour
{
    public int SampleCount = 20;
    public Vector3[] PastPosition;
    public float Offset = 0.001f;
    Vector2 PastV;
    public static int walk = 0;

    private void Awake()
    {
        PastPosition = new Vector3[SampleCount];
        PastV = Vector2.zero;
    }

    private void Update()
    {
        for (int i = 0; i < SampleCount-1; i++) PastPosition[i + 1] = PastPosition[i];
        PastPosition[0] = GlobalSet.LeftHand.Position;

        Vector2 NowV = Velocity();
        //Debug.Log(Velocity());
        

        if(PastV != NowV)
        {
            //Debug.Log( status(NowV, PastV));
            PastV = NowV;
            walk = 1;
        }
        else
        {
            walk = 0;
        }
        
    }


    Vector2 Velocity()
    {
        float count_y=0, count_z=0;
        
        for (int i = 0; i < SampleCount - 1; i++)
        {
            count_y += PastPosition[i + 1].y - PastPosition[i].y;
            count_z += PastPosition[i + 1].z - PastPosition[i].z;
        }
            count_y /= SampleCount;
        count_z /= SampleCount;
        count_y = Mathf.Abs(count_y) < Offset ? 0 : count_y;
        count_z = Mathf.Abs(count_z) < Offset ? 0 : count_z;
        if (Mathf.Abs(count_y) - Mathf.Abs(count_z) > 0) //x 變量大於 z變量
        {
            if (count_y > 0) count_y = 1;
            else if (count_y == 0) count_y = 0;
            else count_y = -1;

            if (count_z > 0) count_z = 0.5f;
            else if (count_z == 0) count_z = 0;
            else count_z = -0.5f;
        }else
        {
            if (count_y > 0) count_y = 0.5f;
            else if (count_y == 0) count_y = 0;
            else count_y = -0.5f;

            if (count_z > 0) count_z = 1f;
            else if (count_z == 0) count_z = 0;
            else count_z = -1f;
        }




        return new Vector2(count_y, count_z);
    }

    Vector2 CenterPosition()
    {
        Vector2 center = new Vector2();
        for (int i = 0; i < SampleCount; i++)
        {
            center.x += PastPosition[i].y;
            center.y += PastPosition[i].z;
        }
        center /= SampleCount;
        return center;
    }


    int status(Vector2 NowV, Vector2 PastV)
    {
        if (PastV.x == 1 && NowV.y == -1) return 1;
        if (PastV.y == -1 && NowV.x == -1) return 2;
        if (PastV.x == -1 && NowV.y == 1) return 3;
        if (PastV.y == 1 && NowV.x == 1) return 4;
        else return 0;
        
    }
}
