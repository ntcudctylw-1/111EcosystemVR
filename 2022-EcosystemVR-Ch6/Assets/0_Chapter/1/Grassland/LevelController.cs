using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation.Examples;
using Random=UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    WebPhp web;
    public GameObject SelectMenu;

    public GameObject Ch1_1;
    public GameObject Ch1_2;
    public GameObject Ch2_1;
    public GameObject Ch2_2;
    public GameObject Ch2_3;
    public GameObject Ch2_4;
    public GameObject Terrain;
    public GameObject IceTerrain;

    public GameObject TemRain;
    public Text TargetText;
    public Text AnswerText;
    public Text TipText;
    public GameObject AnsButton1;
    public GameObject AnsButton2;
    public GameObject AnsButton3;
    public GameObject AnsButton4;
    public int ChNum = 0;
    public int QuestionCount = 0;

    public GameObject Note;
    bool ButtonAState = false;
    bool NoteOpen = false;

    bool LionHair = false;
    bool LionTeeth = false;
    bool ZebraLines = false;
    bool ZebraFoot = false;
    public GameObject Lion;
    public GameObject Zebra;
    public GameObject LionHairGameObject;
    public GameObject LionTeethGameObject;
    public GameObject ZebraLinesGameObject;
    public GameObject ZebraFootGameObject;
    public Animator LionAn;
    public Animator ZebraAn;

    public GameObject Bear;
    public GameObject Penguin;
    public GameObject PenguinFa;
    public GameObject Sealdog;
    public GameObject SealdogSkinGameObject;
    public GameObject BearHairGameObject;
    public GameObject PenguinFeatherGameObject;
    public Animator BearAn;
    public Animator SealdogAn;
    public Animation PenguinAn;

    public static int finalgame = 1;
    public bool Ch1_1Complete = false;
    public bool Ch1_2Complete = false;
    public GameObject EnterButton;

    public GameObject Thermometer;
    public Text ThermometerText;
    public Text RainText;

    public GameObject RightHandController;
    public GameObject LeftHandController;

    public bool Wait = false;

    public string[][] QuestionArr = {
    new string[] {"現在的環境感覺如何？" //0 草原
    , "觀察看看附近的植物有甚麼特徵？"
    , "你覺得斑馬有哪些特徵呢？"
    , "你覺得獅子有哪些特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //1 極地
    , "四周環境有什麼特別的地方嗎？"
    , "北極熊有甚麼特徵呢？"
    , "海豹有甚麼特徵呢？"
    , "企鵝有甚麼特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //2 高山
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "仔細看一下櫻花鉤吻鮭的外型有什麼特徵？"
    }, new string[] {"現在的環境感覺如何？" //3 淺山
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "你覺得石虎有哪些特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //4 濕地
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "你覺得黑面琵鷺有哪些特徵呢？"
    , "你覺得招潮蟹有哪些特徵呢？"
    , "你覺得彈塗魚有哪些特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //5 珊瑚礁
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "你覺得熱帶魚有哪些特徵呢？"
    }};

    public string[][] AnswerArr = {new string[] 
    {"乾燥", "樹很少", "", ""}
    , new string[] {"寒冷","冰雪覆蓋","","",""}
    , new string[] {"","",""}};

    public string[][][] OptionArr = {new string[][] {new string[] {"乾燥", "潮濕", "熱"}
    , new string[] {"樹很多", "樹很少", "地形崎嶇"}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"炎熱", "舒爽", "寒冷"}
    , new string[] {"冰雪覆蓋", "綠意盎然", "沙漠地形"}
    , new string[] {""}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"","",""}}};

    void Start()
    {
        web = GetComponent<WebPhp>();
        PenguinAn = Penguin.GetComponent<Animation>();
        /*PenguinFa.transform.position = new Vector3(242, -0.5f, 100);
        PenguinFa.transform.LookAt(new Vector3(239.53f, -0.5f, 98.3f));*/
    }

    void Update()
    {
        if (ZebraFoot == true && ZebraLines == true)
        {
            ZebraFoot = false;
            ZebraLines = false;
            ZebraFootGameObject.SetActive(false);
            ZebraLinesGameObject.SetActive(false);
            LionHairGameObject.SetActive(true);
            LionTeethGameObject.SetActive(true);
            QuestionCount++;
            TargetText.text = QuestionArr[ChNum][QuestionCount];
        }
        if (LionHair == true && LionTeeth == true)
        {
            LionHair = false;
            LionTeeth = false;
            LionHairGameObject.SetActive(false);
            LionTeethGameObject.SetActive(false);
            Ch1_1Complete = true;
            if (Ch1_2Complete != true)
            {
                Invoke("SelectIce", 2);
            }
        }
        if (Ch1_1Complete == true && Ch1_2Complete == true)
        {
            Ch1_1Complete = false;
            Ch1_2Complete = false;
            Invoke("ShowEnterButton", 2);
        }
        if (GameController.Score1 == 2)
        {
            GameController.Score1 = 100;
            Invoke("ShowEnterButton", 2);
        }
        if (GameController.Score2 == 3)
        {
            AnswerText.text = "恭喜完成第一章節！";
        }
        
        if (GlobalSet.RightHand.ButtonA != ButtonAState && GlobalSet.RightHand.ButtonA == true)
        {
            if (NoteOpen == false)
            {
                Note.SetActive(true);
                NoteOpen = true;
            }
            else
            {
                Note.SetActive(false);
                NoteOpen = false;
            }
        }
        ButtonAState = GlobalSet.RightHand.ButtonA;
    }

    public void ShowEnterButton()
    {
        Debug.Log("123");
        EnterButton.SetActive(true);
        EnterButton.GetComponentInChildren<Text>().text = "確認";
    }

    public void ShowFirstQuestion()
    {
        
        TemRain.SetActive(true);
        QuestionCount = 0;
        AnsButton1.SetActive(true);
        AnsButton2.SetActive(true);
        AnsButton3.SetActive(true);
        if (ChNum == 0)
        {
            StartCoroutine(web.php("ch1test", "1", "3", WebPhp.php_method.Action));
            ThermometerText.text = "24℃";
            RainText.text = "300mm";
        }
        else if (ChNum == 1)
        {
            StartCoroutine(web.php("ch1test", "1", "9", WebPhp.php_method.Action));
            ThermometerText.text = "-20℃";
            RainText.text = "150mm";
        }
        TargetText.text = QuestionArr[ChNum][QuestionCount];
        TipText.text = "觀察看看畫面上的溫度計及降雨量！";
        AnsButton1.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][0];
        AnsButton2.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][1];
        AnsButton3.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][2];
        if (OptionArr[ChNum][QuestionCount].Length == 4)
        {
            AnsButton4.SetActive(true);
            AnsButton4.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][3];
        }
        else
        {
            AnsButton4.SetActive(false);
        }
    }

    public void ShowNextQuestion()
    {
        TemRain.SetActive(false);
        AnsButton1.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][0];
        AnsButton2.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][1];
        AnsButton3.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][2];
        if (OptionArr[ChNum][QuestionCount].Length == 4)
        {
            AnsButton4.SetActive(true);
            AnsButton4.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][3];
        }
        else
        {
            AnsButton4.SetActive(false);
        }
        TargetText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void CheckAnswer()
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == AnswerArr[ChNum][QuestionCount])
        {
            AnswerText.text = "";
            if (QuestionCount + 1 < QuestionArr[ChNum].Length)
            {
                QuestionCount++;
                if (QuestionArr[ChNum][QuestionCount] == "你覺得斑馬有哪些特徵呢？")
                {
                    StartCoroutine(web.php("ch1test", "1", "4", WebPhp.php_method.Action));
                    CheckAnimal();
                    ZebraFootGameObject.SetActive(true);
                    ZebraLinesGameObject.SetActive(true);
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "北極熊有甚麼特徵呢？")
                {
                    StartCoroutine(web.php("ch1test", "1", "10", WebPhp.php_method.Action));
                    CheckAnimal();
                    BearHairGameObject.SetActive(true);
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else
                {
                    ShowNextQuestion();
                }
            }
            else
            {
                TargetText.text = "";
                ChNum = 1;
                QuestionCount = 0;
                AnsButton1.SetActive(false);
                AnsButton2.SetActive(false);
                AnsButton3.SetActive(false);
                AnsButton4.SetActive(false);
                Ch1_1Complete = true;
                if (Ch1_2Complete == false)
                {
                    SelectIce();
                }
            }
        }
        else
        {
            AnswerText.text = "回答錯誤";
            Invoke("EraseFeatureError", 2f);
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
    }

    public void CheckAnimal()
    {
        if (ChNum == 0)
        {
            LionAn.Play("run");
            ZebraAn.Play("run");
            Lion.GetComponent<PathFollower>().enabled = true;
            Zebra.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是斑馬和獅子出現了！";
        }
        else if (ChNum == 1)
        {
            BearAn.Play("run");
            SealdogAn.Play("run");
            Bear.GetComponent<PathFollower>().enabled = true;
            Sealdog.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是海豹和北極熊出現了！";
        }
        TipText.text = "拿出你的放大鏡觀察看看。";
        Invoke("AnStop", 6.5f);
    }

    public void AnStop()
    {
        if (ChNum == 0)
        {
            LionAn.Play("idle");
            ZebraAn.Play("idle");
            Lion.GetComponent<PathFollower>().enabled = false;
            Zebra.GetComponent<PathFollower>().enabled = false;
            Zebra.transform.LookAt(new Vector3(239.5f, 0.26f, 102f));
            Lion.transform.LookAt(new Vector3(239.6f, 0.26f, 94f));
        }
        else if (ChNum == 1)
        {
            BearAn.Play("idle");
            SealdogAn.Play("idle");
            PenguinAn.Play("idle");
            Bear.GetComponent<PathFollower>().enabled = false;
            Sealdog.GetComponent<PathFollower>().enabled = false;
            PenguinFa.GetComponent<PathFollower>().enabled = false;
            Sealdog.transform.LookAt(new Vector3(239.5f, 0.26f, 102f));
            Bear.transform.LookAt(new Vector3(239.6f, 0.26f, 94f));
            PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        TargetText.text = QuestionArr[ChNum][QuestionCount];
        TipText.text = "先按下右手的抓握再按下板機。";
    }

    public void EraseFeatureError()
    {
        AnswerText.text = "";
    }

    public void CheckAnimalFeature(string Feature)
    {
        if (Feature == "LionHair")
        {
            StartCoroutine(web.php("ch1test", "1", "7", WebPhp.php_method.Action));
            LionHair = true;
        }
        if (Feature == "LionTeeth")
        {
            StartCoroutine(web.php("ch1test", "1", "8", WebPhp.php_method.Action));
            LionTeeth = true;
        }
        if (Feature == "ZebraLines")
        {
            StartCoroutine(web.php("ch1test", "1", "5", WebPhp.php_method.Action));
            ZebraLines = true;
        }
        if (Feature == "ZebraFoot")
        {
            StartCoroutine(web.php("ch1test", "1", "6", WebPhp.php_method.Action));
            ZebraFoot = true;
        }
        if (Feature == "BearHair")
        {
            StartCoroutine(web.php("ch1test", "1", "11", WebPhp.php_method.Action));
            BearHairGameObject.SetActive(false);
            SealdogSkinGameObject.SetActive(true);
            QuestionCount++;
            TargetText.text = QuestionArr[ChNum][QuestionCount];
            TipText.text = "先按下右手的抓握再按下板機。";
        }
        if (Feature == "SealdogSkin")
        {
            StartCoroutine(web.php("ch1test", "1", "12", WebPhp.php_method.Action));
            SealdogSkinGameObject.SetActive(false);
            Bear.SetActive(false);
            Sealdog.SetActive(false);
            PenguinGo();
        }
        if (Feature == "PenguinFeather")
        {
            StartCoroutine(web.php("ch1test", "1", "13", WebPhp.php_method.Action));
            PenguinFeatherGameObject.SetActive(false);
            Ch1_2Complete = true;
            if (Ch1_1Complete == false)
            {
                Invoke("SelectGrassland", 2);
            }
        }
    }

    public void PenguinGo()
    {
        
        PenguinAn.Play("run");
        PenguinFa.GetComponent<PathFollower>().enabled = true;
        QuestionCount++;
        TargetText.text = "是企鵝出現了！";
        TipText.text = "拿出你的放大鏡觀察看看。";
        Invoke("AnStop", 6.5f);
    }

    public void SelectGrassland()
    {
        StartCoroutine(web.php("ch1test", "1", "1", WebPhp.php_method.Action));
        ChNum = 0;
        Ch1_1.SetActive(true);
        Ch1_2.SetActive(false);
        SelectMenu.SetActive(false);
        ShowFirstQuestion();
    }

    public void SelectIce()
    {
        StartCoroutine(web.php("ch1test", "1", "2", WebPhp.php_method.Action));
        ChNum = 1;
        Ch1_1.SetActive(false);
        Ch1_2.SetActive(true);
        SelectMenu.SetActive(false);
        ShowFirstQuestion();
    }

    public void Game()
    {
        EnterButton.SetActive(false);
        TargetText.text = "請選出適合在此環境中生存的動物";
        TipText.text = "用右手將動物抓起吧！";
        if (GameController.Score1 == 0)
        {
            Ch1_1.SetActive(true);
            Ch1_2.SetActive(true);
            Terrain.SetActive(true);
            IceTerrain.SetActive(false);
        }
        else if (GameController.Score1 == 100)
        {
            GameController.Score1 = 0;
            finalgame = 2;
            Ch1_1.SetActive(true);
            Ch1_2.SetActive(true);
            Terrain.SetActive(false);
            IceTerrain.SetActive(true);
            Lion.SetActive(false);
            Zebra.SetActive(false);
            Bear.SetActive(false);
            Penguin.SetActive(false);
            Sealdog.SetActive(false);
        }
        Lion.SetActive(true);
        Zebra.SetActive(true);
        Bear.SetActive(true);
        Penguin.SetActive(true);
        Sealdog.SetActive(true);
        Lion.GetComponent<PathFollower>().enabled = false;
        Zebra.GetComponent<PathFollower>().enabled = false;
        Bear.GetComponent<PathFollower>().enabled = false;
        Sealdog.GetComponent<PathFollower>().enabled = false;
        PenguinFa.GetComponent<PathFollower>().enabled = false;
        Zebra.transform.position = new Vector3(242, -0.2f, 102);
        Lion.transform.position = new Vector3(240, -0.2f, 102);
        Sealdog.transform.position = new Vector3(241, 2f, 95);
        Bear.transform.position = new Vector3(245, -0.2f, 95);
        PenguinFa.transform.position = new Vector3(242, -0.2f, 100);
        Penguin.transform.localPosition = new Vector3(0, 0, 0);
        Lion.GetComponent<XRGrabInteractable>().enabled = true;
        Zebra.GetComponent<XRGrabInteractable>().enabled = true;
        Bear.GetComponent<XRGrabInteractable>().enabled = true;
        Sealdog.GetComponent<XRGrabInteractable>().enabled = true;
        Penguin.GetComponent<XRGrabInteractable>().enabled = true;
        Lion.GetComponent<BoxCollider>().enabled = true;
        Zebra.GetComponent<BoxCollider>().enabled = true;
        Bear.GetComponent<BoxCollider>().enabled = true;
        Sealdog.GetComponent<BoxCollider>().enabled = true;
        Penguin.GetComponent<BoxCollider>().enabled = true;
        LionAn.Play("idle", 0, 0f);
        ZebraAn.Play("idle", 0, 0f);
        BearAn.Play("idle", 0, 0f);
        SealdogAn.Play("idle", 0, 0f);
        PenguinAn.Play("idle");
        LookAtCamera();
        
    }
    
    public void LookAtCamera()
    {
        Zebra.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        Lion.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        Sealdog.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        Bear.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        PenguinFa.transform.LookAt(new Vector3(239.53f, -0.5f, 98.3f));
    }
}
