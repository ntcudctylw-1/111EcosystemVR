using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Ch5_Flaping : MonoBehaviour
{
    public bool flaping;

    [Serializable]
    public class flapEvent : UnityEvent { }

    [SerializeField]
    flapEvent m_EventFlap = new flapEvent();
    protected Ch5_Flaping()
    { }

    public flapEvent onFlap
    {
        get { return m_EventFlap; }
        set { m_EventFlap = value; }
    }

    private void Update()
    {
        if (flaping)
        {
            m_EventFlap.Invoke();
            flaping = false;
        }
    }

}
