using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public GameObject Player;
    public int Level=0;

    private void Update()
    {
        if(Level == 0)
        {
            Level_0();
        }
    }
    public void Level_0()
    {
        if(Player.transform.position.z > -45.539f)
        {
            Level = 1;
        }
    }

    public void Level_1()
    {
        if (Level == 1)
        {
            Level = 2;
        }
        
    }
    public void Level_2()
    {
        if (Level == 2)
        {
            Level = 3;
        }
    }
}
