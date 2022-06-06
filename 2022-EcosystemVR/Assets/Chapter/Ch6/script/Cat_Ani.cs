using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Ani : MonoBehaviour
{

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Debug.Log(ch6_1st.Moving);
        if(ch6_1st.Moving == 1)
        {
            if (animator.GetInteger("state") == 0)
            {
                animator.SetTrigger("move");
            } 
            animator.SetInteger("state", 1);
        }
        else if(ch6_1st.Moving <= 0) {
            if (animator.GetInteger("state") == 1)
            {
                animator.SetTrigger("stand");
            }
            animator.SetInteger("state", 0);
        }
    }
}
