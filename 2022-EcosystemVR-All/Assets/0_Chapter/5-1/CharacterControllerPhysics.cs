using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterControllerPhysics : MonoBehaviour
{
    public bool grounded;
    public bool floating;
    public float gravity;
    public float floatForce;
    CharacterController controller;
    public float _verticalVelocity;
    public float _horzionVelocity;
    public bool jumping;
    public float jumpHeight;
    public float jumpTimeout;
    float jumpDelta;
    public float flapMove;
    public float maxMoveSpeed;
    public float moveResistance;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        checkgrounded();
        gravitycheck();
        if (_horzionVelocity >= 0) _horzionVelocity -= moveResistance;
        if (_horzionVelocity <= 0) _horzionVelocity = 0;
        if (_horzionVelocity >= maxMoveSpeed) 
        { 
            _horzionVelocity = maxMoveSpeed;
            floating = true;
        }
        else
        {
            floating = false;
        }
        if (grounded) _horzionVelocity = 0;
        move();

    }

    void checkgrounded()
    {
        grounded = controller.isGrounded;
    }

    void gravitycheck()
    {
        if (grounded)
        {
            _verticalVelocity = -2;
            jumpDelta = 0;
        }
        else
        {
            if (floating)
            {
                _verticalVelocity += (gravity + floatForce) * Time.deltaTime;
            }
            else
            {
                _verticalVelocity += gravity * Time.deltaTime;
            }

            jumpDelta -= Time.deltaTime;
        }

        if (jumping && jumpDelta <=0)
        {
            if(_verticalVelocity <= maxMoveSpeed) _horzionVelocity += flapMove * Time.deltaTime;
            _verticalVelocity = jumpHeight * Time.deltaTime;
            
            jumping = false;
        }
    }

    public Transform cAmera;
    void move()
    {
        //controller.Move(transform.rotation * new Vector3(0.0f, _verticalVelocity, _horzionVelocity) * Time.deltaTime);
        Quaternion rotate = cAmera.transform.rotation;
        rotate.x = 0;
        rotate.z = 0;
        //rotate.w = 0;
        //rotate.y = 0;
        controller.Move(( rotate* new Vector3(0.0f, 0, _horzionVelocity)+ new Vector3(0.0f, _verticalVelocity, 0)) * Time.deltaTime);
    }
}
