using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    public Animator Animator;

    private void Start()
    {
        
    }
    bool walk = false;
    private void Update()
    {
        Vector3 v = GetComponent<NavMeshAgent>().velocity;
        float temp = Mathf.Pow((v.x * v.x + v.z * v.z), 1f / 2f);
        if(temp > 0.5 && !walk)
        {
            walk = true;
            Animator.SetTrigger("walk");
        }
        if(temp < 1)
        {
            walk = false;
        }

        //  Debug.Log(Mathf.Pow((v.x * v.x + v.z * v.z), 1f / 2f));
        Animator.SetFloat("v",temp );
    }

}
