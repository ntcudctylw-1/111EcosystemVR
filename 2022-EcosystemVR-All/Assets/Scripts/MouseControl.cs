using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MouseControl : MonoBehaviour
{
    public Camera uc;
    public Image Target;
    InputSet myInput;
    float presstime,cooldown = 2.0f; //不要被連點連選，間隔2000ms
    float MouseX, MouseY;
    int loadscene=-1;
    public Text mes; //顯示文字訊息
    public Text sid; //顯示學生資訊

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android) gameObject.SetActive(false);
        mes.text = "";
        sid.text = GlobalSet.SID;
        presstime = Time.realtimeSinceStartup;
        myInput = new InputSet();
        myInput.PCVR.Enable();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - presstime > cooldown && loadscene!=-1)
        {
            SceneManager.LoadScene(loadscene);
        }
        float HorizontalSensitivity = 100.0f;
        float VerticalSensitivity = 100.0f;

        Vector2 mp = myInput.PCVR.MouseSys.ReadValue<Vector2>();
        MouseX = mp.x;
        MouseY = mp.y;
        
        float RotationX = HorizontalSensitivity * MouseX * Time.deltaTime;
        float RotationY = VerticalSensitivity * MouseY * Time.deltaTime;

        Vector3 CameraRotation = uc.transform.rotation.eulerAngles;

        CameraRotation.x -= RotationY;
        CameraRotation.y += RotationX;

        uc.transform.rotation = Quaternion.Euler(CameraRotation);

        Ray ray = new Ray(transform.position, uc.transform.forward * 100);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            Target.rectTransform.sizeDelta = new Vector2(130, 130);
            string Feature = hit.collider.gameObject.name;
            if (Feature.Substring(0, 2) == "CH")
            {
                if (Feature == "CH1") mes.text = "單元1.生物多樣性";
                else if (Feature == "CH2") mes.text = "單元2.台灣的多樣化環境";
                else if (Feature == "CH3") mes.text = "單元3.生物生存適應";
                else if (Feature == "CH4") mes.text = "單元4.外來入侵種對台灣的影響";
                else if (Feature == "CH5") mes.text = "單元5.候鳥遷徙";
                else if (Feature == "CH6") mes.text = "單元6.淺山生態與石虎";
                if (Mouse.current.leftButton.isPressed && Time.realtimeSinceStartup - presstime > cooldown) //選擇目標物
                {
                    presstime = Time.realtimeSinceStartup;                    
                    GameObject.Find("SelectEffect").GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                    loadscene = int.Parse(Feature.Substring(2, 1))+1;                    
                }
            }
            else //有打到物體，但不是選項
            {
                Target.rectTransform.sizeDelta = new Vector2(80, 80);
                mes.text = "";
            }
            
        }
        else //沒打到物體
        {
            Target.rectTransform.sizeDelta = new Vector2(80, 80);
            mes.text = "";
        }
    }  
}
