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
    private void Start()
    {
        type = (Type)Random.Range(0,2);
        /*
        if(type == Type.poison)
        {
            GetComponent<CarCollision>().onCollision.AddListener(delegate () { FindObjectOfType<HMDEvents>().EventTriggered(2); });

        }*/
        controller = FindObjectOfType<CatFirstPersonController>();
    }

    public void lessSpeed()
    {
        controller.moveSpeed = 0.03f;
    }


}
