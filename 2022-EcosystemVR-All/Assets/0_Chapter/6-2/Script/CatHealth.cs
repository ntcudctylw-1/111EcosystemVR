using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    public int hp;
    [SerializeField]
    private float normalSpeed,posionSpeed;
    CatFirstPersonController CatFirstPerson;
    private void Start()
    {
        CatFirstPerson = GetComponent<CatFirstPersonController>();
    }

    public void subHP()
    {
        hp--;
    }

    public void posioned()
    {
        CatFirstPerson.moveSpeed = posionSpeed;
    }

    public void normalized()
    {
        CatFirstPerson.moveSpeed = normalSpeed ;
    }
}
