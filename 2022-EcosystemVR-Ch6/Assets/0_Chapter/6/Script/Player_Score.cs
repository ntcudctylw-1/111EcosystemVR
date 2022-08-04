using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Score : MonoBehaviour
{
    public int Hp = 3;
    public int Food = 1;

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
}
