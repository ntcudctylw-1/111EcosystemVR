using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sqlserver : MonoBehaviour
{

     public void go()
    {
        string url = "https://jingtw.tk/user/muji/sendoutcome.php";
        WWWForm form = new WWWForm();

        form.AddField("in_name", "name");
        form.AddField("in_sex", "sex");
        form.AddField("in_age", "121");
        form.AddField("in_outcome", "45454");
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}