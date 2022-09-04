using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backtohome : MonoBehaviour
{
    public GameObject global;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            global.GetComponent<Levels>().Level_3();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            global.GetComponent<Levels>().Level_3();
        }
    }
}
