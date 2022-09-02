using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject Player;
    public int Level=0;
    WebPhp web;
    private void Start()
    {
        web = GetComponent<WebPhp>();
        StartCoroutine( web.php(GlobalSet.SID.ToString(), "6", "57", WebPhp.php_method.Action));
    }

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
            StartCoroutine(web.php(GlobalSet.SID.ToString(), "6", "58", WebPhp.php_method.Action));
        }
    }

    public void Level_1()
    {
        if (Level == 1)
        {
            Level = 2;
            StartCoroutine(web.php(GlobalSet.SID.ToString(), "6", "59", WebPhp.php_method.Action));
        }
        
    }
    public void Level_2()
    {
        if (Level == 2)
        {
            Level = 3;
        }
    }
    public void Level_3()
    {
        if (Level == 3)
        {
            Level = 4;
            SceneManager.LoadScene("Lobby");

        }
    }
}
