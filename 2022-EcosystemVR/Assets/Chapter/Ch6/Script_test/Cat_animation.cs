using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_animation : MonoBehaviour
{
    Animator Animator;
    public float Cat_Walk_Speed = 0;

    [SerializeField] GameObject Cat_Obj;
    public stat CatState = 0;
    public GameObject Event_Obj;
    float angle;
    public float Move_Speed = 100;
    public float[] last_angle;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        last_angle = new float[3];
        CatState = stat.lie;
    }
    public enum stat
    {
        lie,
        idle,
        walk,
        run,
        jump
    }


    public bool IsWalking;
    public GameObject Target,MoveOBJ;
    public float time;
    void Update()
    {
        angle = (int)(Event_Obj.GetComponent<Controller_Post_Detector>().AngleRelateToBasePosition / 30);
        //Debug.Log(angle);
        IsWalking = false;
        if ((angle == 11 && last_angle[2] == 0 && last_angle[1] == 1) || (angle == 10 && last_angle[2] == 11 && last_angle[1] == 0)) IsWalking = true;
        else if (last_angle[0] > last_angle[1] && last_angle[1] > last_angle[2] && last_angle[2] >= angle)
        {
            IsWalking = true;
        }
        if (last_angle[2] != angle)
        {
            last_angle[0] = last_angle[1];
            last_angle[1] = last_angle[2];
            last_angle[2] = angle;
        }


        Vector3 target_vector = Vector3.zero;
        if (IsWalking)
        {
            // MoveOBJ.transform.Translate(Target.transform.position * Move_Speed);
            //MoveOBJ.transform.position = Vector3.Lerp(MoveOBJ.transform.position, Target.transform.position * Move_Speed, time);
            target_vector = RemoveVectcor(GlobalSet.HeadSet.Rotation * Vector3.forward, true, false, true);


        }
        Target.transform.position = Vector3.Lerp(Target.transform.position, target_vector, Move_Speed);
        //Target.transform.localPosition = RemoveVectcor(GlobalSet.HeadSet.Rotation * Vector3.forward, true, false, true);


        //var step = Move_Speed * Time.deltaTime;
        //MoveOBJ.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
    }

    Vector3 RemoveVectcor(Vector3 vector, bool x, bool y, bool z)
    {
        Vector3 vector1 = new Vector3(0, 0, 0);
        if (x) vector1.x = vector.x;
        if (y) vector1.y = vector.y;
        if (z) vector1.z = vector.z;

        return vector1;
    }


}
