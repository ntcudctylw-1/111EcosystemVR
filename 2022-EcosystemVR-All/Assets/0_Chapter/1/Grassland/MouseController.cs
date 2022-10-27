using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
    Ray ray; //射線
    float raylength = 100f; //射線最大長度
    RaycastHit hit; //被射線打到的物件
    string hitname = "";
    public static GameObject hitObject;
    public GameObject Aim;

    // Start is called before the first frame update
    void Start()
    {
        if (DisableWhenPC.IsPC == false)
        {
            Aim.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()  
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //由攝影機射到是畫面正中央的射線

        if (Physics.Raycast(ray, out hit, raylength))
        // (射線,out 被射線打到的物件,射線長度)，out hit 意思是：把"被射線打到的物件"帶給hit
        {
            hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
            //向被射線打到的物件呼叫名為"HitByRaycast"的方法，不需要傳回覆

            Debug.DrawLine(ray.origin, hit.point, Color.yellow);
            //當射線打到物件時會在Scene視窗畫出黃線，方便查閱
            hitname = hit.transform.name;
            hitObject = GameObject.Find(hitname);
            //print(hit.transform.name);
            //在Console視窗印出被射線打到的物件名稱，方便查閱                       
        }
        else
        {            
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("LevelController").GetComponent<LevelController>().CheckAnimalFeature(hitname);
            GameObject.Find("LevelController").GetComponent<GameController>().PCDown(hitObject);
        }
        if (hitname.Contains("Terrain") || hitname.Contains("Ground") || hitname.Contains("floor") || hitname == "")
        {
            Aim.GetComponent<RawImage>().color = new Color (255, 0, 0, 255);
        }
        else
        {
            Aim.GetComponent<RawImage>().color = new Color (255, 255, 255, 255);
        }
    }
}
