using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUp : MonoBehaviour
{
    FlyChecker checker;
    CharacterControllerPhysics characterControllerPhysics;

    public float jumpHeight = 2f;

    private void Start()
    {
        checker = GetComponent<FlyChecker>();
        characterControllerPhysics = GetComponent<CharacterControllerPhysics>();
    }

    private void Update()
    {
        if (checker.flying)
        {
            characterControllerPhysics._verticalVelocity += jumpHeight;
        }
    }
}
