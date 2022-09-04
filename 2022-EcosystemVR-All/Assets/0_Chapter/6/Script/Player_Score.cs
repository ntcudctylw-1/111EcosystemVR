using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour
{
    public int Hp = 3;
    public int Food = 1;
    public Image Image;

    public void Eat_Lemon()
    {
        Food += 1;
        GetComponent<Levels>().Level_1();       
    }
    
    public void Car_Accident()
    {
        Hp -= 1;
        
    }
    
    public void Eat_Chicken()
    {
        Food += 2;
        GetComponent<Levels>().Level_2();
        GetComponent<Animate_New>().Play();
        
    }

    private void Update()
    {
        if (Hp == 3)
        {
            Image.fillAmount = 1;
        }if (Hp == 2)
        {
            Image.fillAmount = 0.65f;
        }if (Hp == 1)
        {
            Image.fillAmount = 0.35f;
        }if (Hp == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void Start()
    {
        Image.fillAmount = 1;
    }
}
