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
    private void Update()
    {
        debugText.text = Application.platform.ToString();
    }
}
