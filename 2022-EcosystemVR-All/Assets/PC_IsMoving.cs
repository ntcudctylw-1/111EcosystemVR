using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PC_IsMoving : MonoBehaviour
{
    public StarterAssetsInputs _input;
    public bool Is_Walking;

    private void Update()
    {
        if (GlobalSet.playMode == GlobalSet.PlayMode.PC) 
        { 
            if (_input.move != Vector2.zero)
            {
                Is_Walking = true;
            }
            else
            {
                Is_Walking = false;
            }
        }
    }
}
