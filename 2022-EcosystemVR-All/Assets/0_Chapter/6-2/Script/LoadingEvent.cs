using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class LoadingEvent : MonoBehaviour
{
    [Serializable]
    public class LoadEvent : UnityEvent { }

    [SerializeField]
    LoadEvent m_Event = new LoadEvent();
    protected LoadingEvent() 
    {}

    public LoadEvent onLoad
    {
        get { return m_Event; }
        set { m_Event = value; }
    }

    public void Load()
    {
        m_Event.Invoke();
    }


    private void Start()
    {
        Load();
    }
}
