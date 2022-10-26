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
    public static int PositionCount = 0;
    public static int DeadNum = 0;
    public static int LiveNum = 0;
    public static Vector3 DeadPosition = new Vector3(248.360001f, 0.86f, 99.4599991f);
    public static int Score1 = 0;
    public static int Score2 = 0;
    public static int Ch2GameScore = 0;
    public Animator CollAnimalAn;
    public GameObject CollAnimal;
    public GameObject PenguinFa;
    public Animation PenguinAnimation;
    public GameObject RightHandController;

    public static bool DeadDone = true;
    public bool IsGrab = false;
    public GameObject[] GrabAnimal;
    public GameObject HoldAnimal;
    public bool[] Hold = {false, false, false, false, false};
    public Text TargetText;

    public float[][][] DeadPositionArr = {new float[][] 
    {new float[] {240.122f,0.779999971f,91.742f}
    , new float[] {238.084f,0.779999971f,91.742f}
    , new float[] {242.0606f,0.779999971f,91.742f}
    , new float[] {236.1227f,0.779999971f,91.742f}
    , new float[] {244.27f,0.779999971f,91.74f}
    , new float[] {234f,0.779999971f,91.7421f}}, new float[][]
    {new float[] {240.122f,0.779999971f,91.742f}
    , new float[] {238.084f,0.779999971f,91.742f}
    , new float[] {242.0606f,0.779999971f,91.742f}
    , new float[] {236.1227f,0.779999971f,91.742f}
    , new float[] {244.27f,0.779999971f,91.74f}
    , new float[] {234f,0.779999971f,91.7421f}}, new float[][]
    {new float[] {240.122f,0.779999971f,91.742f}
    , new float[] {238.084f,0.779999971f,91.742f}
    , new float[] {242.0606f,0.779999971f,91.742f}
    , new float[] {236.1227f,0.779999971f,91.742f}
    , new float[] {244.27f,0.779999971f,91.74f}
    , new float[] {234f,0.779999971f,91.7421f}}, new float[][]
    {new float[] {244.20079f,0.779999971f,99.7309494f}
    ,new float[] {244.460007f,0.779999971f,97.7099991f}
    ,new float[] {243.95f,0.779999971f,101.677f}
    ,new float[] {244.7f,0.779999971f,95.78f}
    ,new float[] {243.685f,0.779999971f,103.75f}
    ,new float[] {244.987f,0.779999971f,93.596f}}};

    public void OnCollisionEnter(Collision animal)
    {
        Debug.Log(PositionCount);
        TargetText = GameObject.Find("Target_Text").GetComponent<Text>();
        if (LevelController.ChNum == 0 || LevelController.ChNum == 1)
        {
            CollAnimal = animal.gameObject;
            CollAnimalAn = animal.gameObject.GetComponent<Animator>();
            if (PositionCount == 1)
            {
                DeadPosition = new Vector3(248.360001f, 0.56f, 101.4599991f);
            }
            else if (PositionCount == 2)
            {
                DeadPosition = new Vector3(248.360001f, 0.56f, 97.4599991f);
            }
            else if (PositionCount == 3)
            {
                DeadPosition = new Vector3(248.360001f, 0.56f, 103.4599991f);
            }
            else if (PositionCount == 4)
            {
                DeadPosition = new Vector3(248.360001f, 0.56f, 95.4599991f);
            }
            if (animal.gameObject.name == "Penguin2")
            {
                PenguinFa = animal.transform.parent.gameObject;
                //PenguinFa.GetComponent<BoxCollider>().enabled = false;
                PenguinFa.transform.position = DeadPosition;
                //animal.gameObject.transform.position = DeadPosition;
                animal.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
                animal.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else if (animal.gameObject.name == "Sealdog2")
            {
                animal.gameObject.transform.position = DeadPosition + new Vector3(0, 0.34f, 0);
                animal.gameObject.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            }
            else
            {
                animal.gameObject.transform.position = DeadPosition;
                animal.gameObject.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            }
            animal.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            RightHandController.GetComponent<XRRayInteractor>().enabled = false;
            CollAnimalAn.ResetTrigger("live");
            if (LevelController.finalgame == 1)
            {
                if (animal.gameObject.name == "Lion2" || animal.gameObject.name == "Zebra2")
                {
                    Score1++;
                    CollAnimalAn.Play("idle", 0, 0f);
                    Invoke("AnimalFalse", 2.5f);
                    LiveNum++;
                }
                else
                {
                    if (animal.gameObject.name == "Penguin2")
                    {
                        PenguinAnimation = CollAnimal.GetComponent<Animation>();
                        animal.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        Invoke("PlayPenguinDeadAn", 2);
                    }
                    Invoke("PlayDeadAn", 2);
                    Invoke("AnimalFalse", 2.5f);
                    DeadNum++;
                }
            }
            else if (LevelController.finalgame == 2)
            {
                if (animal.gameObject.name == "Penguin2" || animal.gameObject.name == "Bear2" || animal.gameObject.name == "Sealdog2")
                {
                    Score2++;
                    CollAnimalAn.Play("idle", 0, 0f);
                    Invoke("AnimalFalse", 2.5f);
                }
                else
                {
                    DeadNum++;
                    Invoke("PlayDeadAn", 2);
                    Invoke("AnimalFalse", 2.5f);
                }
            }
            PositionCount++;
            TargetText.text = "剩餘動物：" + (5 - PositionCount);
        }
    }

    public void AnimalFalse()
    {
        RightHandController.GetComponent<XRRayInteractor>().enabled = true;
    }

    public void PlayDeadAn()
    {
        DeadDone = true;
        CollAnimalAn.Play("dead", 0, 0f);
    }

    public void PlayPenguinDeadAn()
    {
        DeadDone = true;
        PenguinAnimation.Play("Dead");
    }

    public void Reset()
    {
        Debug.Log("00000000000");
        for (int i = 0; i < 5; i++)
        {
            Hold[i] = false;
        }
        IsGrab = false;
        PositionCount = 0;
        Debug.Log(PositionCount);
        Ch2GameScore = 0;
        DeadPosition = new Vector3(248.360001f, 0.86f, 99.4599991f);
    }

    public void PCDown(GameObject animal)
    {
        if (IsGrab == false)
        {
            if (animal.transform.name == "Zebra2" && Hold[0] == false && DeadDone == true)
            {
                animal.SetActive(false);
                HoldAnimal = animal;
                GrabAnimal[0].SetActive(true);
                IsGrab = true;
                Hold[0] = true;
            }
            else if (animal.transform.name == "Lion2" && Hold[1] == false && DeadDone == true)
            {
                animal.SetActive(false);
                HoldAnimal = animal;
                GrabAnimal[1].SetActive(true);
                IsGrab = true;
                Hold[1] = true;
            }
            else if (animal.transform.name == "Bear2" && Hold[2] == false && DeadDone == true)
            {
                animal.SetActive(false);
                HoldAnimal = animal;
                GrabAnimal[2].SetActive(true);
                IsGrab = true;
                Hold[2] = true;
            }
            else if (animal.transform.name == "Sealdog2" && Hold[3] == false && DeadDone == true)
            {
                animal.SetActive(false);
                HoldAnimal = animal;
                GrabAnimal[3].SetActive(true);
                IsGrab = true;
                Hold[3] = true;
            }
            else if (animal.transform.name == "Penguin2" && Hold[4] == false && DeadDone == true)
            {
                animal.SetActive(false);
                HoldAnimal = animal;
                GrabAnimal[4].SetActive(true);
                IsGrab = true;
                Hold[4] = true;
            }
        }
        else if (IsGrab == true)
        {
            Debug.Log(PositionCount);
            for (int i = 0; i < 5; i++)
            {
                GrabAnimal[i].SetActive(false);
            }
            IsGrab = false;
            HoldAnimal.SetActive(true);
            TargetText = GameObject.Find("Target_Text").GetComponent<Text>();
            if (LevelController.ChNum == 0 || LevelController.ChNum == 1)
            {
                CollAnimal = HoldAnimal;
                CollAnimalAn = HoldAnimal.GetComponent<Animator>();
                if (PositionCount == 1)
                {
                    DeadPosition = new Vector3(248.360001f, 0.56f, 101.4599991f);
                }
                else if (PositionCount == 2)
                {
                    DeadPosition = new Vector3(248.360001f, 0.56f, 97.4599991f);
                }
                else if (PositionCount == 3)
                {
                    DeadPosition = new Vector3(248.360001f, 0.56f, 103.4599991f);
                }
                else if (PositionCount == 4)
                {
                    DeadPosition = new Vector3(248.360001f, 0.56f, 95.4599991f);
                }
                if (CollAnimal.name == "Penguin2")
                {
                    PenguinAnimation = CollAnimal.GetComponent<Animation>();
                    PenguinAnimation.Play("idle");
                    PenguinFa = CollAnimal.transform.parent.gameObject;
                    PenguinFa.transform.position = DeadPosition;
                    CollAnimal.transform.localPosition = new Vector3(0, 0, 0);
                    PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
                    CollAnimal.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                else if (CollAnimal.name == "Sealdog2")
                {
                    CollAnimal.transform.position = DeadPosition + new Vector3(0, 0.34f, 0);
                    CollAnimal.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
                }
                else
                {   
                    CollAnimal.transform.position = DeadPosition;
                    CollAnimal.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
                }
                CollAnimal.GetComponent<XRGrabInteractable>().enabled = false;
                CollAnimalAn.ResetTrigger("live");
                if (LevelController.finalgame == 1)
                {
                    if (CollAnimal.name == "Lion2" || CollAnimal.name == "Zebra2")
                    {
                        Score1++;
                        CollAnimalAn.Play("idle", 0, 0f);
                        LiveNum++;
                    }
                    else
                    {
                        if (CollAnimal.name == "Penguin2")
                        {
                            PenguinAnimation = CollAnimal.GetComponent<Animation>();
                            CollAnimal.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                            Invoke("PlayPenguinDeadAn", 2);
                        }
                        DeadDone = false;
                        Invoke("PlayDeadAn", 2);
                        DeadNum++;
                    }
                }
                else if (LevelController.finalgame == 2)
                {
                    if (CollAnimal.name == "Penguin2" || CollAnimal.name == "Bear2" || CollAnimal.name == "Sealdog2")
                    {
                        Score2++;
                        CollAnimalAn.Play("idle", 0, 0f);
                    }
                    else
                    {
                        DeadDone = false;
                        DeadNum++;
                        Invoke("PlayDeadAn", 2);
                    }
                }
                PositionCount++;
                TargetText.text = "剩餘動物：" + (5 - PositionCount);
            }
        }
    }
}
