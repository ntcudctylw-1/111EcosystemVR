using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCh6 : MonoBehaviour
{
    public UIController controller;

    private void Start()
    {
        controller = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        if(CatHealth.hp <= 0)
        {
            EndScene();
        }
        if(controller.tasks[3].currentTimes == controller.tasks[3].totleTimes)
        {
            EndScene();
        }
    }

    void EndScene()
    {
        print("end");
        SceneManager.LoadScene("Menu");
    }
}
