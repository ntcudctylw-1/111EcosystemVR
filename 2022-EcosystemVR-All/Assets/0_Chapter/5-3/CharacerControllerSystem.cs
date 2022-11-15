using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerControllerSystem : MonoBehaviour
{
    [SerializeReference] private CharacterController character;
    [SerializeReference] private GameObject relectiveObject;
    [SerializeReference] private float gravaity = 9.8f;
    [SerializeReference] private float speed_V;
    [SerializeReference] private float speed_H;
    [SerializeReference] private float speed_H_Max;
    [SerializeReference] private float acc_H;
    [SerializeReference] private float height_Jump;
    [SerializeReference] private float height_Jump_PC;

    [SerializeReference] private bool jump;
    [SerializeReference] private bool grounded;
    [SerializeReference] private bool enableHMove = true;
    [SerializeReference] private EyeFilter eyeFilter;



    private void Start()
    {
        if (character == null) character = GetComponent<CharacterController>();
#if UNITY_STANDALONE_WIN
        height_Jump = height_Jump_PC;
#endif
    }

    private void Update()
    {
        GroundCheck();
        JumpCheck();
        Physics();
        CharMove();
    }

    void GroundCheck()
    {
        grounded = character.isGrounded;
    }

    public void AddHMoveForce_Grouned(float f)
    {
        if (grounded) speed_H += f;
    }
    public void AddHMoveForce_UnGrouned(float f)
    {
        speed_H += f;
    }

    public void Jumpping()
    {
        jump = true;
    }

    void JumpCheck()
    {
        if (jump)
        {
            speed_V = height_Jump;
            
        }
    }

    void CharMove()
    {
        Vector3 vector = new Vector3(0,0,speed_H);
        Quaternion quaternion = relectiveObject.transform.rotation;
        quaternion.z = 0;
        quaternion.x = 0;
        vector = quaternion* vector;
        Vector3 vector1 = new Vector3(0, speed_V, 0);
        if (eyeFilter != null) eyeFilter.SetTime(speed_H / speed_H_Max);
        character.Move((vector + vector1) * Time.deltaTime);
    }

    void Physics()
    {
        if (!grounded) speed_V -= gravaity;
        if(grounded && !jump) speed_V = -2f;
        jump = false;


        if (speed_H > 1 ) speed_H -= 0.01f;
        else
        {
            speed_H = 0;
        }

        if (speed_H > speed_H_Max) speed_H = speed_H_Max;
        if (!enableHMove) speed_H = 0;
        if (grounded) speed_H = 0;
    }

    public void SetHMoveEnable(bool a) => enableHMove = a;

    public void ResetPosision()
    {
        character.enabled = false;
        transform.localPosition = new Vector3(0, transform.localPosition.y,0);
        character.enabled = true;
    }
    public void ResetPosisionToZero()
    {
        character.enabled = false;
        transform.localPosition = new Vector3(0, 0,0);
        character.enabled = true;
    }


}
