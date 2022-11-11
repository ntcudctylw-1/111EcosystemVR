using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temperature : MonoBehaviour
{
    [SerializeReference]
    private Text temp, place;
    [SerializeField]
    private Image tempImage;
    [SerializeReference]
    private int currentTemp = 10;
    [SerializeReference]
    private float tempImageFill = 0.3f;

    //0.3 == 10?
    //1 == 30?

    public void setPlace(string a)
    {
        place.text = a;
        UpdateState();
    }

    public void setTemp(int a)
    {
        currentTemp = a;
        UpdateState();
    } 
    public void addTemp(int a)
    {
        StopAllCoroutines();
        StartCoroutine(slowlyAdd(currentTemp + a));
    }
    IEnumerator slowlyAdd(int target)
    {
        while(currentTemp != target)
        {
            currentTemp += (int)Mathf.Sign(target-currentTemp);
            UpdateState();
            yield return new WaitForSeconds(1);
        }

    }

    void UpdateState()
    {
        temp.text = currentTemp.ToString() + "°C";
        tempImageFill = 0.3f + (currentTemp-10) * 0.035f;
        tempImage.fillAmount = tempImageFill;
    }

    private void Start()
    {
        UpdateState();
    }
}
