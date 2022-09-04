using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public static XRIDefaultInputActions inputActions;

    private void Start()
    {
        inputActions = new XRIDefaultInputActions();
        inputActions.Enable();
    }
    private void Update()
    {
        if(inputActions.XRILeftHandInteraction.MenuButton.ReadValue<float>() != 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
