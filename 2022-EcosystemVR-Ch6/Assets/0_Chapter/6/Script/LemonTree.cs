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
            if (Random.Range(0, 10) < 5)
            {
                obj.SetActive(false);
            }
                for (int i = 0; i < obj.transform.childCount; i++)
            {
                //Debug.Log(obj.name);
                if (Random.Range(0, 10) < SpawnChance*10)
                    obj.transform.GetChild(i).gameObject.SetActive(true);
                else
                    obj.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }

        objects = GameObject.FindGameObjectsWithTag("Lemon");

        foreach (GameObject obj in objects)
        {
            obj.transform.GetChild(0).transform.localPosition = Vector3.zero;
            

        }
    }

    

}
