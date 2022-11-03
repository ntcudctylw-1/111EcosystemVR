using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEvent : MonoBehaviour
{
    public void PrintDebug(string a)
    {
        print(a);
    }

    public Text debugText;
    public Image image;
    private void Update()
    {
        //debugText.text = FindObjectOfType<ScreenRecord>().WebUploading.ToString();

    }
}
