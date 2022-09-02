using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject prefab;
    public float spawnChance = 0.3f;
    public Vector3 targetVector;
    public float time;

    private void Update()
    {
       if( Random.Range(0f,1f)> spawnChance)
       {
            StartCoroutine(NewFish());
        }
    }

    IEnumerator NewFish()
    {
        Vector3 vector = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f), transform.position.y, transform.position.z);
        GameObject fish = Instantiate(prefab, vector , new Quaternion(0,0,0,0));
        fish.SetActive(true);
        while((fish.transform.position -(transform.position + targetVector)).magnitude > 50f)
        {
            fish.transform.position = Vector3.Lerp(fish.transform.position, transform.position + targetVector, time * Time.deltaTime);
            yield return null;
        }
        Destroy(fish);
        
    }
}
