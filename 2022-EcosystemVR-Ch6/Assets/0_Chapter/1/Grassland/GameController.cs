using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation.Examples;

public class GameController : MonoBehaviour
{
    public static int Score1 = 0;
    public static int Score2 = 0;
    public GameObject CollAnimal;
    public GameObject PenguinFa;
    public Animation PenguinAnimation;
    public GameObject RightHandController;
    public void OnCollisionEnter(Collision animal)
    {
        CollAnimal = animal.gameObject;
        Animator CollAnimalAn = animal.gameObject.GetComponent<Animator>();
        if (animal.gameObject.name == "Penguin")
        {
            PenguinFa = animal.transform.parent.gameObject;
            PenguinFa.transform.position = new Vector3(248.360001f, -0.2f, 99.4599991f);
            animal.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            animal.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            animal.gameObject.transform.position = new Vector3(248.360001f, 0.759000003f, 99.4599991f);
            animal.gameObject.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        animal.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        RightHandController.GetComponent<XRRayInteractor>().enabled = false;
        CollAnimalAn.ResetTrigger("live");
        if (LevelController.finalgame == 1)
        {
            if (animal.gameObject.name == "Lion" || animal.gameObject.name == "Zebra")
            {
                Score1++;
                CollAnimalAn.Play("live", 0, 0f);
                Invoke("AnimalFalse", 2);
            }
            else
            {
                /*if (animal.gameObject.name == "Penguin")
                {
                    PenguinAnimation = CollAnimal.GetComponent<Animation>();
                    PenguinAnimation.Play("")
                }*/
                CollAnimalAn.Play("dead", 0, 0f);
                Invoke("AnimalFalse", 2);
            }
        }
        else if (LevelController.finalgame == 2)
        {
            if (animal.gameObject.name == "Penguin" || animal.gameObject.name == "Bear" || animal.gameObject.name == "Sealdog")
            {
                Score2++;
                Invoke("AnimalFalse", 2);
            }
            else
            {
                CollAnimalAn.Play("dead", 0, 0f);
                Invoke("AnimalFalse", 2);
            }
        }
    }

    public void AnimalFalse()
    {
        CollAnimal.SetActive(false);
        RightHandController.GetComponent<XRRayInteractor>().enabled = true;
    }
}
