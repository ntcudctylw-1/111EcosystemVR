using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    [SerializeField]
    public static int hp = 3;
    [SerializeField]
    private float normalSpeed,posionSpeed;
    CatFirstPersonController CatFirstPerson;
    private void Start()
    {
        CatFirstPerson = FindObjectOfType< CatFirstPersonController>();
    }

    public void subHP()
    {
        hp--;
    }

    public void posioned()
    {
        print("GetPosioned");
        CatFirstPerson.moveSpeed *= posionSpeed;
    }

    public void normalized()
    {
        CatFirstPerson.moveSpeed = normalSpeed ;
    }
}
