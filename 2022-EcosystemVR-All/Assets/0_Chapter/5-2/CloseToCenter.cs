using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CloseToCenter : MonoBehaviour
{
    public int colliderIndex = 0;
    public bool enableDetect = false;

    [Serializable]
    public class collidEvent : UnityEvent { }

    [SerializeField]
    collidEvent m_CollidzeroEvent = new collidEvent();
    [SerializeField]
    collidEvent m_CollidFirstEvent = new collidEvent();
    [SerializeField]
    collidEvent m_CollidSecEvent = new collidEvent();

    protected CloseToCenter()
    { }

    public collidEvent onZero
    {
        get { return m_CollidzeroEvent; }
        set { m_CollidzeroEvent = value; }
    }
    public collidEvent onFirst
    {
        get { return m_CollidFirstEvent; }
        set { m_CollidFirstEvent = value; }
    }
    public collidEvent onSec
    {
        get { return m_CollidSecEvent; }
        set { m_CollidSecEvent = value; }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player" && enableDetect)
        {
            Debug.Log(transform.name);
            colliderIndex++;
            switch (colliderIndex)
            {
                case 0:
                    onZero.Invoke();
                    break;
                case 1:
                    onFirst.Invoke();
                    break;
                case 2:
                    onSec.Invoke();
                    break;
            }
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player" && enableDetect)
        {
            Debug.Log(transform.name);
            colliderIndex--;
            switch (colliderIndex)
            {
                case 0:
                    onZero.Invoke();
                    break;
                case 1:
                    onFirst.Invoke();
                    break;
                case 2:
                    onSec.Invoke();
                    break;
            }
        }
        
    }

    IEnumerator test()
    {
        yield return 0
            ;
    }

    private void Start()
    {
        
    }

    public void RestCollid()
    {
        colliderIndex = 0;
    }

    public void SetDetect(bool a) => enableDetect = a;
}
