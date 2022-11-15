using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public int currentTaskID;
    [SerializeField]
    public List<Task> tasks;
    public List<Image> hp;
    public Color ActivateTaskColor, DeactivateTaskColor;

    [Serializable]
    public class TaskFInishEvent : UnityEvent { }
    protected UIController()
    { }

    [System.Serializable]
    public class Task
    {
        public string name;
        public Text textObj;
        public int totleTimes;
        public int currentTimes;
        public bool finished;
        [SerializeField]
        public TaskFInishEvent m_TaskFInishEvent = new TaskFInishEvent();
        public TaskFInishEvent onFlap
        {
            get { return m_TaskFInishEvent; }
            set { m_TaskFInishEvent = value; }
        }
    }



    private void Update()
    {
        for (int i = 0; i < hp.Count; i++)
            hp[i].gameObject.SetActive(i <= CatHealth.hp-1);

        for (int i = 0; i < tasks.Count; i++)
        {
            
            if (!tasks[i].finished)
                tasks[i].textObj.color = ActivateTaskColor;
            else
                tasks[i].textObj.color = DeactivateTaskColor;
            tasks[i].textObj.text = string.Format("{0}({1}/{2})", tasks[i].name, tasks[i].currentTimes, tasks[i].totleTimes);
            if (!tasks[i].finished && tasks[i].currentTimes == tasks[i].totleTimes)
            {
                tasks[i].finished = true; 
                tasks[i].m_TaskFInishEvent.Invoke();
                currentTaskID++;
            }
            
        }
            
    }
    public void TaskTimesPlus(int taskID)
    {
        tasks[taskID].currentTimes++;
    }
}
