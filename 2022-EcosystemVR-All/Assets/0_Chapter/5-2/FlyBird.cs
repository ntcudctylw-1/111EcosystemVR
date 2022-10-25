using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    [SerializeReference]
    float offset = 1f;
    [SerializeReference]
    float speed = 1f;
    [SerializeReference]
    int round = 10;
    int key = 0;
    void Start()
    {
        GetComponent<Animator>().Play("Fly");
        GetComponent<Animator>().speed = Random.Range(0.7f, 1.5f);
    }

    private void Update()
    {
        key++;
        if (key > round) key = -round;
        transform.Translate(0, offset * speed * Time.deltaTime * Mathf.Sign(key) * Random.Range(0.7f,5f), 0);
    }
}
