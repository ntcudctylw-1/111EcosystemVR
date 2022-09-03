using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_eaten : MonoBehaviour
{
    private void Awake()
    {
        
    }

    public float disapearRotation = 1.07f;
    public GameObject cAmera;
    public ch5_diractor ch5_Diractor;

    private void Update()
    {
        // print((cAmera.transform.rotation * new Vector3(0, 1, 0)));
        float temp = Vector3.Lerp(cAmera.transform.localRotation.eulerAngles, new Vector3(0, 1, 0), 0.1f).x;
        //print(temp);
        if(temp < disapearRotation && temp > 200)
        {
           this.gameObject.SetActive(false);
            ch5_Diractor.fishsEat++;
        }
    }
}
