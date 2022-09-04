using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjMoveByAxis : MonoBehaviour
{
    public GameObject ObjToMove,LookingAt,camera,cat;
    public float Time;

    [SerializeReference]
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Update()
    {
        //ObjToMove.transform.position += Vector3.Lerp(Vector3.zero, ButtonASAxisValue.SimulateAxisVector , Time);
        ObjToMove.transform.position += NewVector(ButtonASAxisValue.SimulateAxisVector,0)/Time;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(ButtonASAxisValue.SimulateAxisVector.x, 0, ButtonASAxisValue.SimulateAxisVector.z);
        controller.Move(move * UnityEngine.Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        /*if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/




        playerVelocity.y += gravityValue * UnityEngine.Time.deltaTime;
        controller.Move(playerVelocity * UnityEngine.Time.deltaTime);




        // Debug.Log(GlobalSet.HeadSet.Rotation);
        LookingAt.transform.position = NewVectortwo(camera.transform.forward,true,false,true)*10 + ObjToMove.transform.position;
        cat.transform.LookAt(LookingAt.transform);
        cat.transform.position = NewVectortwo(camera.transform.position, true, false, true);
    }
    Vector3 NewVector(Vector3 vector, float y)
    {
        Vector3 a = vector;
        
        a.y = y ;

        return a;
    }
    Vector3 NewVectortwo(Vector3 vector, bool x ,bool y , bool z)
    {
        Vector3 a = Vector3.zero;
        a.x = x ? vector.x : 0;
        a.y = y ? vector.y : 0;
        a.z = z ? vector.z : 0;
       
        return a;
    }
}
