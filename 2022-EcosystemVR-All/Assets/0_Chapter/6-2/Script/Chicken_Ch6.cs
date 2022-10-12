using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Ch6 : MonoBehaviour
{
    public GameObject camera;


    void Start()
    {
        GetComponent<Animator>().speed = Random.Range(1, 2f);
        this.transform.rotation = new Quaternion(0, Random.Range(0f, 1f), 0, Random.Range(0f, 1f));
        
    }

    
        
    public void getChicken()
    {

        if(camera.transform.childCount == 0)
        {
            transform.parent = camera.transform;
            GetComponent<BoxCollider>().enabled = false;
            transform.localPosition = Vector3.zero;
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            GetComponent<Animator>().enabled = false;
            //GetComponent<Rigidbody>().useGravity = false;
        }
        
    }

    private void Update()
    {
        //camera.transform.localPosition = camera.transform.parent.transform.rotation * new Vector3(0, 0, 0.629f);
    }

}
