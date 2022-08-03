using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LemonTree : MonoBehaviour
{
    // Start is called before the first frame update
    public float SpawnChance = 0.3f;
    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("LemonTree");

        foreach(GameObject obj in objects)
        {
            for(int i = 0; i < obj.transform.childCount; i++)
            {
                if (Random.Range(0, 10) < SpawnChance*10)
                    obj.transform.GetChild(i).gameObject.SetActive(true);
                else
                    obj.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    }

    

}
