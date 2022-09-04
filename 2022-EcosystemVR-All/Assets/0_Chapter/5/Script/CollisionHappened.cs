using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHappened : MonoBehaviour
{
    public FlyLevel level;
    public int id;


    private void OnTriggerEnter(Collider trigger)
    {
        //Debug.Log("OnTriggerEnter");
        if (level != null && trigger.tag == "Player") level.TriggerEnter(id, trigger);
    }

    private void OnTriggerStay(Collider trigger)
    {
        //Debug.Log("OnTriggerStay");
        if (level != null && trigger.tag == "Player") level.TriggerStay(id, trigger);
    }

    private void OnTriggerExit(Collider trigger)
    {
        //Debug.Log("OnTriggerExit");
        if (level != null && trigger.tag == "Player") level.TriggerExit(id, trigger);
    }
}
