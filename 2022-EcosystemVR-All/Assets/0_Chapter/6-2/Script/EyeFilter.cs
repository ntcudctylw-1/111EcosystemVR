using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFilter : MonoBehaviour
{
    [SerializeReference] private Animator animator;
    [SerializeReference] private float Time;
    public void SetTime(float a)
    {
        if (a == 1) a -= 0.01f; 
        Time = a;
        animator.SetFloat("Time", Time);
    }
}
