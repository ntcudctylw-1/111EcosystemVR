using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Collision : MonoBehaviour
{
    public GameObject GlobalSet;


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.tag == "Player")
        {
            Debug.Log(collision.transform.name);
            StartCoroutine( GlobalSet.GetComponent<Spwan_Player>().Respawn(0));
            GlobalSet.GetComponent<Player_Score>().Car_Accident();
        }
    }

}
