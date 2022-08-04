using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Move : MonoBehaviour
{
    public GameObject ChickensParent;
    public GameObject[] Chickens;

    private void Start()
    {
        Chickens = new GameObject[ChickensParent.transform.childCount];
        for(int i = 0; i < ChickensParent.transform.childCount; i++)
        {
            Chickens[i] = ChickensParent.transform.GetChild(i).gameObject;
        }


        InvokeRepeating("RandomWalking", 0, Random.Range(3,10));
    }




}
