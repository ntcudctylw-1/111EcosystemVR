using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class ControllerVector
{
    public Vector3 x;
    public Vector3 v;
    public Vector3 a;
    public Vector3[] positions;
    public Vector3[] velocities;
}
    public class VR_Controller_Velocity : MonoBehaviour
{

    public ControllerVector Left;
    public float RecordEveryXSeconds = 0.1f;
    public int RecordTimes = 30;
    public float MinalOffset = 0.0001f;
    
    // Start is called before the first frame update
    void Start()
    {
        Left.positions = new Vector3[RecordTimes];
        Left.velocities = new Vector3[RecordTimes];

        InvokeRepeating("Record", 0, RecordEveryXSeconds);
    }

    void Record()
    {
        Left = SetVector(Left,GlobalSet.LeftHand.Position);
    }
   

    ControllerVector SetVector(ControllerVector Target,Vector3 New)
    {
        //Debug.Log(Mathf.Round(New.x * (1 / MinalOffset))* MinalOffset);
        New = new Vector3(Mathf.Round(New.x * (1 / MinalOffset)) * MinalOffset, Mathf.Round(New.y * (1 / MinalOffset)) * MinalOffset, Mathf.Round(New.z * (1 / MinalOffset)) * MinalOffset);

        Vector3[] Stack(Vector3[] Target,Vector3 New)
        {
            for (int i = Target.Length - 1; i > 0; i--)
            {
                //Debug.Log(i - 1 + " -> " + i);
                Target[i] = Target[i - 1];
            }

            Target[0] = New;
            return Target;
        }

        Vector3 Count_Slope(Vector3[] datas)//­pºâ±×²v
        {
            Vector3 Vector_Sum(Vector3[] vectors)
            {
                Vector3 sum = Vector3.zero;
                for (int i = 0; i < vectors.Length-1; i++)
                {
                    sum += vectors[i + 1] - vectors[i];
                }
                return sum;
            }
            return Vector_Sum(datas) / datas.Length;
        }

        Target.x = New;//¬ö¿ý Position
        Target.positions =  Stack(Target.positions, Target.x);//°ïÅ| Position
        Target.v = Count_Slope(Target.positions);//­pºâVelocity
        Target.velocities = Stack(Target.velocities, Target.v);//°ïÅ| Velocity
        Target.a = Count_Slope(Target.velocities);//­pºâVelocity

        return Target;
    }
}

