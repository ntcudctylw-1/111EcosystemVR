using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButtons : MonoBehaviour
{
    public static XRIDefaultInputActions inputActions;

    private void Start()
    {
        inputActions = new XRIDefaultInputActions();
        inputActions.Enable();
    }
    private void Update()
    {
        print(inputActions.XRILeftHandInteraction.MenuButton.ReadValue<float>());
    }
}
