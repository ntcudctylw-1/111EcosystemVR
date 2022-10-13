using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMove : MonoBehaviour
{
    VR_Gesture gesture;
    CharacterControllerPhysics character;
    public float moveSpeed = 0.1f;
    private void Start()
    {
        gesture = GetComponent<VR_Gesture>();
        character = GetComponent<CharacterControllerPhysics>();
    }

    private void Update()
    {
        if (gesture.Is_Walking) character._horzionVelocity = moveSpeed;
    }
}
