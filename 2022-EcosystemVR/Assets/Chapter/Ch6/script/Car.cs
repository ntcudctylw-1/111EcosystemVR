using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int EveryXSecSpawn = 3;
    public float Car_Speed = 100;
    public GameObject Prefab;
    public GameObject[] Cars;
    

    private void Awake()
    {
        InvokeRepeating("Spawn", 1, EveryXSecSpawn);
        
    }
     
    private void Update()
    {
        foreach (var item in Cars)
        {
            if (item == null) continue;
            //Debug.Log("!!");
           item.transform.position =   Vector3.Lerp(item.transform.position, item.transform.position + new Vector3(200, 0, 0), Car_Speed);
        }
    }



    void Spawn()
    {
        Cars[Cars.Length-1] = Instantiate(Prefab, this.transform).gameObject;
        Destroy(Cars[0]);
        for(int i = 1; i < Cars.Length; i++)
        {
            Cars[i - 1] = Cars[i];
        }

    }
}
