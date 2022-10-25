using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System;
using UnityEngine.Events;

public class FlappingCheck1 : MonoBehaviour
{
    public bool isFlaping;
    public int flapTimes = 0;

    public StarterAssetsInputs assetsInputs;
    public VR_Gesture _Gesture;


    [Serializable]
    public class Event : UnityEvent { }
    [SerializeField]
    Event m_Event = new Event();

    protected FlappingCheck1()
    { }

    public Event onEvent
    {
        get { return m_Event; }
        set { m_Event = value; }
    }
    //public Ch5_Flaping flaping;

    //public CharacterControllerPhysics physics;

    private void Update()
    {
        
        if((assetsInputs.jump || _Gesture.Is_Flapping || Input.GetKeyDown(KeyCode.Space)) && !isFlaping)
        {
            //print(assetsInputs.jump);
            isFlaping = true;
            assetsInputs.jump = false;
            _Gesture.Is_Flapping = false;
            
        }

        if (isFlaping)
        {
            //personController.forceJump = true;
            m_Event.Invoke();
            isFlaping = false;
            //flaping.flaping = true;
            //physics.jumping = true;
            //physics._horzionVelocity
        }
    }
}
