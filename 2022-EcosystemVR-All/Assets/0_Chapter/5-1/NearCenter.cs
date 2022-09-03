using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class NearCenter : MonoBehaviour
{
    public GameObject diableWhenTouchCollider1;
    public GameObject diableWhenTouchCollider2;
    int collision = 0;
    public bool inTheRing;

    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }
    [FormerlySerializedAs("inRange1")]
    [SerializeField]
    private ButtonClickedEvent m_InRange1 = new ButtonClickedEvent();

    protected NearCenter()
    { }
    public ButtonClickedEvent inRange1
    {
        get { return m_InRange1; }
        set { m_InRange1 = value; }
    }
    [FormerlySerializedAs("inRange2")]
    [SerializeField]
    private ButtonClickedEvent m_InRange2 = new ButtonClickedEvent();

    public ButtonClickedEvent inRange2
    {
        get { return m_InRange2; }
        set { m_InRange2 = value; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(CharacterController))
        {
            collision++;
            updateState();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetType() == typeof(CharacterController))
        {
            collision--;
            updateState();
        }
    }

    void updateState()
    {
        if (collision == 0 && false)
        {
            inTheRing = false;
            diableWhenTouchCollider1.SetActive(true);
            diableWhenTouchCollider2.SetActive(true);
        }
        if (collision == 1)
        {
            inRange1.Invoke();
            inTheRing = false;
            diableWhenTouchCollider1.SetActive(false);
            
        }
        else if (collision == 2)
        {
            inRange2.Invoke();
            inTheRing = true;
            diableWhenTouchCollider1.SetActive(false);
            diableWhenTouchCollider2.SetActive(false);
        }
    }
}
