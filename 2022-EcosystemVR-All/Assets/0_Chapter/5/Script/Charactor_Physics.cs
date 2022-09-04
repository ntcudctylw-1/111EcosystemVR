using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor_Physics : MonoBehaviour
{
    CharacterController character;
    public float Gravity = -15.0f;
    public float JumpHeight = 1.2f;
    public bool Grounded = true;
    public float _verticalVelocity;
    public Vector3 _horizionVelocity;
    public float _terminalVelocity = 53.0f;
    public float _speed = 53.0f;
    public float Resistance = 0.9f;
    void Start()
    {
        character = GetComponent<Mode_Switch>().GetCharacterController();
    }

    // Update is called once per frame
    void Update()
    {
        _horizionVelocity *= Resistance;
        //if (Mathf.Abs(_horizionVelocity.z) < 1) _horizionVelocity = Vector3.zero;
        Grounded = (character.isGrounded) ? true : false;

        JumpAndGravity();
        character.Move(character.transform.rotation *new Vector3(0, _verticalVelocity, (_horizionVelocity * _speed).z) * Time.deltaTime);
    }


    public void Add_horizionVelocity(Vector3 value)
    {
        _horizionVelocity += value;
    }

    public void Player_Jump()
    {
        _verticalVelocity += Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }

    public void JumpAndGravity()
    {
        
        // stop our velocity dropping infinitely when grounded
        if (_verticalVelocity < 0.0f && Grounded)
        {
            _verticalVelocity = -2f;
        }


        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += Gravity * Time.deltaTime;
        }

    }

    public void Rotate()
    {

    }


}
