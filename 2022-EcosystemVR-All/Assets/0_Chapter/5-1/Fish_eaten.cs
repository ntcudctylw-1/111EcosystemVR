using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Fish_eaten : MonoBehaviour
{
    [Serializable]
    public class EatEvent : UnityEvent { }
    [SerializeField]
    public EatEvent m_Event = new EatEvent();
    protected Fish_eaten()
    { }

    public EatEvent onEat
    {
        get { return m_Event; }
        set { m_Event = value; }
    }
    private void Awake()
    {
        
    }

    public float disapearRotation = 1.07f;
    public GameObject cAmera;


    private void Update()
    {
        // print((cAmera.transform.rotation * new Vector3(0, 1, 0)));
        float temp = Vector3.Lerp(cAmera.transform.localRotation.eulerAngles, new Vector3(0, 1, 0), 0.1f).x;
        print(temp);
        if(temp < disapearRotation && temp > 200)
        {
            m_Event.Invoke();
           this.gameObject.SetActive(false);

        }
    }
}
