using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRespawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    private static Transform[] staticSpawnPoints;

    [SerializeReference]
    private static CharacterController player;
    [SerializeReference]
    private static GameObject chickens;


    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        chickens = GameObject.Find("ChickenDrag");
        staticSpawnPoints = spawnPoints;
    }

    public static void spawn( int id)
    {
        player.enabled = false;

        player.transform.position = staticSpawnPoints[id].transform.position;
        player.transform.rotation = staticSpawnPoints[id].transform.rotation;
        player.enabled = true;
        if(chickens.transform.childCount > 0)
        {
            Destroy(chickens.transform.GetChild(0).gameObject);
        }

    }
}
