using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject fish_eaten;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "mouse")
        {
            fish_eaten.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
