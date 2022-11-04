using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WebPhp))]
public class HMDEvents : MonoBehaviour
{
    [Serializable]
    public class HMDEvent
    {
        public bool guide = false;
        public string tip;
        public List<string> contents;
        public int MID;
    }
    public HMDController controller;
    public List<HMDEvent> hMDEvents;
    [SerializeField]
    WebPhp web;

    [Serializable]
    public class ShowEvent : UnityEvent { }

    [SerializeField]
    ShowEvent m_EventStart = new ShowEvent();
    [SerializeField]
    ShowEvent m_EventEnd = new ShowEvent();
    [SerializeField]
    ShowEvent m_EventEndScene = new ShowEvent();
    protected HMDEvents() { }
    private int currentID;
    public int endID;

    public ShowEvent onShowStart
    {
        get { return m_EventStart; }
        set { m_EventStart = value; }
    }
    
    public ShowEvent onShowEnd
    {
        get { return m_EventEnd; }
        set { m_EventEnd = value; }
    }
    public ShowEvent onShowEndScene
    {
        get { return m_EventEndScene; }
        set { m_EventEndScene = value; }
    }

    public void EventTriggered(int id)
    {
        currentID = id;
        if(GlobalSet.guideMode == GlobalSet.GuideMode.Self || hMDEvents[id].guide)
        {
            if(hMDEvents[id].contents.Count != 0)
            {
                print("Event: " + id.ToString());
                //FindObjectOfType<CatFirstPersonController>().enabled = false;
                m_EventStart.Invoke();
                controller.displayTexts = hMDEvents[id].contents;
                controller.gameObject.SetActive(true);
                controller.GetComponent<HMDController>().UpdateState();
            }
            
           
        }
        if (hMDEvents[id].MID != 0)
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, hMDEvents[id].MID.ToString(), WebPhp.php_method.Action));

    }

    private void Start()
    {

        web = this.GetComponent<WebPhp>();
    }

    public void closeEvent()
    {
        m_EventEnd.Invoke();
        if (currentID == endID) m_EventEndScene.Invoke();    }
}
