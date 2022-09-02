using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ch5_diractor : MonoBehaviour
{
    public int step = 0;

    public CharacterControllerPhysics controllerPhysics;
    public GameObject ring_end;
    public int fishsEat = 0;
    public WebPhp php;


    private void Start()
    {
        ring_end.SetActive(false);
    }
    private void Update()
    {
        if (step == 0 )
        {
            //48
            step = 1;
            StartCoroutine(php.php(GlobalSet.SID, "5", "48", WebPhp.php_method.Action));
        }
        if (step == 1 && controllerPhysics.floating)
        {
            //49
            step = 2;
            StartCoroutine(php.php(GlobalSet.SID, "5", "49", WebPhp.php_method.Action));
        }

        if(step ==4 && fishsEat >= 3)
        {
            //52
            step = 5;
            ring_end.SetActive(true);
            StartCoroutine(php.php(GlobalSet.SID, "5", "52", WebPhp.php_method.Action));
        }
        if(step ==5 && controllerPhysics.floating)
        {
            //53
            step = 6;
            StartCoroutine(php.php(GlobalSet.SID, "5", "53", WebPhp.php_method.Action));
        }
        
    }

    public void findEnd()
    {
        if (step == 2)
        {
            //50
            step = 3;
            StartCoroutine(php.php(GlobalSet.SID, "5", "50", WebPhp.php_method.Action));
        }
    }

    public void arrivedEnd()
    {
        if (step == 3)
        {
            //51
            step = 4;
            StartCoroutine(php.php(GlobalSet.SID, "5", "51", WebPhp.php_method.Action));
        }
    }
    public void findStart()
    {
        if (step == 6)
        {
            //54
            step = 7;
            StartCoroutine(php.php(GlobalSet.SID, "5", "54", WebPhp.php_method.Action));
        }
    }
    public void arrivedStart()
    {
        if (step == 7)
        {
            //55
            step = 8;
            StartCoroutine(php.php(GlobalSet.SID, "5", "55", WebPhp.php_method.Action));
            //SceneManager.LoadScene("");//¶^®Ï§j∆U
        }
    }


}
