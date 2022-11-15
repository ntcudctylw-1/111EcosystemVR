using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VR_Gesture))]
public class CatFirstPersonController : MonoBehaviour
{
    public CharacterController character;
    public Transform cameraDirection;
    public EyeFilter eyeFilter;
    public float moveSpeed = 1f;
    public float maxMoveSpeed = 10f;
    public float currentSpeed = 0f;
    public float reduse = 0.99f;

    VR_Gesture gesture;
    PcWalking pcWalking;
    private void Start()
    {
        gesture = GetComponent<VR_Gesture>();
        pcWalking = GetComponent<PcWalking>();
    }
    private void Update()
    {
        if (gesture.Is_Walking || pcWalking.isWalking)
        {
            currentSpeed = moveSpeed;
        }
        else
        {
            currentSpeed *= reduse;
        }
        if (currentSpeed < 0.01f) currentSpeed = 0;
        Move();
    }

    private void Move()
    {
        Quaternion rotate = cameraDirection.transform.rotation;
        rotate.x = 0;
        rotate.z = 0;
        if(eyeFilter!= null) eyeFilter.SetTime(currentSpeed / moveSpeed);
        character.Move(rotate * new Vector3(0, 0, currentSpeed) *Time.deltaTime);
    }



}
