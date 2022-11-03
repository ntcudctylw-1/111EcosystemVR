using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;

public class PassBorder : MonoBehaviour
{
    public GameObject borader;
    public GameObject player;
    [SerializeField]
    public Side side;
    [SerializeField]
    public Comapre comapre;

    public enum Side
    {
        x, y, z
    }

    public enum Comapre
    {
        more,less
    }

    [Serializable]
    public class PassEvent : UnityEvent { }

    [SerializeField]
    public PassEvent m_Event = new PassEvent();
    protected PassBorder()
    { }

    public PassEvent onPass
    {
        get { return m_Event; }
        set { m_Event = value; }
    }


    private void Update()
    {
        float a = 0, b = 0;

        switch (side)
        {
            case Side.x:
                a = borader.transform.position.x;
                b = player.transform.position.x;
                break;
            case Side.y:
                a = borader.transform.position.y;
                b = player.transform.position.y;
                break;
            case Side.z:
                a = borader.transform.position.z;
                b = player.transform.position.z;
                break;

        }

        switch (comapre)
        {
            case Comapre.more:
                if (a > b) m_Event.Invoke();
                break;
            case Comapre.less:
                if (a < b) m_Event.Invoke();
                break;
        }
    }

    public void detectOnce()
    {
        this.enabled = false;
    }
}
