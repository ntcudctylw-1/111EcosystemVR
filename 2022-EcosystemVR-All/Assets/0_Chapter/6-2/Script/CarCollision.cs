using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
public class CarCollision : MonoBehaviour
{
    [Serializable]
    public class CollisionEvent : UnityEvent { }

    [SerializeField]
    CollisionEvent m_Event = new CollisionEvent();
    protected CarCollision()
    { }

    public CollisionEvent onCollision
    {
        get { return m_Event; }
        set { m_Event = value; }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            m_Event.Invoke();
        }
    }

}
