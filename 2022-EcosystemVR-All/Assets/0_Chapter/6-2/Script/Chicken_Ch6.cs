using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Ch6 : MonoBehaviour
{
    public GameObject camera;
    public bool isScared = false;


    void Start()
    {
        GetComponent<Animator>().speed = Random.Range(1, 2f);
        this.transform.rotation = new Quaternion(0, Random.Range(0f, 1f), 0, Random.Range(0f, 1f));
        
    }

    
        
    public void getChicken()
    {
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);/*
        if(camera.transform.childCount == 0)
        {
            transform.parent = camera.transform;
            GetComponent<BoxCollider>().enabled = false;
            transform.localPosition = Vector3.zero;
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            GetComponent<Animator>().enabled = false;
            //GetComponent<Rigidbody>().useGravity = false;
        }*/

        foreach (var item in FindObjectsOfType<Chicken_Ch6>())
        {
            item.isScared = true;
        }

    }

    private void Update()
    {
        //camera.transform.localPosition = camera.transform.parent.transform.rotation * new Vector3(0, 0, 0.629f);
        if (isScared)
        {
            scared_voice();
            scared_random();
        }
    }

    

    private void scared_voice()
    {
        if(TryGetComponent<AudioSource>(out AudioSource audioSource))
        {
            audioSource.pitch = 1.2f;
            audioSource.volume =0.35f;
        }
    }

    private void scared_random()
    {
        if (TryGetComponent<RandomPlayAudio>(out RandomPlayAudio audio))
        {
            audio.setchance(0.8f);
        }
    }

}
