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
    public GameObject Canvas;
    public AudioSource ButtonSound;
    public Text TargetText;
    public Text InfoText;
    public Text ButtonText;
    public Text DeadLiveText;

    public GameObject HoldObject;
    public GameObject[] ShowAnimal;
    public GameObject[] HoldAnimal;
    public Animator[] AnArr;
    public GameObject[] CanvasArr;
    
    public GameObject LizardHp;
    public GameObject SnakeHp;
    public Text LizardTem;
    public Text SnakeTem;

    public bool ButtonState;
    public int ButtonLevel = 0;
    public int CH3Level = 0;

    public int DeadNum = 0;
    public int LiveNum = 0;

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
    }

    void Update()
    {
        for (int i = 0; i < CanvasArr.Length; i++)
        {
            CanvasArr[i].transform.rotation = Camera.main.transform.rotation;    
        }
        if (GlobalSet.RightHand.Grip.OnPressing == true && HoldAnimal[Order[CH3Level]].activeSelf && GlobalSet.RightHand.Grip.OnPressing != ButtonState)
        {
            Down();
        }
        ButtonState = GlobalSet.RightHand.Grip.OnPressing;
    }

    public void RandomLevel()
    {
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, 5);
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
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(Order[i]);
        }
    }

    public void Ch3Go()
    {
        TargetText.text = "剩餘動物：" + (5 - CH3Level);
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
            LiveNum++;
            if (ShowAnimal[Order[CH3Level]].name == "Lizard" || ShowAnimal[Order[CH3Level]].name == "Snake")
            {
                Invoke("Tem1",1);
                Invoke("Tem2",2);
                Invoke("Tem3",3);
            }
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
        DeadLiveText.text = "存活：" + LiveNum + " " + "死亡：" + DeadNum;
        if (CH3Level != 4)
        {
            CH3Level++;
            Ch3Go();
        }
        else
        {
            TargetText.text = "剩餘動物：0";
            Invoke("EndCH3", 5);
        }
    }

    public void EndCH3()
    {
        Canvas.SetActive(true);
        TargetText.text = "";
        ButtonText.text = "回到主畫面";
        DeadLiveText.text = "";
        InfoText.text = "恭喜你完成本單元！在這個單元裡，\n有沒有學會怎麼分辨變溫跟恆溫動物呢？\n人類也是恆溫動物，\n那我們用來維持我們體溫的特徵是什麼呢？\n想一想，你還有認識哪些動物？\n牠們分別是屬於恆溫還是變溫動物呢？";
    }

    public void Dead()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard" || ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            DeadNum++;
            Invoke("Hp1",1);
            Invoke("Hp2",2);
            Invoke("Hp3",3);
        }
        else
        {
            LiveNum++;
        }
    }

    public void Hp1()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardHp.transform.localPosition = new Vector3(-0.25f, 0, 0);
            LizardTem.text = "50℃";
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            SnakeHp.transform.localPosition = new Vector3(-0.25f, 0, 0);
            SnakeTem.text = "50℃";
        }
    }
    public void Hp2()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardHp.transform.localPosition = new Vector3(-0.45f, 0, 0);
            LizardTem.text = "53℃";
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            SnakeHp.transform.localPosition = new Vector3(-0.45f, 0, 0);
            SnakeTem.text = "52℃";
        }
    }
    public void Hp3()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardHp.transform.localPosition = new Vector3(-0.72f, 0, 0);
            LizardTem.text = "55℃";
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            SnakeHp.transform.localPosition = new Vector3(-0.72f, 0, 0);
            SnakeTem.text = "56℃";
        }
        AnArr[Order[CH3Level]].Play("dead");
    }

    public void Tem1()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardTem.text = "44℃";
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            SnakeTem.text = "43℃";
        }
    }
    public void Tem2()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardTem.text = "42℃";
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            SnakeTem.text = "41℃";
        }
    }
    public void Tem3()
    {
        if (ShowAnimal[Order[CH3Level]].name == "Lizard")
        {
            LizardTem.text = "40℃";
        }
        else if (ShowAnimal[Order[CH3Level]].name == "Snake")
        {
            SnakeTem.text = "39℃";
        }
    }

    public void ButtonClick()
    {
        ButtonSound.Play();
        if (ButtonLevel == 0)
        {
            InfoText.text = "接下來會陸續出現幾種不同的動物，\n其中有變溫動物，也有恆溫動物。\n觀察動物身上的體溫，\n並幫助這些動物們\n移動至能讓牠們感到舒服的區域，\n小心不要讓牠們太熱或太冷了！";
        }
        else if (ButtonLevel == 1)
        {
            InfoText.text = "操作方式：\n用手把抓握和食指板機將動物抓起，\n將動物拖曳到區域後再次按下抓握將動物放下。";
            ButtonText.text = "開始";
        }
        else if (ButtonLevel == 2)
        {
            Canvas.SetActive(false);
            Ch3Go();
        }
        else
        {

        }
        ButtonLevel++;
    }
}
