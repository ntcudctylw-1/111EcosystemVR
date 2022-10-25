using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HMDController : MonoBehaviour
{
    public List<string> displayTexts;
    public Text text;
    public GameObject nextBut, closeBut;
    int stringid = 0;
    public GameObject rightController;
    
    public void close()
    {
        //FindObjectOfType<CatFirstPersonController>().enabled = true;
        stringid = 0;
        rightController.SetActive(false);
        displayTexts = new List<string>();
        this.gameObject.SetActive(false);
    }

    public void next() => stringid++;

    private void Awake()
    {

        
    }



    public void UpdateState()
    {
        stringid = 0;
        rightController.SetActive(true);
        
        if (displayTexts.Count == 0) this.gameObject.SetActive(false);
        text.text = displayTexts[stringid];
    }

    private void Update()
    {
        //sprint(stringid);
        text.text = displayTexts[stringid];
        bool go = displayTexts.Count - 1 == stringid;
        closeBut.SetActive(go);
        nextBut.SetActive(!go);
    }
}
