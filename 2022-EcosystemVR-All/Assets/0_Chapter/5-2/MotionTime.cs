using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class MotionTime : MonoBehaviour
{
    [Range(0, 9.9999f)]
    public float motionTime;
    [SerializeReference]
    Animator animator;

    [Serializable]
    public class EndEvent : UnityEvent { }

    [SerializeField]
    EndEvent m_OnEndAnimation = new EndEvent();
    [SerializeField]
    EndEvent m_OnEndFrame = new EndEvent();
    protected MotionTime()
    { }

    public EndEvent onEnd
    {
        get { return m_OnEndAnimation; }
        set { m_OnEndAnimation = value; }
    }
    public EndEvent onEndFrame
    {
        get { return m_OnEndFrame; }
        set { m_OnEndFrame = value; }
    }

    [SerializeField]
    private float endTime =10;
    public bool go;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            //print("GO");
            motionTime += (0.001f * speed);
            if(speed!=0) m_OnEndFrame.Invoke();
        }
        animator.SetFloat("Time", motionTime/10f);
        endcheck();
    }

 
    void endcheck()
    {
        if(motionTime >= endTime)
        {
            m_OnEndAnimation.Invoke();
            enabled = false;
        }
    }

    public void SetGo(bool a) => go = a;
    public void SetsPEED(float a) => speed = a;

    public void Reset()
    {
        motionTime = 0;
        speed = 0;
    }

    public void SetForward(bool go)
    {
        animator.SetBool("go", go);
    }

}
