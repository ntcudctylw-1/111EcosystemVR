using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelBird : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Animator>().speed = Random.Range(0.7f, 1.5f);
    }

}
