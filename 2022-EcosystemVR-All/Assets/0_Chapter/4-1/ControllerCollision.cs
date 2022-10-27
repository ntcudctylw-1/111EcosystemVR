using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "grid")
        {
            //print(other.name);
            other.GetComponent<Ch4_Grid>().RemoveFlower();
            other.GetComponent<BoxCollider>().enabled = false;
            Score.AddScore();
        }
    }
}
