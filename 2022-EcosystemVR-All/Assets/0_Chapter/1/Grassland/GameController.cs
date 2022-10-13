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
            if (animal.gameObject.name == "Penguin")
            {
                PenguinFa = animal.transform.parent.gameObject;
                //PenguinFa.GetComponent<BoxCollider>().enabled = false;
                PenguinFa.transform.position = DeadPosition;
                //animal.gameObject.transform.position = DeadPosition;
                animal.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
                animal.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else if (animal.gameObject.name == "Sealdog")
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
                if (animal.gameObject.name == "Lion" || animal.gameObject.name == "Zebra")
                {
                    Score1++;
                    CollAnimalAn.Play("idle", 0, 0f);
                    Invoke("AnimalFalse", 2.5f);
                    LiveNum++;
                }
                else
                {
                    if (animal.gameObject.name == "Penguin")
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
                if (animal.gameObject.name == "Penguin" || animal.gameObject.name == "Bear" || animal.gameObject.name == "Sealdog")
                {
                    Score2++;
                    CollAnimalAn.Play("idle", 0, 0f);
                    Invoke("AnimalFalse", 2.5f);
                }
                else
                {
                    Invoke("PlayDeadAn", 2);
                    Invoke("AnimalFalse", 2.5f);
                }
            }
            PositionCount++;
            TargetText.text = "剩餘動物：" + (5 - PositionCount);
        }
        else
        {
            CollAnimal = animal.gameObject;
            CollAnimalAn = animal.gameObject.GetComponent<Animator>();
            float PositionX = DeadPositionArr[LevelController.Ch2GameLevel][PositionCount][0];
            float PositionY = DeadPositionArr[LevelController.Ch2GameLevel][PositionCount][1];
            float PositionZ = DeadPositionArr[LevelController.Ch2GameLevel][PositionCount][2];
            DeadPosition = new Vector3(PositionX, PositionY, PositionZ);
            animal.gameObject.transform.position = DeadPosition;
            if (LevelController.Ch2GameLevel == 3)
            {
                animal.gameObject.transform.LookAt(new Vector3(PositionX-1,PositionY,PositionZ));
            }
            else
            {
                animal.gameObject.transform.LookAt(new Vector3(PositionX,PositionY,PositionZ+1));
            }
            animal.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            RightHandController.GetComponent<XRRayInteractor>().enabled = false;
            if (LevelController.Ch2GameLevel == 0)
            {
                if (animal.gameObject.name == "Oncorhynchus")
                {
                    Ch2GameScore++;
                    Debug.Log(Ch2GameScore);
                    CollAnimalAn.Play("idle");
                    Invoke("AnimalFalse", 2.5f);
                }
                else
                {
                    Invoke("PlayDeadAn", 2);
                    Invoke("AnimalFalse", 2.5f);
                }
            }
            else if (LevelController.Ch2GameLevel == 1)
            {
                if (animal.gameObject.name == "Cat")
                {
                    Ch2GameScore++;
                    CollAnimalAn.Play("idle");
                    Invoke("AnimalFalse", 2.5f);
                }
                else
                {
                    Invoke("PlayDeadAn", 2);
                    Invoke("AnimalFalse", 2.5f);
                }
            }
            else if (LevelController.Ch2GameLevel == 2)
            {
                if (animal.gameObject.name == "Bird" || animal.gameObject.name == "Crab" || animal.gameObject.name == "Mudskipper")
                {
                    Ch2GameScore++;
                    CollAnimalAn.Play("idle");
                    Invoke("AnimalFalse", 2.5f);
                }
                else
                {
                    Invoke("PlayDeadAn", 2);
                    Invoke("AnimalFalse", 2.5f);
                }
            }
            else if (LevelController.Ch2GameLevel == 3)
            {
                if (animal.gameObject.name == "Fish")
                {
                    Ch2GameScore++;
                    CollAnimalAn.Play("idle");
                    Invoke("AnimalFalse", 2.5f);
                }
                else
                {
                    Invoke("PlayDeadAn", 2);
                    Invoke("AnimalFalse", 2.5f);
                }
            }
            PositionCount++;
        }
    }

    public void AnimalFalse()
    {
        RightHandController.GetComponent<XRRayInteractor>().enabled = true;
    }

    public void PlayDeadAn()
    {
        CollAnimalAn.Play("dead", 0, 0f);
    }

    public void PlayPenguinDeadAn()
    {
        PenguinAnimation.Play("Dead");
    }

    public static void Reset()
    {
        PositionCount = 0;
        Ch2GameScore = 0;
        DeadPosition = new Vector3(248.360001f, 0.86f, 99.4599991f);
    }
}
