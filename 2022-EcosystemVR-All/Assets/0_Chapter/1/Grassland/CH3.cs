using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation.Examples;
using Random=UnityEngine.Random;

<<<<<<< Updated upstream
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
=======
public class CH3 : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Canvas3;

    public GameObject TemAndRain;
    public Text Tem3_1;
    public Text Tem3_2;
    public Text Rain3_1;
    public Text Rain3_2;

    public Text TargetText;
    public GameObject AnsButton1;
    public GameObject AnsButton2;
    public GameObject AnsButton3;
    public GameObject AnsButton4;

    public GameObject Lion;
    public Animator LionAn;
    public GameObject Cat;
    public Animator CatAn;
    public GameObject Bird;
    public Animator BirdAn;
    public GameObject Snake;
    public Animator SnakeAn;
    public GameObject Lizard;
    public Animator LizardAn;

    public int CH3Level = 0;

    // Start is called before the first frame update
    void Start()
    {
        Ch3Go();
    }

    // Update is called once per frame
    void Update()
    {
        
>>>>>>> Stashed changes
    }

    public void Ch3Go()
    {
<<<<<<< Updated upstream
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
=======
        if (CH3Level == 0)
        {
            Lion.GetComponent<PathFollower>().enabled = true;
            LionAn.Play("run");
        }
        else if (CH3Level == 1)
        {
            Cat.GetComponent<PathFollower>().enabled = true;
            CatAn.Play("run");
        }
        else if (CH3Level == 2)
        {
            Bird.GetComponent<PathFollower>().enabled = true;
            BirdAn.Play("run");
        }
        else if (CH3Level == 3)
        {
            Snake.GetComponent<PathFollower>().enabled = true;
            SnakeAn.Play("run");
        }
        else if (CH3Level == 4)
        {
            Lizard.GetComponent<PathFollower>().enabled = true;
            LizardAn.Play("run");
        }
        Invoke("AnStop", 3f);
    }

    public void AnStop()
    {
        LionAn.Play("idle");
        /*CatAn.Play("idle");
        BirdAn.Play("idle");
        SnakeAn.Play("idle");
        LizardAn.Play("idle");*/
        Lion.GetComponent<PathFollower>().enabled = false;
>>>>>>> Stashed changes
    }
}
