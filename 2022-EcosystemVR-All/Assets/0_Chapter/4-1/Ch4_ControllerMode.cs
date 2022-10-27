using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class Ch4_ControllerMode : MonoBehaviour
{
    [SerializeField]
    public enum ControllerMode
    {
        Ray,
        Hand
    }

    public ControllerMode controllerMode;
    [SerializeReference]
    private XRInteractorLineVisual XRInteractorLineVisual;
    [SerializeReference]
    private GameObject HandObject;

    private void Update()
    {
        bool handEnable = true;
        if (controllerMode == ControllerMode.Ray) handEnable = false;
        XRInteractorLineVisual.enabled = !handEnable;
        HandObject.SetActive(handEnable);

        
    }

    public void SetMode(int mode) => controllerMode = (ControllerMode)mode;

}
