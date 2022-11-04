using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class c5_Demo_ : MonoBehaviour
{
    public FlyCollider collider1,collider2;


    [SerializeReference]
    private HMDController controller;
    public List<string> displayTexts;
    Coroutine coroutine;

    public int time = 5;
    private void Update()
    {

        if (collider1.inTheCollider)
        {
            if (coroutine == null) coroutine = StartCoroutine(CountDown());
            controller.displayTexts[0] = displayTexts[1].ToString() + "\n" + time.ToString();

        }
        else
        {
            coroutine = null;
            controller.displayTexts[0] = displayTexts[0];
            StopAllCoroutines();
            time = 5;
        }
    }

    IEnumerator CountDown()
    {
        
        while(time >= 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }

        FindObjectOfType<HMDEvents>().EventTriggered(1);
        this.gameObject.SetActive(false);
        controller.gameObject.SetActive(false);
        
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Ch5-2");
    }


}
