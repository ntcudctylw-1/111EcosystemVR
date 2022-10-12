using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    /*
    public class task
    {
        public string tip;
    }*/
    [SerializeField]
    public static string currentTask;
    public List<string> task;

    public void setCurrent(int id)
    {
        currentTask = task[id];
    }
    
}
