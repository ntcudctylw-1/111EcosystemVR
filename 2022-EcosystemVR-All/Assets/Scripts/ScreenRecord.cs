using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System.Net;
using System.Threading;

public class ScreenRecord : MonoBehaviour
{
    string url;
    string sid;
    public float RefreshPeroid; //sec
    public int MaxSerial = 1; //伺服器最多儲存的畫面數量
    public int Quality; //截圖品質 4是最好 8是最差 可選擇4 6 8
    public Text mes; //除錯用
    int ser = 0;
    float pt;

    int tstep = -1;
    Texture2D screenshot;
    byte[] bytes;
    WWWForm form;
    UnityWebRequest req;

    // Start is called before the first frame update
    void Start()
    {
        url = GlobalSet.ScrRecIP;
        sid = "dct"+ Random.Range(1, 10); //GlobalSet.SID;
        mes.text = sid;
    }
    IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();
        screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        //screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();
    }

    private async void WebUpload()
    {
        req.SendWebRequest();

        /*if (req.result == UnityWebRequest.Result.ConnectionError)
            Debug.Log(req.error);
        else
            Debug.Log(req.downloadHandler.text);*/
    }

    void Update()
    {
        if (Time.time - pt > RefreshPeroid || tstep!=-1)
        {
            tstep++;
            switch(tstep)
            {
                case 0:
                    pt = Time.time;
                    StartCoroutine(CaptureScreen());
                    break;
                case 1:
                    screenshot = ScaleTexture(screenshot, Screen.width / Quality, Screen.height / Quality);
                    break;
                case 2:
                    bytes = ImageConversion.EncodeArrayToPNG(screenshot.GetRawTextureData(), screenshot.graphicsFormat, (uint)screenshot.width, (uint)screenshot.height);
                    break;
                case 3:
                    form = new WWWForm();
                    form.AddField("SID", sid);
                    form.AddField("SNUM", ser);
                    form.AddBinaryData("files", bytes, ser + ".png", "image/png");
                    req = UnityWebRequest.Post("http://" + url + "/vrmonitor/Uploader.php", form);
                    req.SetRequestHeader("Access-Control-Allow-Origin", "*");
                    break;
                case 4:
                    WebUpload();
                    break;
                case 5:
                    Destroy(screenshot);
                    ser++;
                    if (ser >= MaxSerial)
                    {
                        ser = 0;
                    }
                    tstep = -1;
                    break;
            }           
        }
    }

    private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
        Color[] rpixels = result.GetPixels(0);
        float incX = ((float)1 / source.width) * ((float)source.width / targetWidth);
        float incY = ((float)1 / source.height) * ((float)source.height / targetHeight);
        for (int px = 0; px < rpixels.Length; px++)
        {
            rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth),
                              incY * ((float)Mathf.Floor(px / targetWidth)));
        }
        result.SetPixels(rpixels, 0);
        result.Apply();
        return result;
    }

    /*IEnumerator FTPUpload() //for PC
   {
       string path = Application.temporaryCachePath + "/temp.png";
       bool isUploading = false;

       UnityEngine.Debug.Log("開始！！");

       ThreadPool.QueueUserWorkItem((o) =>
       {
           using (WebClient client = new WebClient())
           {
               client.Credentials = new NetworkCredential("ylw", "1234");
               client.UploadFile("ftp://" + url + "/" + sid + ".png", "STOR", path);
           }
           isUploading = true;
       });

       while (!isUploading)
       {
           UnityEngine.Debug.Log("上傳中！！");
           yield return new WaitForSeconds(0.1f);
       }

       UnityEngine.Debug.Log("結束！！");
   }
   IEnumerator UploadMultipleFiles()
   {
       string[] path = new string[3];
       path[0] = "D:/File1.txt";
       path[1] = "D:/File2.txt";
       path[2] = "D:/File3.txt";

       UnityWebRequest[] files = new UnityWebRequest[path.Length];
       WWWForm form = new WWWForm();

       for (int i = 0; i < files.Length; i++)
       {
           files[i] = UnityWebRequest.Get(path[i]);
           yield return files[i].SendWebRequest();
           form.AddBinaryData("files[]", files[i].downloadHandler.data, Path.GetFileName(path[i]));
       }

       UnityWebRequest req = UnityWebRequest.Post("http://localhost/File%20Upload/Uploader.php", form);
       yield return req.SendWebRequest();

       if (req.result == UnityWebRequest.Result.ConnectionError)
           Debug.Log(req.error);
       else
           Debug.Log("Uploaded " + files.Length + " files Successfully");
   }

   IEnumerator Capture()
   {
       //ScreenCapture.CaptureScreenshot(Application.temporaryCachePath + "/temp.png");        
       fileData = File.ReadAllBytes(Application.temporaryCachePath + "/temp.png");
       tex = new Texture2D(2, 2);
       tex.LoadImage(fileData);
       newScreenshot=ScaleTexture(tex, Screen.width / 2, Screen.height / 2);
       bytes = newScreenshot.EncodeToPNG();
       File.WriteAllBytes(Application.temporaryCachePath + "/temp.png", bytes);
       yield return new WaitForEndOfFrame();
       Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
       screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
       screenshot.Apply();

       Texture2D newScreenshot = ScaleTexture(screenshot, Screen.width/2, Screen.height/2);

       byte[] bytes = newScreenshot.EncodeToPNG();
       //File.WriteAllBytes(Application.temporaryCachePath + "/temp.png", bytes);
   }
*/
}
