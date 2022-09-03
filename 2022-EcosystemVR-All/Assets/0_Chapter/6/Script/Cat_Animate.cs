using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Animate : MonoBehaviour
{
    public Animator animator;

    public float Animate_Speed_Max = 1;
    float Animate_Speed_Now;
    public int Animate_Speed_Step = 10;

    private void Update()
    {
        if (GetComponent<VR_Gesture>().Is_Walking || GetComponent<PC_IsMoving>().Is_Walking)
        {
            if(Animate_Speed_Now < Animate_Speed_Max)
            {
                Animate_Speed_Now += Animate_Speed_Max / Animate_Speed_Step;
                SetSpeed(Animate_Speed_Now);
            }
            else
            {
                SetSpeed(Animate_Speed_Max);
            }
        }
        else
        {
            SetSpeed(0);
        }
    }

    void SetSpeed(float Speed)
    {
        animator.SetFloat("Speed", Speed);

    }
}
