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
            case "Lemon":
                print("Lemon");
                //print(hit.gameObject.TryGetComponent(out M_Collision coll));
                if (hit.gameObject.TryGetComponent(out M_Collision coll))
                {
                    //print("invoke");
                    coll.m_Event.Invoke();
                }
                break;
            case "Trap":
                if (hit.gameObject.TryGetComponent(out M_Collision coll2))
                {
                    //print("invoke");
                    coll2.m_Event.Invoke();
                }
                break;
            case "Chicken":
                if (hit.gameObject.TryGetComponent(out M_Collision coll3))
                {
                    //print("invoke");
                    coll3.m_Event.Invoke();
                }
                break;
        }


        
    }
}
