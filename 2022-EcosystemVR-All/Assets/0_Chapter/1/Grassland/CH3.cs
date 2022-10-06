using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation.Examples;
using Random=UnityEngine.Random;

//using System.Collections.IEnumerable;

public class CH3 : MonoBehaviour
{
    public Text TargetText;
    public GameObject HoldObject;
    public GameObject[] ShowAnimal;
    public GameObject[] HoldAnimal;
    public Animator[] AnArr;
    public GameObject[] CanvasArr;

    public GameObject LizardHp;
    public GameObject SnakeHp;

    public int CH3Level = 0;
    List<int> Order = new List<int>();
    
    public float[][][] PosArr = {new float[][] {
        new float[] {245.880005f,0.89200002f,92.3499985f},
        new float[] {245.899994f,0.89200002f,95.151001f},
        new float[] {243.529999f,0.89200002f,92.3499985f},
        new float[] {244.169998f,0.89200002f,94.4899979f},
        new float[] {244.119995f,0.89200002f,96.7300034f}}, new float[][] {
        new float[] {235.755661f,0.89200002f,92.0551605f},
        new float[] {235.160004f,0.89200002f,94.207901f},
        new float[] {233.926727f,0.89200002f,96.078476f},
        new float[] {237.746124f,0.89200002f,93.3045959f},
        new float[] {236.273865f,0.89200002f,95.6875458f}
        }};

    void Start()
    {
        RandomLevel();
        Ch3Go();
    }

    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            CanvasArr[i].transform.rotation = Camera.main.transform.rotation;    
        }
        //CanvasArr[Order[CH3Level]].transform.rotation = Camera.main.transform.rotation;
        if (GlobalSet.RightHand.ButtonB == true && HoldAnimal[Order[CH3Level]].activeSelf)
        {
            Down();
        }
    }

    public void RandomLevel()
    {
        for (int i = 0; i < 4; i++)
        {
            int random = Random.Range(0, 4);
            if (Order.Contains(random))
            {
                i--;
                continue;
            }
            else
            {
                Order.Add(random);
            }
        }
        Order.ToArray();
        for(int i = 0; i < 4; i++)
        {
            Debug.Log(Order[i]);
        }
    }

    public void Ch3Go()
    {
        ShowAnimal[Order[CH3Level]].GetComponent<PathFollower>().enabled = true;
        AnArr[Order[CH3Level]].Play("move");
        Invoke("AnStop", 3f);
    }

    public void AnStop()
    {
        AnArr[Order[CH3Level]].Play("idle");
        ShowAnimal[Order[CH3Level]].GetComponent<PathFollower>().enabled = false;
    }

    public void Hold()
    {
        ShowAnimal[Order[CH3Level]].SetActive(false);
        HoldAnimal[Order[CH3Level]].SetActive(true);
    }

    public void Down()
    {
        HoldAnimal[Order[CH3Level]].SetActive(false);
        ShowAnimal[Order[CH3Level]].SetActive(true);
        if (HoldObject.transform.position.x > 240)
        {
            float PositionX = PosArr[0][CH3Level][0];
            float PositionY = PosArr[0][CH3Level][1];
            float PositionZ = PosArr[0][CH3Level][2];
            ShowAnimal[Order[CH3Level]].transform.position = new Vector3(PositionX, PositionY, PositionZ);
        }
        else
        {
            float PositionX = PosArr[1][CH3Level][0];
            float PositionY = PosArr[1][CH3Level][1];
            float PositionZ = PosArr[1][CH3Level][2];
            ShowAnimal[Order[CH3Level]].transform.position = new Vector3(PositionX, PositionY, PositionZ);
            Dead();
        }
        ShowAnimal[Order[CH3Level]].GetComponent<XRSimpleInteractable>().enabled = false;
        Invoke("NextRound", 3);
    }

    public void NextRound()
    {
        if (CH3Level != 3)
        {
            CH3Level++;
            Ch3Go();
        }
    }

    public void Dead()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            Invoke("Hp1",1);
            Invoke("Hp2",2);
            Invoke("Hp3",3);
        }
    }

    public void Hp1()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardHp.transform.localPosition = new Vector3(-0.25f, 0, 0);
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            //SnakeHp.transform.localPosition = new Vector3(-0.25f, 0, 0);
        }
    }
    public void Hp2()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardHp.transform.localPosition = new Vector3(-0.45f, 0, 0);
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            //SnakeHp.transform.localPosition = new Vector3(-0.45f, 0, 0);
        }
    }
    public void Hp3()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardHp.transform.localPosition = new Vector3(-0.72f, 0, 0);
            AnArr[Order[CH3Level]].Play("dead");
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            //SnakeHp.transform.localPosition = new Vector3(-0.72f, 0, 0);
        }
    }
}
