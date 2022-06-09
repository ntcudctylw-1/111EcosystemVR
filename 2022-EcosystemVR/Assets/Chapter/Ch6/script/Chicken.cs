using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject chicken;
    public float Radius = 3;
    public float lerptime = 0.01f;
    public float move_dis = 1f;
    Vector3 target;
    private void Start()
    {
        chicken = this.transform.GetChild(0).gameObject;
        target = Vector3.zero;
        
        InvokeRepeating("Chicken_move", 1, 3);
    }
    private void Update()
    {
        chicken.transform.LookAt(target);
        chicken.transform.position = Vector3.Lerp(chicken.transform.position, this.transform.position + target, lerptime);
    }


    void Chicken_move()
    {
        target = new Vector3(Random.Range(-Radius, Radius), 0, Random.Range(-Radius, Radius));
        Debug.Log(target);
        move_dis = Random.Range(-move_dis, move_dis);
    }
    
}
