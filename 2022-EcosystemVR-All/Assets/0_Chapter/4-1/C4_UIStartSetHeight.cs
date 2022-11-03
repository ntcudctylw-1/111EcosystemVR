using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C4_UIStartSetHeight : MonoBehaviour
{
    [SerializeReference]
    private GameObject Camera;
    [SerializeReference]
    private float speed = 0.1f;
    [SerializeReference]
    public float offset = 0f;


    private void Start()
    {
       
    }

    private void Update()
    {
        Vector3 temp = this.transform.position;
        temp.y = Camera.transform.position.y + offset;
        this.transform.position = Vector3.Slerp(this.transform.position,temp,speed*Time.deltaTime);
    }
}
