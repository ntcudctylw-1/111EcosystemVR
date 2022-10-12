using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class m_ScreenRecord : MonoBehaviour
{
    [SerializeField]
    private string serverIP = "www.ylw.idv.tw";
    [SerializeField]
    private string port = "2121";
    [SerializeField]
    private string serverFolder = "/home/www/screen/";
    [SerializeField]
    private Platform platform;
    [SerializeField]
    private string user = "vreco";
    [SerializeField]
    private string password = "~Vrdct3028";
    [SerializeReference]
    private string localPath;
    [SerializeReference]
    private int quality = 4;

    [System.Serializable]
    public enum Platform
    {
        oculus,
        focus,
        pc
    }

    private void Start()
    {
        SwitchPlatform();
        CaptureScreen();
    }




    public void CaptureScreen() {
        ScreenCapture.CaptureScreenshot(localPath);
        print(localPath);
        Resize();
    }

    void Resize()
    {
        byte[] photo = File.ReadAllBytes(localPath);
        
        byte[] newPhoto = new byte[photo.Length / quality];
        for (int i = 0 ; i < photo.Length; i++)
        {
            if(i * quality > photo.Length)
            print(i * quality);
            newPhoto[i] = photo[i* quality];
        }
        File.WriteAllBytes(localPath, newPhoto);
    }

    void SwitchPlatform()
    {
        switch (platform)
        {
            case Platform.oculus:
                localPath = "/mnt/sdcard/tmp.png";
                break;
            case Platform.focus:
                localPath = "/mnt/sdcard/tmp.png";
                break;
            case Platform.pc:
                localPath = Application.persistentDataPath + "/tmp.png";
                break;
            default:
                break;
        }
    }

}
