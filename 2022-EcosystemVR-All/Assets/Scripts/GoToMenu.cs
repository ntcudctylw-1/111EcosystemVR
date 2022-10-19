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
            loadscene(1);
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            loadscene(1);
        }
    }

    int outid = 0;
    public void InvokeLoadScene(int sec,int outidd)
    {
        outid = outidd;
        Invoke("loadsceneout", sec);
    }

    void loadscene(int id) => SceneManager.LoadScene(id);

    void loadsceneout() => SceneManager.LoadScene(outid);
}
