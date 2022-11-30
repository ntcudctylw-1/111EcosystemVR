using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Keyin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("123");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterID()
    {
        //Debug.Log("123");

        GlobalSet.SID =GameObject.Find("input").GetComponent<Text>().text;
        WebPhp webPhp = FindObjectOfType<WebPhp>();
        StartCoroutine(webPhp.php(GlobalSet.SID, "", "", WebPhp.php_method.UserData));
        SceneManager.LoadScene(1);
        
    }
}
