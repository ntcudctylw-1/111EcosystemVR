using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEvent : MonoBehaviour
{
    [SerializeField]
    private HMDEvents mDEvents;
    [SerializeField]
    private CatHealth catHealth;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        mDEvents = FindObjectOfType<HMDEvents>();
        catHealth = FindObjectOfType<CatHealth>();
        animator = GetComponent<Animator>();
    }

    public void GetTrap()
    {
        mDEvents.EventTriggered(4);
        catHealth.posioned();
        animator.SetTrigger("go");
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
