using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonASAxisValue : MonoBehaviour
{
    public float Value = 0f;
    public float Accelator = 0f;
    public GameObject SimulateAxis;
    public static Vector3 SimulateAxisVector;
    public Animator Animator; 
    private void Update()
    {
        //Debug.Log(GlobalSet.LeftHand.ButtonA);
        if (/*GlobalSet.LeftHand.ButtonA && Value <= 1f ||*/ Value < 0 || HandAccelator.walk == 1)
        {
            //Debug.Log("!!!");
            Animator.SetBool("walking",true);
            Animator.SetBool("stand", false);
            Value += Accelator * 10;
        }
        else if(Value > 0)
        {

            Value -= Accelator;
        }
        if (Value < 0.001f)
        {
            Value = 0;
            Animator.SetBool("walking", false);
            if(Animator.GetBool("stand"))Animator.SetBool("stand",true);
        }
        if (Value > 0.99f) Value = 1;

        SimulateAxis.transform.position = NewVector(GlobalSet.HeadSet.Rotation * Vector3.forward, true, false, true).normalized * Value;
        SimulateAxisVector = SimulateAxis.transform.position;
        
    }

    Vector3 NewVector(Vector3 vector,bool x,bool y,bool z)
    {
        Vector3 a = Vector3.zero;
        a.x = x ? vector.x : 0;
        a.y = y ? vector.y : 0;
        a.z = z ? vector.z : 0;
        return a;
    }
}
