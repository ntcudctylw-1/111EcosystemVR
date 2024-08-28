using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDisable : MonoBehaviour
{
    public GameObject[] objects;
    void Start()
    {
        int enableIndex = Random.Range(0, objects.Length);
        for(int i = 0; i < objects.Length; i++)
        {
            if(i != enableIndex)
            {
                objects[i].SetActive(false);
            }else
            {
                objects[i].SetActive(true);
            }   
        }
    }

}
