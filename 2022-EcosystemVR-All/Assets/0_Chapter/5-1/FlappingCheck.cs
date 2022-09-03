using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FlappingCheck : MonoBehaviour
{
    public bool isFlaping;
    public int flapTimes = 0;

    public StarterAssetsInputs assetsInputs;
    public VR_Gesture _Gesture;

    public ThirdPersonController2 personController;
    public CharacterControllerPhysics physics;

    private void Update()
    {
        
        if((assetsInputs.jump || _Gesture.Is_Flapping) && !isFlaping)
        {
            //print(assetsInputs.jump);
            isFlaping = true;
            assetsInputs.jump = false;
            _Gesture.Is_Flapping = false;
            
        }

        if (isFlaping)
        {
            personController.forceJump = true;
   
            isFlaping = false;
            physics.jumping = true;
        }
    }
}
