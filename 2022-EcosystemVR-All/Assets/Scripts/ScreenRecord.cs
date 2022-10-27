using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Experimental.Rendering;

public class ScreenRecord : MonoBehaviour
{
    string url, port, path;
    string sid;
    public float RefreshPeroid; //sec
    public int MaxSerial = 1; //¦øªA¾¹³Ì¦hÀx¦sªºµe­±¼Æ¶q
    public int Quality; //ºI¹Ï«~½è 4¬O³Ì¦n 8¬O³Ì®t ¥i¿ï¾Ü4 6 8
    //public Text mes; //°£¿ù¥Î
    int ser = 0;
    DateTime pt;

    int tstep = -1;
    Texture2D screenshot;
    GraphicsFormat gf;
    uint sw, sh;
    byte[] bytes, rawbytes;
    WWWForm form;
    UnityWebRequest req;
    private Thread encoderThread;
    bool WebUploading = false;
    Stream requestStream;
    Stream fileStream;
    FtpWebRequest request;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        port = "2121";
        path = "/home/www";
        url = "ftp://" + GlobalSet.ScrRecIP + ":" + port + path + "/screen/";

        if (GlobalSet.SID == null) sid = "dct" + UnityEngine.Random.Range(1, 10); else sid = GlobalSet.SID;
        request = (FtpWebRequest)WebRequest.Create(url + sid);
        request.Method = WebRequestMethods.Ftp.MakeDirectory;
        request.UseBinary = true;
        request.UsePassive = true;
        request.KeepAlive = false;
        request.Credentials = new NetworkCredential("vreco", "~Vrdct3028");
        try { WebResponse response = request.GetResponse(); } catch (WebException e1) { }

        pt = DateTime.Now;
        WebUploading = false;
        encoderThread = new Thread(WebUpload);
        encoderThread.Start();
    }
    IEnumerator CaptureScreen()
    {
        Debug.Log("CaptureScreen ");
        yield return new WaitForEndOfFrame();
        screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        //screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        screenshot.Apply();
    }

    private void WebUpload()
    {
        while (true)
        {
            if (WebUploading)
            //if (!WebUploading)
            {
                Debug.Log("Encoding");
                bytes = ImageConversion.EncodeArrayToPNG(rawbytes, gf, sw, sh);
                fileStream = new MemoryStream(bytes);
                request = (FtpWebRequest)WebRequest.Create(url + sid + "/0.png");
                Debug.Log(url + sid + "/0.png");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;
                request.Timeout = 3000;
                request.Credentials = new NetworkCredential("vreco", "~Vrdct3028");
                Debug.Log("SetRequest");
                requestStream = request.GetRequestStream();
                fileStream.CopyTo(requestStream);
                requestStream.Flush();
                requestStream.Close();
                Debug.Log("Close");
                ser++;
                if (ser >= MaxSerial)
                {
                    ser = 0;
                }
                WebUploading = false;
                Debug.Log("Finish");
            }
        }
    }

    public bool AcceptAllCertificatePolicy(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }

    void Update()
    {
        if ((DateTime.Now - pt).TotalSeconds > RefreshPeroid || tstep != -1)
        {

            tstep++;
            Debug.Log("Uploading " + tstep.ToString());
            switch (tstep)
            {
                case 0:
                    pt = DateTime.Now;
                    StartCoroutine(CaptureScreen());
                    break;
                case 1:
                    screenshot = ScaleTexture(screenshot, Screen.width / Quality, Screen.height / Quality);
                    break;
                case 2:
                    rawbytes = screenshot.GetRawTextureData();
                    gf = screenshot.graphicsFormat;
                    sw = (uint)screenshot.width;
                    sh = (uint)screenshot.height;
                    Destroy(screenshot);
                    break;
                case 3:
                    WebUploading = true;
                    Debug.Log("WebUploading = true");
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

       UnityEngine.Debug.Log("¶}©l¡I¡I");

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
           UnityEngine.Debug.Log("¤W¶Ç¤¤¡I¡I");
           yield return new WaitForSeconds(0.1f);
       }

       UnityEngine.Debug.Log("µ²§ô¡I¡I");
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
