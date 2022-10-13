using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomHandAnimator : MonoBehaviour
{
    public Animator animator_L, animator_R;
    public InputActionReference grip_L, grip_R, Trigger_L, Trigger_R;
    public GameObject Cube_L, Cube_R;

    private void Start()
    {
        if (grip_L != null) grip_L.action.Enable();
        if (grip_R != null) grip_R.action.Enable();
        if (Trigger_L != null) Trigger_L.action.Enable();
        if (Trigger_R != null) Trigger_R.action.Enable();


    }

    private void Update()
    {
        UpdateHandAnimation();
    }
    void UpdateHandAnimation()
    {
        float value;
        string par ;
        par = "Trigger";
        value = Trigger_L.action.ReadValue<float>();
        if (num2bool(value)) animator_L.SetFloat(par, value);
        else animator_L.SetFloat(par, 0);
        if (value > 0.6f) Cube_L.SetActive(true);
        else Cube_L.SetActive(false);

        par = "Trigger";
        value = Trigger_R.action.ReadValue<float>();
        if (num2bool(value)) animator_R.SetFloat(par, value);
        else animator_R.SetFloat(par, 0);
        if (value > 0.6f) Cube_R.SetActive(true);
        else Cube_R.SetActive(false);

        par = "Grip";
        value = Trigger_L.action.ReadValue<float>();
        if (num2bool(value)) animator_L.SetFloat(par, value);
        else animator_L.SetFloat(par, 0);

        par = "Grip";
        value = Trigger_R.action.ReadValue<float>();
        if (num2bool(value)) animator_R.SetFloat(par, value);
        else animator_R.SetFloat(par, 0);


        
        //print("Trigger_L:" + Trigger_L.action.ReadValue<float>());
       //print("Trigger_R"+Trigger_R.action.ReadValue<float>());
        //print("grip_L"+grip_L.action.ReadValue<float>());
        //print("grip_R"+grip_R.action.ReadValue<float>());
        
    }

    bool num2bool(float inp)
    {
        if (inp > 0.5f) return true;
        else return false;
    }

}
