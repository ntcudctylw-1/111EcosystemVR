using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public Transform lookAt,target;
    public bool enableLookat = true;
    public float autopilotDistence;
    public float autopilotSpeed;

    void Update()
    {
        if (enableLookat)
        {
            lookAt.position = new Vector3(lookAt.position.x, transform.position.y, lookAt.position.z);
            transform.LookAt(lookAt);
        }


        print((transform.position - target.position).magnitude );
        if((transform.position - target.position).magnitude < autopilotDistence)
        {
            enableLookat = false;
            StartCoroutine(Autopolit());
        }

    }

    IEnumerator Autopolit()
    {
        GetComponent<CharacterControllerPhysics>().enabled = false;
        while ((transform.position - lookAt.position).magnitude > 2f) 
        {
            transform.position = Vector3.Lerp(transform.position, target.position, autopilotSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = target.position;
        GetComponent<CharacterControllerPhysics>().enabled = true;
        GetComponent<LookAtObject>().enabled = false;
    }
}
