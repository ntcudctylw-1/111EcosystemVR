using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(WebPhp))]
public class HMDEvents : MonoBehaviour
{
    [Serializable]
    public class HMDEvent
    {
        public string tip;
        public List<string> contents;
        public int MID;
    }
    public HMDController controller;
    public List<HMDEvent> hMDEvents;
    WebPhp web;
    


    public void EventTriggered(int id)
    {

        FindObjectOfType<CatFirstPersonController>().enabled = false;
        controller.displayTexts = hMDEvents[id].contents;
        controller.gameObject.SetActive(true);
        controller.GetComponent<HMDController>().UpdateState();
        web.php(GlobalSet.SID, GlobalSet.LID, hMDEvents[id].MID.ToString(), WebPhp.php_method.Action);
    }

    private void Start()
    {

        web = this.GetComponent<WebPhp>();
    }
}
