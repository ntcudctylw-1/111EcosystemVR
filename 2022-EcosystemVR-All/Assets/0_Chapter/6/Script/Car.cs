using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;

public class Car : MonoBehaviour
{
    public int EveryXSecSpawn = 3;
    public float Car_Speed = 100;
    public GameObject Prefab,Spwner,Path;
    public GameObject[] Cars;
    

    private void Awake()
    {
        Prefab.GetComponent<PathFollower>().speed = Car_Speed;
        InvokeRepeating("Spawn", 1, EveryXSecSpawn);
        
    }
     
    private void Update()
    {

    }



    void Spawn()
    {
        Cars[Cars.Length-1] = Instantiate(Prefab, Spwner.transform).gameObject;
        Cars[Cars.Length - 1].GetComponent<PathFollower>().pathCreator = Path.GetComponent<PathCreator>();
        Cars[Cars.Length - 1].SetActive(true);
        Destroy(Cars[0]);
        for(int i = 1; i < Cars.Length; i++)
        {
            Cars[i - 1] = Cars[i];
        }

    }
}
