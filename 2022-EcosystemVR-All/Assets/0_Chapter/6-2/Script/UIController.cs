using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public int currentTaskID;
    [SerializeField]
    public List<Task> tasks;
    public List<Image> hp;
    public Color ActivateTaskColor, DeactivateTaskColor;

    [System.Serializable]
    public class Task
    {
        public string name;
        public Text textObj;
        public int totleTimes;
        public int currentTimes;
    }



    private void Update()
    {
        for (int i = 0; i < hp.Count; i++)
            hp[i].gameObject.SetActive(i <= CatHealth.hp-1);

        for (int i = 0; i < tasks.Count; i++)
        {
            if (i == currentTaskID)
                tasks[i].textObj.color = ActivateTaskColor;
            else
                tasks[i].textObj.color = DeactivateTaskColor;
            tasks[i].textObj.text = string.Format("{0}({1}/{2})", tasks[i].name, tasks[i].currentTimes, tasks[i].totleTimes);
            if (i== currentTaskID &&tasks[i].currentTimes == tasks[i].totleTimes) currentTaskID++;

        }
            
    }
    public void TaskTimesPlus(int taskID)
    {
        tasks[taskID].currentTimes++;
    }
}
