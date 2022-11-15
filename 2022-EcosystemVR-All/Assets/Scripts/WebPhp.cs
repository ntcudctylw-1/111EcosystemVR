using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class WebPhp : MonoBehaviour
{
    [System.Serializable]
    public enum php_method
    {
        Action,
        LevelInf,
        UserData
    }

    private void Start()
    {
        //StartCoroutine(php("0", "6", "0", php_method.Action));
    }

    public IEnumerator php(string sid, string lid,string mid,php_method method)
    {
        Debug.Log("WebPhp Called");
        yield return null;
        
        string doc = "";
        if (method == php_method.Action) doc = "Action.php";
        else if (method == php_method.LevelInf) doc = "LevelInf.php";
        else if (method == php_method.UserData) doc = "UserData.php";


        string strUrl = string.Format("http://www.ylw.idv.tw:81/~vreco/{3}?sid={0}&lid={1}&mid={2}", sid, lid, mid,doc);
        Debug.Log("URL="+strUrl);
        UnityWebRequest request = UnityWebRequest.Get(strUrl);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            GlobalSet.LID = "0";
            Debug.Log(request.error);
            yield break;
        }

        string html = request.downloadHandler.text;

        if (method == php_method.LevelInf)
        {
            Debug.Log("LID=" + html);
            GlobalSet.LID = html;
        }
        //  Debug.Log(html);
    }


}
