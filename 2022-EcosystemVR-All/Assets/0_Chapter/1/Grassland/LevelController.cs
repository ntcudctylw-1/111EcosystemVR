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
    public GameObject SelectMenu1;
    public GameObject SelectMenu2;

    public GameObject Ch1_1;
    public GameObject Ch1_2;
    public GameObject Ch2_1;
    public GameObject Ch2_2;
    public GameObject Ch2_3;
    public GameObject Ch2_4;
    public GameObject Terrain;
    public GameObject IceTerrain;
    public GameObject Terrain2_1;
    public GameObject Terrain2_2;
    public GameObject Terrain2_3;
    public GameObject Terrain2_4;

    public Button SM2Button1;
    public Button SM2Button2;
    public Button SM2Button3;
    public Button SM2Button4;

    public GameObject TemRain;
    public Text TargetText;
    public Text AnswerText;
    public Text TipText;
    public Text InfoText;
    public GameObject AnsButton1;
    public GameObject AnsButton2;
    public GameObject AnsButton3;
    public GameObject AnsButton4;
    public static int ChNum = 2;
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

    public GameObject Oncorhynchus;
    public GameObject OncorhynchusLinesGameObject;
    public Animator OncorhynchusAn;
    public GameObject Oncorhynchus1;
    public Animator OncorhynchusAn1;

    bool CatFace = false;
    bool CatLines = false;
    public GameObject Cat;
    public GameObject CatFaceGameObject;
    public GameObject CatLinesGameObject;
    public Animator CatAn;
    public GameObject Cat1;
    public Animator CatAn1;

    bool BirdMouth = false;
    bool BirdFeather = false;
    public GameObject Bird;
    public GameObject BirdMouthGameObject;
    public GameObject BirdFeatherGameObject;
    public Animator BirdAn;
    public GameObject Crab;
    public GameObject CrabTombGameObject;
    public Animator CrabAn;
    public GameObject Mudskipper;
    public GameObject MudskipperSkinGameObject;
    public Animator MudskipperAn;

    public GameObject Fish;
    public GameObject FishColorGameObject;
    public Animator FishAn;
    public GameObject Siganus;
    public GameObject Moorish;
    public GameObject Angelfish;
    public GameObject Fish1;
    public Animator FishAn1;

    public static int finalgame = 1;
    public bool Ch1_1Complete = false;
    public bool Ch1_2Complete = false;
    public bool Ch2_1Complete = false;
    public bool Ch2_2Complete = false;
    public bool Ch2_3Complete = false;
    public bool Ch2_4Complete = false;
    public int Ch2Complete = 0;
    public GameObject EnterButton;
    public GameObject EnterButtonCh2;
    public int[] Ch2GameScoreTarget = {1, 1, 3, 1};
    public static int Ch2GameLevel = 0;

    public Text ThermometerText;
    public Text RainText;

    public GameObject RightHandController;
    public GameObject LeftHandController;

    public bool Wait = false;

    public string[][] TemAndRainArr = {new string [] {"24℃", "300mm"}
    , new string[] {"-20℃", "150mm"}
    , new string[] {"℃", "mm"}
    , new string[] {"℃", "mm"}
    , new string[] {"℃", "mm"}
    , new string[] {"℃", "mm"}};

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
    , new string[] {"1", "1", ""}
    , new string[] {"1", "1", ""}
    , new string[] {"1", "1", "", "", ""}
    , new string[] {"1", "1", ""}};

    public string[][][] OptionArr = {new string[][] {new string[] {"乾燥", "潮濕", "熱"}//0
    , new string[] {"樹很多", "樹很少", "地形崎嶇"}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"炎熱", "舒爽", "寒冷"}//1
    , new string[] {"冰雪覆蓋", "綠意盎然", "沙漠地形"}
    , new string[] {""}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"1","2","3"}//2
    , new string[] {"1", "2", "3"}
    }, new string[][] {new string[] {"1", "2", "3"}//3
    , new string[] {"1", "2", "3"}
    }, new string[][] {new string[] {"1", "2", "3"}//4
    , new string[] {"1", "2", "3"}
    }, new string[][] {new string[] {"1", "2", "3"}//5
    , new string[] {"1", "2", "3"}
    }};

    void Start()
    {
        ChNum = 2;
        /*Ch2Complete = 4;
        Ch2Level();
        Ch2Game();*/
        
        if (ChNum == 0 || ChNum == 1)
        {
            SelectMenu1.SetActive(true);
        }
        else if (ChNum == 2)
        {
            SelectMenu2.SetActive(true);
        }
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
                TargetText.text = "觀察完草原的生態了";
                TipText.text = "接下來觀察極地的生態吧！";
                Invoke("SelectIce", 2);
            }
        }
        if (CatFace == true && CatLines == true)
        {
            CatFace = false;
            CatLines = false;
            Ch2_2Complete = true;
            SM2Button2.interactable = false;
            Ch2Complete++;
            Ch2Level();
        }
        if (BirdFeather == true && BirdMouth == true)
        {
            BirdFeather = false;
            BirdMouth = false;
            Bird.SetActive(false);
            CrabAndMudGo();
        }
        if (Ch1_1Complete == true && Ch1_2Complete == true)
        {
            Ch1_1Complete = false;
            Ch1_2Complete = false;
            TargetText.text = "接下來我們來玩個小遊戲吧！";
            TipText.text = "";
            Invoke("ShowEnterButton", 2);
        }
        if (GameController.Score1 == 2)
        {
            TargetText.text = "按下確認進入下一階段";
            TipText.text = "";
            GameController.Score1 = 100;
            Invoke("ShowEnterButton", 2);
        }
        if (GameController.Score2 == 3)
        {
            TargetText.text = "";
            TipText.text = "";
            Invoke("ShowCongraText", 2);
        }
        if (GameController.Ch2GameScore == Ch2GameScoreTarget[Ch2GameLevel])
        {
            if (Ch2GameLevel < 3)
            {
                Ch2GameLevel++;
                Invoke("ShowEnterButtonCh2", 2);
            }
            else
            {
                Invoke("ShowCongraText", 2);
            }
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

    public void ShowCongraText()
    {
        if (ChNum == 0 || ChNum == 1)
        {
            AnswerText.text = "恭喜完成第一章節！";
        }
        else
        {
            AnswerText.text = "恭喜完成第二章節！";
        }
    }

    public void ShowEnterButton()
    {
        InfoText.text = "";
        EnterButton.SetActive(true);
        EnterButton.GetComponentInChildren<Text>().text = "確認";
    }

    public void ShowEnterButtonCh2()
    {
        InfoText.text = "";
        EnterButtonCh2.SetActive(true);
    }

    public void ShowFirstQuestion()
    {
        TemRain.SetActive(true);
        QuestionCount = 0;
        AnsButton1.SetActive(true);
        AnsButton2.SetActive(true);
        AnsButton3.SetActive(true);
        ThermometerText.text = TemAndRainArr[ChNum][0];
        RainText.text = TemAndRainArr[ChNum][1];
        if (ChNum == 0)
        {
            StartCoroutine(web.php(GlobalSet.SID, "1", "3", WebPhp.php_method.Action));
        }
        else if (ChNum == 1)
        {
            StartCoroutine(web.php(GlobalSet.SID, "1", "9", WebPhp.php_method.Action));
        }
        else if (ChNum == 2)
        {
            StartCoroutine(web.php(GlobalSet.SID, "2", "19", WebPhp.php_method.Action));
        }
        else if (ChNum == 3)
        {
            StartCoroutine(web.php(GlobalSet.SID, "2", "22", WebPhp.php_method.Action));
        }
        else if (ChNum == 4)
        {
            StartCoroutine(web.php(GlobalSet.SID, "2", "27", WebPhp.php_method.Action));
        }
        else if (ChNum == 5)
        {
            StartCoroutine(web.php(GlobalSet.SID, "2", "32", WebPhp.php_method.Action));
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
        TipText.text = "";
        if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == AnswerArr[ChNum][QuestionCount])
        {
            AnswerText.text = "";
            if (QuestionCount + 1 < QuestionArr[ChNum].Length)
            {
                QuestionCount++;
                if (QuestionArr[ChNum][QuestionCount] == "你覺得斑馬有哪些特徵呢？")
                {
                    StartCoroutine(web.php(GlobalSet.SID, "1", "4", WebPhp.php_method.Action));
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
                    StartCoroutine(web.php(GlobalSet.SID, "1", "10", WebPhp.php_method.Action));
                    CheckAnimal();
                    BearHairGameObject.SetActive(true);
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "仔細看一下櫻花鉤吻鮭的外型有什麼特徵？")
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "20", WebPhp.php_method.Action));
                    CheckAnimal();
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "你覺得石虎有哪些特徵呢？")
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "23", WebPhp.php_method.Action));
                    CheckAnimal();
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "你覺得黑面琵鷺有哪些特徵呢？")
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "27", WebPhp.php_method.Action));
                    CheckAnimal();
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "你覺得熱帶魚有哪些特徵呢？")
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "33", WebPhp.php_method.Action));
                    CheckAnimal();
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
        else if (ChNum == 2)
        {
            Oncorhynchus1.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是櫻花鉤吻鮭出現了！";
        }
        else if (ChNum == 3)
        {
            CatAn1.Play("run");
            Cat1.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是石虎出現了！";
        }
        else if (ChNum == 4)
        {
            BirdAn.Play("fly");
            Bird.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是黑面琵鷺出現了！";
        }
        else if (ChNum == 5)
        {
            Fish1.GetComponent<PathFollower>().enabled = true;
            Siganus.GetComponent<PathFollower>().enabled = true;
            Moorish.GetComponent<PathFollower>().enabled = true;
            Angelfish.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是熱帶魚出現了！";
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
        else if (ChNum == 2)
        {
            //Oncorhynchus.GetComponent<PathFollower>().enabled = false;
            //Oncorhynchus.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        else if (ChNum == 3)
        {
            CatAn1.Play("idle");
            //Cat.GetComponent<PathFollower>().enabled = false;
            //Cat.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        else if (ChNum == 4)
        {
            BirdAn.Play("idle");
            //Bird.GetComponent<PathFollower>().enabled = false;
            Bird.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            CrabAn.Play("idle");
            //Crab.GetComponent<PathFollower>().enabled = false;
            Crab.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            MudskipperAn.Play("idle");
            //Mudskipper.GetComponent<PathFollower>().enabled = false;
            Mudskipper.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
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
        if (ChNum == 0 || ChNum == 1)
        {
            if (Feature == "LionHair")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "7", WebPhp.php_method.Action));
                InfoText.text = "通常只有雄性的獅子脖子上會有鬃毛，是為了可以在打鬥中保護自己的頭部和脖子。";
                LionHair = true;
            }
            if (Feature == "LionTeeth")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "8", WebPhp.php_method.Action));
                InfoText.text = "雄性獅子會有銳利的牙齒以及爪子，方便牠們狩獵使用。";
                LionTeeth = true;
            }
            if (Feature == "ZebraLines")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "5", WebPhp.php_method.Action));
                InfoText.text = "斑馬身上的黑白紋路可以混淆斑馬的天敵的視覺，讓他沒辦法鎖定獵物。同時黑白相間的紋路還可以調節身體的溫度呢！";
                ZebraLines = true;
            }
            if (Feature == "ZebraFoot")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "6", WebPhp.php_method.Action));
                InfoText.text = "斑馬的蹄可以讓牠在草原環境裡更快速的移動，避免被牠的天敵獵捕。";
                ZebraFoot = true;
            }
            if (Feature == "BearHair")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "11", WebPhp.php_method.Action));
                InfoText.text = "北極熊的毛可以防止水分滲入，達到禦寒的效果，同時皮膚底下有一層極厚的皮下脂肪加強保暖。";
                BearHairGameObject.SetActive(false);
                SealdogSkinGameObject.SetActive(true);
                QuestionCount++;
                TargetText.text = QuestionArr[ChNum][QuestionCount];
                TipText.text = "先按下右手的抓握再按下板機。";
            }
            if (Feature == "SealdogSkin")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "12", WebPhp.php_method.Action));
                InfoText.text = "海豹有一層用來保暖的厚厚的皮下脂肪，並提供食物儲備，並產生浮力，讓牠可以漂浮在水面上。";
                SealdogSkinGameObject.SetActive(false);
                Bear.SetActive(false);
                Sealdog.SetActive(false);
                Invoke("PenguinGo", 2);
            }
            if (Feature == "PenguinFeather")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "13", WebPhp.php_method.Action));
                InfoText.text = "企鵝身上的羽毛，具備防水、防風的功能。而且牠也有厚達2到3公分的皮下脂肪，可以讓企鵝保持體溫。";
                PenguinFeatherGameObject.SetActive(false);
                Ch1_2Complete = true;
                if (Ch1_1Complete == false)
                {
                    TargetText.text = "觀察完極地的生態了";
                    TipText.text = "接下來觀察草原的生態吧！";
                    Invoke("SelectGrassland", 2);
                }
            }
        }
        else if (ChNum == 2)
        {
            if (Feature == "OncorhynchusLines")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "21", WebPhp.php_method.Action));
                InfoText.text = "身體側扁呈紡錘狀，背部青綠色，腹部為銀白色，體側中央有橢圓形雲紋斑點。";
                OncorhynchusLinesGameObject.SetActive(false);
                SM2Button1.interactable = false;
                Ch2_1Complete = true;
                Ch2Complete++;
                Ch2Level();
            }
        }
        else if (ChNum == 3)
        {
            if (Feature == "CatFace")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "24", WebPhp.php_method.Action));
                InfoText.text = "額頭有2條灰白色縱帶，最大特徵是耳後有一塊淡黃色的圓斑。";
                CatFaceGameObject.SetActive(false);
                CatFace = true;
            }
            else if (Feature == "CatLines")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "25", WebPhp.php_method.Action));
                InfoText.text = "石虎的身體、四肢、尾巴都有斑點的花紋。";
                CatLinesGameObject.SetActive(false);
                CatLines = true;
            }
        }
        else if (ChNum == 4)
        {
            if (Feature == "BirdMouth")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "28", WebPhp.php_method.Action));
                InfoText.text = "黑面琵鷺有著長長的黑色扁平嘴巴，覓食的時候會以扁平的嘴喙在淺水中左右撈動，來尋找食物。";
                BirdMouthGameObject.SetActive(false);
                BirdMouth = true;
            }
            else if (Feature == "BirdFeather")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "29", WebPhp.php_method.Action));
                InfoText.text = "繁殖期時，黑面琵鷺的冠羽和胸前的羽毛會有明顯的黃色。";
                BirdFeatherGameObject.SetActive(false);
                BirdFeather = true;
            }
            else if (Feature == "CrabTomb")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "30", WebPhp.php_method.Action));
                InfoText.text = "雄性招潮蟹的大螯除了用來防禦、威嚇之外，繁殖季時還會在沙灘上不斷地揮舞大螯，直到漲潮之際，才會停止。";
                CrabTombGameObject.SetActive(false);
                MudskipperSkinGameObject.SetActive(true);
                QuestionCount++;
                TargetText.text = QuestionArr[ChNum][QuestionCount];
            }
            else if (Feature == "MudskipperSkin")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "31", WebPhp.php_method.Action));
                InfoText.text = "彈塗魚潮溼的皮膚可以幫助呼吸，胸鰭能推動身體前進。";
                MudskipperSkinGameObject.SetActive(false);
                Ch2_3Complete = true;
                SM2Button3.interactable = false;
                Ch2Complete++;
                Ch2Level();
            }
        }
        else if (ChNum == 5)
        {
            if (Feature == "FishColor")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "34", WebPhp.php_method.Action));
                InfoText.text = "大多數的熱帶魚都有著光彩奪目的顏色，是為了配合珊瑚礁的色彩，並逃避天敵的捕食。";
                FishColorGameObject.SetActive(false);
                Ch2_4Complete = true;
                SM2Button4.interactable = false;
                Ch2Complete++;
                Ch2Level();
            }
        }
    }

    public void PenguinGo()
    {
        PenguinAn.Play("walk");
        PenguinFa.GetComponent<PathFollower>().enabled = true;
        QuestionCount++;
        TargetText.text = "是企鵝出現了！";
        TipText.text = "拿出你的放大鏡觀察看看。";
        InfoText.text = "";
        Invoke("AnStop", 6.5f);
    }

    public void CrabAndMudGo()
    {
        //CrabAn.Play("");
        Crab.GetComponent<PathFollower>().enabled = true;
        MudskipperAn.Play("jump");
        Mudskipper.GetComponent<PathFollower>().enabled = true;
        QuestionCount++;
        TargetText.text = "是招潮蟹和彈塗魚出現了！";
        TipText.text = "拿出你的放大鏡觀察看看。";
        InfoText.text = "";
        Invoke("AnStop", 6.5f);
    }

    public void SelectGrassland()
    {
        StartCoroutine(web.php(GlobalSet.SID, "1", "1", WebPhp.php_method.Action));
        ChNum = 0;
        InfoText.text = "";
        Ch1_1.SetActive(true);
        Ch1_2.SetActive(false);
        SelectMenu1.SetActive(false);
        ShowFirstQuestion();
    }

    public void SelectIce()
    {
        StartCoroutine(web.php(GlobalSet.SID, "1", "2", WebPhp.php_method.Action));
        ChNum = 1;
        InfoText.text = "";
        Ch1_1.SetActive(false);
        Ch1_2.SetActive(true);
        SelectMenu1.SetActive(false);
        ShowFirstQuestion();
    }

    public void SelectHigh()
    {
        StartCoroutine(web.php(GlobalSet.SID, "2", "15", WebPhp.php_method.Action));
        ChNum = 2;
        InfoText.text = "";
        Ch2_1.SetActive(true);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        ShowFirstQuestion();
    }

    public void SelectLow()
    {
        StartCoroutine(web.php(GlobalSet.SID, "2", "16", WebPhp.php_method.Action));
        ChNum = 3;
        InfoText.text = "";
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(true);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        ShowFirstQuestion();
    }

    public void SelectWet()
    {
        StartCoroutine(web.php(GlobalSet.SID, "2", "17", WebPhp.php_method.Action));
        ChNum = 4;
        InfoText.text = "";
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(true);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        ShowFirstQuestion();
    }

    public void SelectCoral()
    {
        StartCoroutine(web.php(GlobalSet.SID, "2", "18", WebPhp.php_method.Action));
        ChNum = 5;
        InfoText.text = "";
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(true);
        SelectMenu2.SetActive(false);
        ShowFirstQuestion();
    }

    public void Game()
    {
        StartCoroutine(web.php(GlobalSet.SID, "1", "14", WebPhp.php_method.Action));
        GameController.Reset();
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
        LionAn.Play("idle", 0, 0f);
        ZebraAn.Play("idle", 0, 0f);
        BearAn.Play("idle", 0, 0f);
        SealdogAn.Play("idle", 0, 0f);
        PenguinAn.Play("idle");
        Penguin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        PenguinFa.transform.localEulerAngles = new Vector3(0, -124, 0);
        //PenguinFa.transform.LookAt(new Vector3(239.53f, 2, 98.3f));
        //Penguin.transform.Rotate(0, 0 , 90);
        
        Zebra.transform.position = new Vector3(242, -0.2f, 102);
        Lion.transform.position = new Vector3(240, -0.2f, 102);
        Sealdog.transform.position = new Vector3(241, 2f, 95);
        Bear.transform.position = new Vector3(245, -0.2f, 95);
        PenguinFa.transform.position = new Vector3(242, 0, 100);
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
        
        LookAtCamera();
    }
    
    public void LookAtCamera()
    {
        if (ChNum == 0 || ChNum == 1)
        {
            Zebra.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Lion.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Sealdog.transform.LookAt(new Vector3(239.53f, 2, 98.3f));
            Bear.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        else
        {
            Oncorhynchus.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Cat.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Bird.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Crab.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Mudskipper.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Fish.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        //PenguinFa.transform.LookAt(new Vector3(239.53f, 2, 98.3f));//-0.5
        //Penguin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void Ch2Level()
    {
        if (Ch2Complete != 4)
        {
            SelectMenu2.SetActive(true);
        }
        else
        {
            //StartCoroutine(web.php(GlobalSet.SID, "2", "35", WebPhp.php_method.Action));
            TargetText.text = "請選出適合在此環境中生存的動物";
            TipText.text = "用右手將動物抓起吧！";
            ShowEnterButtonCh2();
        }
    }

    public void Ch2GameStart()
    {
        Oncorhynchus1.SetActive(false);
        Cat1.SetActive(false);
        Fish1.SetActive(false);
        Ch2GameReset();
        Ch2Game();
    }

    public void Ch2GameReset()
    {
        GameController.Reset();
        EnterButtonCh2.SetActive(false);
        Ch2_1.SetActive(true);
        Ch2_2.SetActive(true);
        Ch2_3.SetActive(true);
        Ch2_4.SetActive(true);
        Terrain2_1.SetActive(false);
        Terrain2_2.SetActive(false);
        Terrain2_3.SetActive(false);
        Terrain2_4.SetActive(false);
        Oncorhynchus.SetActive(true);
        Cat.SetActive(true);
        Bird.SetActive(true);
        Crab.SetActive(true);
        Mudskipper.SetActive(true);
        Fish.SetActive(true);
        Siganus.SetActive(false);
        Moorish.SetActive(false);
        Angelfish.SetActive(false);
        OncorhynchusAn.Play("idle");
        CatAn.Play("idle");
        BirdAn.Play("idle");
        CrabAn.Play("idle");
        MudskipperAn.Play("idle");
        Bird.GetComponent<PathFollower>().enabled = false;
        Crab.GetComponent<PathFollower>().enabled = false;
        Mudskipper.GetComponent<PathFollower>().enabled = false;
        Oncorhynchus.GetComponent<XRGrabInteractable>().enabled = true;
        Cat.GetComponent<XRGrabInteractable>().enabled = true;
        Bird.GetComponent<XRGrabInteractable>().enabled = true;
        Crab.GetComponent<XRGrabInteractable>().enabled = true;
        Mudskipper.GetComponent<XRGrabInteractable>().enabled = true;
        Fish.GetComponent<XRGrabInteractable>().enabled = true;
        LookAtCamera();
    }

    public void Ch2Game()
    {
        if (Ch2GameLevel == 0)
        {
            Terrain2_1.SetActive(true);
            Oncorhynchus.transform.position = new Vector3(237.035995f,0.240999997f,97.9179993f);
            Cat.transform.position = new Vector3(237.119995f,-0.0410000086f,96.3170013f);
            Bird.transform.position = new Vector3(238.035995f,-0.0109999999f,95.5250015f);
            Crab.transform.position = new Vector3(242.339996f,0.47299999f,94.8170013f);
            Mudskipper.transform.position = new Vector3(243.117996f,1.549000025f,95.8199997f);
            Fish.transform.position = new Vector3(242.589996f,0.419999987f,97.711998f);
        }
        else if (Ch2GameLevel == 1)
        {
            Terrain2_2.SetActive(true);
            Oncorhynchus.transform.position = new Vector3(237.035995f,0.66f,97.9179993f);
            Cat.transform.position = new Vector3(237.119995f,0.277f,96.3170013f);
            Bird.transform.position = new Vector3(238.035995f,0.294f,95.5250015f);
            Crab.transform.position = new Vector3(242.339996f,0.47299999f,94.8170013f);
            Mudskipper.transform.position = new Vector3(243.117996f,1.549000025f,95.8199997f);
            Fish.transform.position = new Vector3(242.589996f,0.419999987f,97.711998f);
        }
        else if (Ch2GameLevel == 2)
        {
            Terrain2_3.SetActive(true);
            Oncorhynchus.transform.position = new Vector3(237.035995f,0.66f,97.9179993f);
            Cat.transform.position = new Vector3(237.119995f,0.277f,96.3170013f);
            Bird.transform.position = new Vector3(238.035995f,0.294f,95.5250015f);
            Crab.transform.position = new Vector3(242.339996f,0.47299999f,94.8170013f);
            Mudskipper.transform.position = new Vector3(243.117996f,1.549000025f,95.8199997f);
            Fish.transform.position = new Vector3(242.589996f,0.419999987f,97.711998f);
        }
        else if (Ch2GameLevel == 3)
        {
            Terrain2_4.SetActive(true);
            Oncorhynchus.transform.position = new Vector3(238.940002f,0.660000026f,95.3399963f);
            Cat.transform.position = new Vector3(240.955002f,0.27700001f,95.3690033f);
            Bird.transform.position = new Vector3(242.561005f,0.294f,95.7440033f);
            Crab.transform.position = new Vector3(240.841003f,0.549000025f,100.639f);
            Mudskipper.transform.position = new Vector3(242.248993f,1.47299999f,100.686996f);
            Fish.transform.position = new Vector3(239.302002f,0.51700002f,100.497002f);
        }
        LookAtCamera();
    }
}
