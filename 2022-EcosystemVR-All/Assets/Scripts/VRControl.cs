using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControl : MonoBehaviour
{
    // Start is called before the first frame update
    float presstime, cooldown = 2.0f; //不要被連點連選，間隔2000ms
    int loadscene = -1;
    public Text mes; //顯示文字訊息
    public Text sid; //顯示學生資訊
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android) gameObject.SetActive(false);
        mes.text = "";
        sid.text = GlobalSet.SID;
        presstime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - presstime > cooldown && loadscene != -1)
        {
            print(loadscene);
            SceneManager.LoadScene(loadscene);
        }
    }

    public void HoverIn(string Feature)
    {
        if(Feature == "CH1") mes.text = "單元1.生物多樣性";
        else if (Feature == "CH2") mes.text = "單元2.台灣的多樣化環境";
        else if (Feature == "CH3") mes.text = "單元3.生物生存適應";
        else if (Feature == "CH4") mes.text = "單元4.外來入侵種對台灣的影響";
        else if (Feature == "CH5") mes.text = "單元5.候鳥遷徙";
        else if (Feature == "CH6") mes.text = "單元6.淺山生態與石虎";
    }
    public void HoverOut(string Feature)
    {
        mes.text = "";
    }
    public void CheckSelect(string Feature)
    {
        //RightHand.Trigger.OnPressing = inputActions.XRIRightHandInteraction.Activate.ReadValue<float>() == 1 ? true : false;
        mes.text = Feature;
        if (Feature.Substring(0, 2) == "CH")
        {
            mes.text=Feature;
            GameObject.Find("SelectEffect").GetComponent<AudioSource>().Play();
            GameObject.Find(Feature).transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            loadscene = int.Parse(Feature.Substring(2, 1))+1;
        }
    }

    /*public void OnSelectEntered(SelectEnterEventArgs args)
    {
        mes.text = "YAAAA";
    }*/
}
