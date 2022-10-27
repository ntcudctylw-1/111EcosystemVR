using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : MonoBehaviour
{
    public enum Type
    {
        normal,
        poison
    }

    [SerializeField]
    public Type type;
    [SerializeField]
    private CatFirstPersonController controller;
    [SerializeField]
    private CatHealth catHealth;
    [SerializeField]
    private HMDEvents mDEvents;
    private void Start()
    {

        if (Random.Range(0, 1f) > 0.7f)
            type = Type.poison;
        else
            type = Type.normal;
        //print(type);
        /*
        if(type == Type.poison)
        {
            GetComponent<CarCollision>().onCollision.AddListener(delegate () { FindObjectOfType<HMDEvents>().EventTriggered(2); });

        }*/
        controller = FindObjectOfType<CatFirstPersonController>();
        catHealth = FindObjectOfType<CatHealth>();
        mDEvents = FindObjectOfType<HMDEvents>();
    }

    public void lessSpeed()
    {
        print("Less Speed");
        if(type == Type.poison) 
        {
            //controller.moveSpeed *= 0.5f;
            mDEvents.EventTriggered(2);
            catHealth.posioned();
        }
        FindObjectOfType<UIController>().TaskTimesPlus(1);
        this.gameObject.SetActive(false);
        
    }


}
