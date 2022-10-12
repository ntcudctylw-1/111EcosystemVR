using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
public class M_Collision : MonoBehaviour
{
    [Serializable]
    public class CollisionEvent : UnityEvent { }

    [SerializeField]
    public CollisionEvent m_Event = new CollisionEvent();
    protected M_Collision()
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            m_Event.Invoke();
        }
    }

}
