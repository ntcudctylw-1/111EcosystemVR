using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Transform : MonoBehaviour
{
    [System.Serializable]
    public class CharactorArgument 
    {
        public float Gravity = 0.05f;
        public float Speed_Max = 1;
    }


    public GameObject XRCamera,Axis,Player,lookatpoint;
    public GameObject Cat;
    public CharactorArgument charactorArgument;
    public Vector3 XrOffset = Vector3.zero;
    CharacterController CharacterController_Cat, CharacterController_Player;

    private void Start()
    {
        if (GlobalSet.playMode != GlobalSet.PlayMode.VR)
        {
            this.GetComponent<Cat_Transform>().enabled = false; 
        }

        CharacterController_Cat = Cat.GetComponent<CharacterController>();
        CharacterController_Player = Player.GetComponent<CharacterController>();
    }
    private void Update()
    {
        //Debug.Log(XRCamera.transform.rotation.y);
        lookatpoint.transform.localPosition = new Vector3(0, 0, 4);
        Debug.Log(lookatpoint.transform.localPosition);



        Player_State_Update();
        Cat_State_Update();
        
    }

    void Player_State_Update()
    {
        Vector3 MoveDirection = Vector3.zero;
        if (GetComponent<VR_Gesture>().Is_Walking || GetComponent<PC_IsMoving>().Is_Walking )
        {
            //MoveDirection = new Vector3(lookatpoint.transform.localPosition.x, 0, lookatpoint.transform.localPosition.z);
            //MoveDirection = transform.TransformDirection(MoveDirection);
            MoveDirection = (lookatpoint.transform.position - Player.transform.position).normalized;
            MoveDirection *= charactorArgument.Speed_Max;
            //Debug.Log(MoveDirection);
        }

        CharacterController_Player.Move(MoveDirection * Time.deltaTime);
    }
    void Cat_State_Update()
    {
        

        Vector3 MoveDirection = Vector3.zero;
        MoveDirection += -(Cat.transform.position - XRCamera.transform.position);
        MoveDirection.y -= charactorArgument.Gravity;
        CharacterController_Cat.Move(MoveDirection);

        Transform New = lookatpoint.transform;
        New.position = new Vector3(New.position.x, Cat.transform.position.y, New.position.z);
        Cat.transform.LookAt(New);
    }



}
