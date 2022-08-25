using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : MonoBehaviour
{
    public bool IsEnable;
    VR_Gesture gesture;


    
    private void Start()
    {
        if (IsEnable) Enable();
    }

    public void Enable()
    {
        gesture = GetComponent<VR_Gesture>();


    }

    bool lastbool = false;
    private void Update()
    {
        if (IsEnable )
        {
            if (gesture.Is_Flapping && !lastbool) 
            {
                GetComponent<Charactor_Physics>().Player_Jump();
                GetComponent<FlyLevel>().PassLevel(0);
            }
            lastbool = gesture.Is_Flapping;
        }
        
    }
}
