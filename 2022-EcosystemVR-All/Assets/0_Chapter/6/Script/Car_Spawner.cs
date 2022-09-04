using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;


public class Car_Spawner : MonoBehaviour
{
    public GameObject CarPrefab;
    public GameObject PatherCreater;
    public int EveryXSecondsSpawn = 5;
    public int DisappearTime = 20;
    public GameObject[] Cars;

    private void Start()
    {
        Cars = new GameObject[20];
        InvokeRepeating("Spwan", 0, EveryXSecondsSpawn);
    }

    void Spawn()
    {
        Cars[Cars.Length - 1] = Instantiate(CarPrefab, PatherCreater.transform).gameObject;
        Cars[Cars.Length - 1].GetComponent<PathFollower>().pathCreator = this.GetComponent<PathCreator>();
        Cars[Cars.Length - 1].SetActive(true);
        Destroy(Cars[0]);
        for (int i = 1; i < Cars.Length; i++) Cars[i - 1] = Cars[i];
        
    }
}
