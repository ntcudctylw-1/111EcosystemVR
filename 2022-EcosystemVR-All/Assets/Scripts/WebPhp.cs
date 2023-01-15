using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.IO;



public class WebPhp : MonoBehaviour
{
    public Text debugText;
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
        if (true)//儲存本地端
        {
            if (!File.Exists(GlobalSet.RecordPath))
            {
                Debug.LogWarning("No File");
                File.Create(GlobalSet.RecordPath);
            }
            GlobalSet.ContentRecord += string.Format("{0} {1} {2} {3},", sid, lid, mid, method);
#if !UNITY_EDITOR_OSX
            File.WriteAllText(GlobalSet.RecordPath, GlobalSet.ContentRecord);
#endif
            //Debug.Log(GlobalSet.ContentRecord);
            yield return null;
        }
        if (true)
        {
            Debug.Log("WebPhp Called");
            yield return null;

            string doc = "";
            if (method == php_method.Action) doc = "Action.php";
            else if (method == php_method.LevelInf) doc = "LevelInf.php";
            else if (method == php_method.UserData) doc = "UserData.php";


            string strUrl = string.Format("http://www.ylw.idv.tw:81/~vreco/{3}?sid={0}&lid={1}&mid={2}", sid, lid, mid, doc);
            Debug.Log("URL=" + strUrl);

            UnityWebRequest www = UnityWebRequest.Get(strUrl);
            yield return www.SendWebRequest();

            if (debugText != null) debugText.text = www.result.ToString();
            if (www.result != UnityWebRequest.Result.Success || !GlobalSet.NetworkMode)
            {
                GlobalSet.LID = "0";
                //Debug.Log(www.error);
            }
            else
            {
                string html = www.downloadHandler.text;

                if (method == php_method.LevelInf)
                {
                    Debug.Log("LID=" + html);
                    GlobalSet.LID = html;
                }
            }
            /*
            UnityWebRequest request = UnityWebRequest.Get(strUrl);

            yield return request.SendWebRequest();



            if (request.error)
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
            //  Debug.Log(html);*/


        }


        
    }


}
