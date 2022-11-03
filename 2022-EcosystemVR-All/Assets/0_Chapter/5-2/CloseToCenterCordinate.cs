using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CloseToCenterCordinate : MonoBehaviour
{
    [Serializable]
    public class collidEvent : UnityEvent { }

    [SerializeField]
    collidEvent m_CollidzeroEvent = new collidEvent();
    [SerializeField]
    collidEvent m_CollidFirstEvent = new collidEvent();
    [SerializeField]
    collidEvent m_CollidSecEvent = new collidEvent();

    protected CloseToCenterCordinate()
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

    [SerializeField]
    private float range1 = 2f;
    
    [SerializeField]
    private float range2 = 7f;

    [SerializeField]
    private Transform CameraOffset;

    public bool startgo = false;

    private void Update()
    {
        if (startgo)
        {
            if (Mathf.Abs(CameraOffset.localPosition.y) > range2) m_CollidzeroEvent.Invoke();
            else if (Mathf.Abs(CameraOffset.localPosition.y) > range1) m_CollidFirstEvent.Invoke();
            else m_CollidSecEvent.Invoke();
        }
        

    }

    public void SetStart(bool a) => startgo = a;

}
