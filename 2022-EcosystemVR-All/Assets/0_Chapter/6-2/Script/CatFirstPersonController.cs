using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VR_Gesture))]
public class CatFirstPersonController : MonoBehaviour
{
    public CharacterController character;
    public Transform cameraDirection;
    public float moveSpeed = 1f;
    public float maxMoveSpeed = 10f;
    public float currentSpeed = 0f;

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
            currentSpeed = 0;
        }
        if (currentSpeed < 0) currentSpeed = 0;
        Move();
    }

    private void Move()
    {
        Quaternion rotate = cameraDirection.transform.rotation;
        rotate.x = 0;
        rotate.z = 0;

        character.Move(rotate * new Vector3(0, 0, currentSpeed) *Time.deltaTime);
    }



}
