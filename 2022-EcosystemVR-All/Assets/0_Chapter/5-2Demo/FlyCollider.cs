using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollider : MonoBehaviour
{
    
    public bool inTheCollider;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            inTheCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            inTheCollider =false;    
    }
}
