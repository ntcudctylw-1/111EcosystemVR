using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goto : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject XR;
    private void Start()
    {
        //SceneManager.LoadScene("ch6");
        //StartCoroutine(LoadYourAsyncScene("ch6"));
    }
    public void To_ch6()
    {
        SceneManager.LoadScene("ch6");
        
        //StartCoroutine(LoadYourAsyncScene("ch6"));
    }
    public void To_Menu()
    {
        SceneManager.LoadScene("menu");

    }


}
