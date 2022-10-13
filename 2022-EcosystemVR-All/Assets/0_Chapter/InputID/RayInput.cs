using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInput : MonoBehaviour
{
    GameObject[] trees;
    private void Start()
    {
        trees = GetComponentsInChildren<GameObject>();

        foreach (var item in trees)
        {
            if(Random.Range(1,10) > 5)
            {
                item.SetActive(false);
            }
        }
    }
}

