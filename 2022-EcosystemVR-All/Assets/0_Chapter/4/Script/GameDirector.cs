using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class GameDirector : MonoBehaviour
{
    public float timeLimit = 120f;
    public float timeLeft;
    public Image timer;
    public Text persentage;
    public GameObject startBut;

    public GameObject LeftCon, RightCon;
    public FlowerRandomSpawn1 flowerSpawner;
    public float flowerPersent;
    public static int score;

    private void Start()
    {
        startBut.SetActive(true);
        //flowerSpawner.enabled = false;
        LeftCon.GetComponent<XRRayInteractor>().enabled = true;
        LeftCon.GetComponent<XRInteractorLineVisual>().enabled = true;
        RightCon.GetComponent<XRRayInteractor>().enabled = true;
        RightCon.GetComponent<XRInteractorLineVisual>().enabled = true;
    }

    private void EndGame()
    {
        //startBut.SetActive(true);
        flowerSpawner.enabled = false;
        persentage.text = "分數：000";
        LeftCon.GetComponent<XRRayInteractor>().enabled = true;
        LeftCon.GetComponent<XRInteractorLineVisual>().enabled = true;
        RightCon.GetComponent<XRRayInteractor>().enabled = true;
        RightCon.GetComponent<XRInteractorLineVisual>().enabled = true;
    }

    public void StartGame()
    {
        
        startBut.SetActive(false);
        flowerSpawner.ResetFlower();
        LeftCon.GetComponent<XRRayInteractor>().enabled = false;
        LeftCon.GetComponent<XRInteractorLineVisual>().enabled = false;
        RightCon.GetComponent<XRRayInteractor>().enabled = false;
        RightCon.GetComponent<XRInteractorLineVisual>().enabled = false;


        timeLeft = timeLimit;
        StartCoroutine(UpdateFix());
    }

    IEnumerator UpdateFix()
    {
        while(timeLeft >= 0)
        {
            int count = 0;
            foreach (var item in flowerSpawner.flowers)
            {
                count += item.spawned.Count;
            }

            persentage.text = string.Format("分數：{0}", score);
            if (count == 25)
            {
                break;
            }

            timer.fillAmount = timeLeft / timeLimit ;
            timeLeft -= 0.1f;
            //print(timeLeft);
            yield return new WaitForSeconds(0.1f);
        }
        
        EndGame();

    }



}
