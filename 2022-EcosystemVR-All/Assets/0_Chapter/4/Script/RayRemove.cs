using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRemove : MonoBehaviour
{
    // Start is called before the first frame update
    

    Camera camera;
    public FlowerRandomSpawn1 randomSpawn;
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log("1 "+objectHit.name);
                if (objectHit.tag == "grid")
                {
                    Debug.Log("2 " + objectHit.name);
                    print(hit);
                    GameObject game = objectHit.gameObject;
                        Debug.Log("3 " + objectHit.name);
                        if (randomSpawn.flowers[0].spawned.Contains(game) || randomSpawn.flowers[1].spawned.Contains(game))
                        {

                            randomSpawn.RemoveFlower(objectHit.gameObject);
                        }
                    
                    
                }
                
                
                
            }
        }
        
    }
}
