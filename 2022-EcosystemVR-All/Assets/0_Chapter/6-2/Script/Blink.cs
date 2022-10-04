using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    Animator[] animator;
    private void Start()
    {
        animator = GetComponentsInChildren<Animator>();
    }

    public void replay()
    {
        foreach (var item in animator)
        {
            item.SetTrigger("go");
        }
    }
}
