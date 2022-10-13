using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRespawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    private static Transform[] staticSpawnPoints;

    [SerializeReference]
    private static CharacterController player;

    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        staticSpawnPoints = spawnPoints;
    }

    public static void spawn( int id)
    {
        player.enabled = false;

        player.transform.position = staticSpawnPoints[id].transform.position;
        player.transform.rotation = staticSpawnPoints[id].transform.rotation;
        player.enabled = true;
    }
}
