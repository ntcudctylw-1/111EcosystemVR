using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollision : MonoBehaviour
{
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Car":
                print("Car!");
                break;
            case "Wall":
                print("Wall!");
                break;

        }

    }
}
