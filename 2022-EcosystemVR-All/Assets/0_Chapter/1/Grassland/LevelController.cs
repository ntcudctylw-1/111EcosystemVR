using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation.Examples;
using Random=UnityEngine.Random;
using Wave.OpenXR.Toolkit.Raycast;
<<<<<<< Updated upstream
=======
using UnityEngine.Video;
>>>>>>> Stashed changes

public class LevelController : MonoBehaviour
{
    WebPhp web;
    public GameObject SelectMenu1;
    public GameObject SelectMenu2;

<<<<<<< Updated upstream
=======
    public VideoPlayer LionVideo;
    public AudioSource ButtonSound;
    public GameObject AllAns;

    public GameObject WSCH1Button;
    public int WSBtnNum = 0;

    public GameObject CanvasCH1;
    public GameObject Canvas2;
>>>>>>> Stashed changes
    public GameObject Canvas1;
    public GameObject Plane;

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
    public Text InfoText;
    public GameObject AnsButton1;
    public GameObject AnsButton2;
    public GameObject AnsButton3;
    public GameObject AnsButton4;
    public static int ChNum = 2;
    public int QuestionCount = 0;
    public string QuaternionRecord = "";
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

    public int ZebraNum = 0;
    public int LionNum = 0;
    public int CatNum = 0;
    public int BirdNum = 0;

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

    public GameObject CH3;

    public string[][] TemAndRainArr = {new string [] {"24℃", "300mm"}
    , new string[] {"-20℃", "150mm"}
    , new string[] {"12℃", "2200mm"}
    , new string[] {"25℃", "2010mm"}
    , new string[] {"23℃", "1300mm"}
    , new string[] {"25℃", "2736mm"}};

    public string[][] QuestionArr = {
    new string[] {"我們現在來到了草原生態系。\n看一看旁邊顯示的溫度計，\n你覺得現在的環境感覺如何？" //0 草原
    , "四處看看草原生態系的景象，\n並觀察一下附近的植物有什麼特徵呢？"
    , "你覺得斑馬有哪些特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    , "很好，斑馬的特徵有牠身上黑白相間的條紋和牠的蹄。\n再來讓我們觀察旁邊的獅子，\n你覺得獅子有哪些特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了極地生態系。\n看一看旁邊顯示的溫度計，\n你覺得現在的環境感覺如何？" //1 極地
    , "四處看看極地生態系的景象，\n你覺得四周的環境有什麼特別的地方嗎？"
    , "觀察北極熊，你覺得北極熊\n有哪個部位可以幫助牠保暖呢？\n移動手把並點選該部位。"
    , "北極熊身上厚重的毛皮能幫助牠保暖，\n讓牠可以在這麼寒冷的環境底下生存。\n再觀察一旁的海豹，\n你覺得海豹有哪個部位可以幫助牠保暖呢？\n移動手把並點選該部位。"
    , "觀察企鵝，你覺得企鵝\n有哪個部位可以幫助牠保暖呢？\n移動手把並點選該部位。？"
    }, new string[] {"我們現在來到了高山溪流生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //2 高山
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n櫻花鉤吻鮭的外型有什麼特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了淺山生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //3 淺山
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n你覺得石虎的外型有什麼特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了溼地生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //4 濕地
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n你覺得黑面琵鷺的外型有什麼特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    , "仔細看一下，\n你覺得招潮蟹的外型有什麼特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    , "仔細看一下，\n你覺得彈塗魚的外型有什麼特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了珊瑚礁生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //5 珊瑚礁
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n熱帶魚的外型有什麼特徵呢？\n移動手把並點選，把這些特徵找出來吧。"
    }};

    public string[][] AnswerArr = {new string[] 
    {"乾燥", "植被稀疏", "", ""}
    , new string[] {"寒冷","冰雪覆蓋","","",""}
    , new string[] {"氣溫稍低", "地形陡峭", ""}
    , new string[] {"涼爽宜人", "樹林茂密", ""}
    , new string[] {"溫暖潮濕", "佈滿沼澤", "", "", ""}
    , new string[] {"溫暖", "海水清澈", ""}};

    public string[][][] OptionArr = {new string[][] {new string[] {"乾燥", "潮濕", "炎熱"}//0
    , new string[] {"樹林茂密", "植被稀疏", "地形崎嶇"}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"炎熱", "舒爽", "寒冷"}//1
    , new string[] {"冰雪覆蓋", "綠意盎然", "沙漠地形"}
    , new string[] {""}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"濕黏悶熱","氣溫稍低","溫暖潮濕"}//2
    , new string[] {"沙漠地形", "地勢平坦", "地形陡峭"}
    }, new string[][] {new string[] {"涼爽宜人", "炎熱乾燥", "寒冷乾燥"}//3
    , new string[] {"植被稀疏", "冰雪覆蓋", "樹林茂密"}
    }, new string[][] {new string[] {"溫暖潮濕", "寒冷乾燥", "炎熱潮濕"}//4
    , new string[] {"沙漠地形", "佈滿沼澤", "土壤乾燥"}
    }, new string[][] {new string[] {"炎熱", "寒冷", "溫暖"}//5
    , new string[] {"河流堆積", "海水清澈", "水流湍急"}
    }};

    void Start()
    {
        ChNum = 6;
<<<<<<< Updated upstream
        
        if (ChNum == 0 || ChNum == 1)
        {
            SelectMenu1.SetActive(true);
            Canvas1.SetActive(true);
            Plane.SetActive(true);
        }
        else if (ChNum > 1 && ChNum < 6)
        {
            SelectMenu2.SetActive(true);
            Canvas1.SetActive(true);
            Plane.SetActive(true);
        }
        else if (ChNum == 6)
        {
            Canvas1.SetActive(false);
            Plane.SetActive(false);
=======
        LionVideo.Play();
        if (ChNum == 0 || ChNum == 1)
        {
            InfoText.text = "歡迎來到第一單元，這個單元\n要帶大家來認識草原及極地生態系中的環境特性、\n這些生態系中特有動物的生物特徵、\n以及不同動物的特徵對應生活環境的習性。\n點擊進入不同的生態系看看吧。";
        }
        else if (ChNum > 1 && ChNum < 6)
        {
            InfoText.text = "歡迎來到第二單元，這個單元\n要帶大家來認識台灣的多樣化生態系和環境特性，\n以及這些生態系的特有動物和牠們的特徵哦。\n點擊進入不同的生態系看看吧。";
        }
        else if (ChNum == 6)
        {
            CanvasCH1.SetActive(false);
>>>>>>> Stashed changes
            RightHandController.GetComponent<RaycastPointer>().enabled = true;
            CH3.SetActive(true);
        }
        web = GetComponent<WebPhp>();
        PenguinAn = Penguin.GetComponent<Animation>();
    }

    void Update()
    {
        if (ZebraFoot == true && ZebraLines == true)
        {
            ZebraFoot = false;
            ZebraLines = false;
            Invoke("CheckLion", 2);
        }
        if (LionHair == true && LionTeeth == true)
        {
            LionHair = false;
            LionTeeth = false;
            Ch1_1Complete = true;
            if (Ch1_2Complete != true)
            {
                Invoke("CheckIce", 2);
                Invoke("SelectIce", 4);
            }
        }
        if (CatFace == true && CatLines == true)
        {
            CatFace = false;
            CatLines = false;
            Ch2_2Complete = true;
            SM2Button2.interactable = false;
            Ch2Complete++;
            if (Ch2Complete != 4)
            {
                Invoke("CH2Done", 2);
                Invoke("CheckOther", 4);                
            }
            else
            {
                Invoke("CH2End", 2);
            }
        }
        if (BirdFeather == true && BirdMouth == true)
        {
            BirdFeather = false;
            BirdMouth = false;
            Invoke("CrabAndMudGo", 2.5f);
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
            GameController.Score2 = 100;
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

    public void CheckLion()
    {
        LionHairGameObject.SetActive(true);
        LionTeethGameObject.SetActive(true);
        QuestionCount++;
        InfoText.text = QuestionArr[ChNum][QuestionCount];
        TargetText.text = "獅子特徵：" + LionNum + " / 2";
    }

    public void CheckMud()
    {
        MudskipperSkinGameObject.SetActive(true);
        QuestionCount++;
        InfoText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void CheckIce()
    {
        TargetText.text = "";
        InfoText.text = "觀察完草原的生態了，\n接下來觀察極地的生態吧！";
    }

    public void CheckGrassland()
    {
        TargetText.text = "";
        InfoText.text = "觀察完極地的生態了，\n接下來觀察草原的生態吧！";
    }

    public void CH2Done()
    {
        if (ChNum == 2)
        {
            InfoText.text = "觀察完高山溪流的生態了，\n接下來觀察其他的生態系吧！";            
        }
        else if (ChNum == 3)
        {
            TargetText.text = "";
<<<<<<< Updated upstream
            TipText.text = "";
            InfoText.text = "";
            AnswerText.text = "恭喜完成第二章節！";
=======
            InfoText.text = "觀察完淺山的生態了，\n接下來觀察其他的生態系吧！";            
        }
        else if (ChNum == 4)
        {
            InfoText.text = "觀察完濕地的生態了，\n接下來觀察其他的生態系吧！";            
        }  
        else if (ChNum == 5)
        {
            InfoText.text = "觀察完珊瑚礁的生態了，\n接下來觀察其他的生態系吧！";            
        }
    }

    public void CheckOther()
    {
        TargetText.text = "";
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(false);
        CanvasCH1.SetActive(false);
        SelectMenu2.SetActive(true);
    }

    public void CH2End()
    {
        WSCH1Button.SetActive(true);
        InfoText.text = "恭喜你完成本單元！\n在這個單元裡，有沒有更加認識\n台灣的各種特殊生態系以及特有動物呢？\n動物為了適應環境並生存，\n會對應不同的生態系演化出不同的特徵與能力。\n想一想，你還知道哪些動物\n為了生存在台灣的特殊生態系，\n而擁有獨特的外觀特徵呢？";
    }

    public void ShowCongraText()
    {
        if (ChNum == 0 || ChNum == 1)
        {
            CanvasCH1.SetActive(true);
            InfoText.text = "死亡數：" + GameController.DeadNum;
>>>>>>> Stashed changes
        }
    }

    public void ShowEnterButton()
    {
        if (GameController.Score1 == 100)
        {
            TargetText.text = "";
            CanvasCH1.SetActive(true);
            WSCH1Button.GetComponentInChildren<Text>().text = "確認";
            InfoText.text = "死亡數：" + GameController.DeadNum + "\n按下確認進入下一階段。";
            GameController.LiveNum = 0;
            GameController.DeadNum = 0;
            WSCH1Button.SetActive(true);
        }
        else
        {
            InfoText.text = "觀察完了草原生態系和極地生態系的動物們後，\n接下來讓我們來玩個小遊戲吧！";
            WSCH1Button.SetActive(true);
        }
    }

    public void ShowEnterButtonCh2()
    {
        InfoText.text = "";
        EnterButtonCh2.SetActive(true);
    }

    public void ShowFirstQuestion()
    {
        QuestionCount = 0;
        AllAns.SetActive(true);
        TemRain.SetActive(true);
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
        InfoText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void CheckAnswer()
    {
        ButtonSound.Play();
        if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == AnswerArr[ChNum][QuestionCount])
        {
            AnswerText.text = "";
            if (QuestionCount + 1 < QuestionArr[ChNum].Length)
            {
                QuestionCount++;
                if (QuestionArr[ChNum][QuestionCount] == "你覺得斑馬有哪些特徵呢？\n移動手把並點選，把這些特徵找出來吧。")
                {
                    StartCoroutine(web.php(GlobalSet.SID, "1", "4", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 1 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, "1", "10", WebPhp.php_method.Action));
                    CheckAnimal();
                    
                    AllAns.SetActive(false);
                }
                else if (ChNum == 2 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "20", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 3 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "23", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 4 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "27", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 5 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, "2", "33", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
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
            if (InfoText.text != "回答錯誤")
            {
                QuaternionRecord = InfoText.text;
            }
            InfoText.text = "回答錯誤";
            Invoke("EraseFeatureError", 2f);
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
    }

    public void CheckAnimal()
    {
        CanvasCH1.SetActive(false);
        if (ChNum == 0)
        {
            LionAn.Play("move");
            ZebraAn.Play("run");
            Lion.GetComponent<PathFollower>().enabled = true;
            Zebra.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在草原上的斑馬和獅子出現了！\n讓我們來仔細觀察一下牠們有哪些特徵吧。";
        }
        else if (ChNum == 1)
        {
            BearAn.Play("run");
            SealdogAn.Play("run");
            Bear.GetComponent<PathFollower>().enabled = true;
            Sealdog.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在極地裡的北極熊和海豹出現了！\n讓我們來仔細觀察一下牠們有哪些特徵吧。";
        }
        else if (ChNum == 2)
        {
            Oncorhynchus1.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在高山溪流生態系的櫻花鉤吻鮭出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        }
        else if (ChNum == 3)
        {
            CatAn1.Play("move");
            Cat1.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在淺山生態系的石虎出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        }
        else if (ChNum == 4)
        {
            BirdAn.Play("move");
            Bird.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "會在溼地生態系活動的黑面琵鷺出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        }
        else if (ChNum == 5)
        {
            Fish1.GetComponent<PathFollower>().enabled = true;
            Siganus.GetComponent<PathFollower>().enabled = true;
            Moorish.GetComponent<PathFollower>().enabled = true;
            Angelfish.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在珊瑚礁生態系的熱帶魚出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        }
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
            ZebraFootGameObject.SetActive(true);
            ZebraLinesGameObject.SetActive(true);
            TargetText.text = "斑馬特徵：" + ZebraNum + " / 2";
        }
        else if (ChNum == 1)
        {
            TargetText.text = "";
            BearAn.Play("idle");
            SealdogAn.Play("idle");
            PenguinAn.Play("idle");
            Bear.GetComponent<PathFollower>().enabled = false;
            Sealdog.GetComponent<PathFollower>().enabled = false;
            PenguinFa.GetComponent<PathFollower>().enabled = false;
            Sealdog.transform.LookAt(new Vector3(239.5f, 0.26f, 102f));
            Bear.transform.LookAt(new Vector3(239.6f, 0.26f, 94f));
            PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            BearHairGameObject.SetActive(true);
        }
        else if (ChNum == 2)
        {
            OncorhynchusLinesGameObject.SetActive(true);
            TargetText.text = "";
        }
        else if (ChNum == 3)
        {
            CatAn1.Play("idle");
            CatFaceGameObject.SetActive(true);
            CatLinesGameObject.SetActive(true);
            TargetText.text = "石虎特徵：" + CatNum + " / 2";
        }
        else if (ChNum == 4)
        {
            BirdAn.Play("idle");
            Bird.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            BirdFeatherGameObject.SetActive(true);
            BirdMouthGameObject.SetActive(true);
            TargetText.text = "黑面琵鷺特徵：" + BirdNum + " / 2";
        }
        else if (ChNum == 5)
        {
            FishColorGameObject.SetActive(true);
            TargetText.text = "";
        }
        CanvasCH1.SetActive(true);
        InfoText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void EraseFeatureError()
    {
        InfoText.text = QuaternionRecord;
    }

    public void CheckAnimalFeature(string Feature)
    {
        ButtonSound.Play();
        if (ChNum == 0 || ChNum == 1)
        {
            if (Feature == "LionHair")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "7", WebPhp.php_method.Action));
                InfoText.text = "通常只有雄性的獅子脖子上會有鬃毛，\n是為了可以在打鬥中保護自己的頭部和脖子。";
                LionHair = true;
                LionHairGameObject.SetActive(false);
                LionNum++;
                TargetText.text = "獅子特徵：" + LionNum + " / 2";
            }
            if (Feature == "LionTeeth")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "8", WebPhp.php_method.Action));
                InfoText.text = "獅子銳利的牙齒，讓牠可以\n在草原上更容易捕捉獵物、溫飽自己的肚子。";
                LionTeeth = true;
                LionTeethGameObject.SetActive(false);
                LionNum++;
                TargetText.text = "獅子特徵：" + LionNum + " / 2";
            }
            if (Feature == "ZebraLines")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "5", WebPhp.php_method.Action));
                InfoText.text = "斑馬身上的黑白紋路可以混淆斑馬的天敵的視覺，\n讓他沒辦法鎖定獵物。\n同時黑白相間的紋路還可以調節身體的溫度呢！";
                ZebraLines = true;
                ZebraLinesGameObject.SetActive(false);
                ZebraNum++;
                TargetText.text = "斑馬特徵：" + ZebraNum + " / 2";
            }
            if (Feature == "ZebraFoot")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "6", WebPhp.php_method.Action));
                InfoText.text = "斑馬的蹄可以讓牠在草原環境裡更快速的移動，\n避免被牠的天敵獵捕。";
                ZebraFoot = true;
                ZebraFootGameObject.SetActive(false);
                ZebraNum++;
                TargetText.text = "斑馬特徵：" + ZebraNum + " / 2";
            }
            if (Feature == "BearHair")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "11", WebPhp.php_method.Action));
                InfoText.text = "北極熊的毛可以防止水分滲入，達到禦寒的效果，\n同時皮膚底下有一層極厚的皮下脂肪加強保暖。";
                BearHairGameObject.SetActive(false);
                SealdogSkinGameObject.SetActive(true);
                QuestionCount++;
                InfoText.text = QuestionArr[ChNum][QuestionCount];
            }
            if (Feature == "SealdogSkin")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "12", WebPhp.php_method.Action));
                InfoText.text = "海豹有一層用來保暖的厚厚的皮下脂肪，\n並提供食物儲備，並產生浮力，\n讓牠可以漂浮在水面上。";
                SealdogSkinGameObject.SetActive(false);
                Invoke("PenguinGo", 2);
            }
            if (Feature == "PenguinFeather")
            {
                StartCoroutine(web.php(GlobalSet.SID, "1", "13", WebPhp.php_method.Action));
                InfoText.text = "企鵝身上的羽毛，具備防水、防風的功能。\n而且牠也有厚達2到3公分的皮下脂肪，\n可以讓企鵝保持體溫。";
                PenguinFeatherGameObject.SetActive(false);
                Ch1_2Complete = true;
                if (Ch1_1Complete == false)
                {
                    Invoke("CheckIce", 2);
                    Invoke("SelectGrassland", 4);
                }
            }
        }
        else if (ChNum == 2)
        {
            if (Feature == "OncorhynchusLines")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "21", WebPhp.php_method.Action));
                InfoText.text = "櫻花鉤吻鮭的身體側扁呈紡錘狀，背部青綠色，\n腹部為銀白色，體側中央有橢圓形雲紋斑點，\n牠像流水一般的身體線條，\n讓牠能夠更輕鬆的在快速流動中的水流裡移動。";
                OncorhynchusLinesGameObject.SetActive(false);
                SM2Button1.interactable = false;
                Ch2_1Complete = true;
                Ch2Complete++;
                if (Ch2Complete != 4)
                {
                    Invoke("CH2Done", 2);
                    Invoke("CheckOther", 4);
                }
                else
                {
                    Invoke("CH2End", 2);
                }
            }
        }
        else if (ChNum == 3)
        {
            if (Feature == "CatFace")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "24", WebPhp.php_method.Action));
                InfoText.text = "額頭有兩條灰白色縱帶，\n最大特徵是耳後有一塊淡黃色的圓斑。";
                CatFaceGameObject.SetActive(false);
                CatFace = true;
                CatNum++;
                TargetText.text = "石虎特徵：" + CatNum + " / 2";
            }
            else if (Feature == "CatLines")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "25", WebPhp.php_method.Action));
                InfoText.text = "石虎的身體、四肢、尾巴都有斑點的花紋。";
                CatLinesGameObject.SetActive(false);
                CatLines = true;
                CatNum++;
                TargetText.text = "石虎特徵：" + CatNum + " / 2";
            }
        }
        else if (ChNum == 4)
        {
            if (Feature == "BirdMouth")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "28", WebPhp.php_method.Action));
                InfoText.text = "黑面琵鷺有著長長的黑色扁平嘴巴，\n覓食的時候會以扁平的嘴喙\n在淺水中左右撈動，來尋找食物。";
                BirdMouthGameObject.SetActive(false);
                BirdMouth = true;
                BirdNum++;
                TargetText.text = "黑面琵鷺特徵：" + BirdNum + " / 2";
            }
            else if (Feature == "BirdFeather")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "29", WebPhp.php_method.Action));
                InfoText.text = "當黑面琵鷺在繁殖期的時候，\n牠的冠羽和胸前的羽毛會有明顯的黃色哦。";
                BirdFeatherGameObject.SetActive(false);
                BirdFeather = true;
                BirdNum++;
                TargetText.text = "黑面琵鷺特徵：" + BirdNum + " / 2";
            }
            else if (Feature == "CrabTomb")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "30", WebPhp.php_method.Action));
                InfoText.text = "雄性招潮蟹的大螯除了拿來防禦、威嚇之外，\n在繁殖期間還會在沙灘上不斷的揮舞大螯來求偶，\n直到漲潮的時候才會停止。";
                CrabTombGameObject.SetActive(false);
                Invoke("CheckMud", 2);
            }
            else if (Feature == "MudskipperSkin")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "31", WebPhp.php_method.Action));
                InfoText.text = "彈塗魚潮溼的皮膚可以幫助呼吸，\n胸鰭能推動身體前進。";
                MudskipperSkinGameObject.SetActive(false);
                Ch2_3Complete = true;
                SM2Button3.interactable = false;
                Ch2Complete++;
                if (Ch2Complete != 4)
                {
                    Invoke("CH2Done", 2);
                    Invoke("CheckOther", 4);
                }
                else
                {
                    Invoke("CH2End", 2);
                }
            }
        }
        else if (ChNum == 5)
        {
            if (Feature == "FishColor")
            {
                StartCoroutine(web.php(GlobalSet.SID, "2", "34", WebPhp.php_method.Action));
                InfoText.text = "大多數的熱帶魚都有著光彩奪目的顏色，\n是為了配合珊瑚礁的色彩，\n並逃避天敵的捕食。";
                FishColorGameObject.SetActive(false);
                Ch2_4Complete = true;
                SM2Button4.interactable = false;
                Ch2Complete++;
                if (Ch2Complete != 4)
                {
                    Invoke("CH2Done", 2);
                    Invoke("CheckOther", 4);
                }
                else
                {
                    Invoke("CH2End", 2);
                }
            }
        }
    }

    public void PenguinGo()
    {
        CanvasCH1.SetActive(false);
        Bear.SetActive(false);
        Sealdog.SetActive(false);
        PenguinAn.Play("walk");
        PenguinFa.GetComponent<PathFollower>().enabled = true;
        QuestionCount++;
        TargetText.text = "快看！生活在極地裡的企鵝也出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        Invoke("PenguinOpen", 6.5f);
        Invoke("AnStop", 6.5f);
    }

    public void PenguinOpen()
    {
        PenguinFeatherGameObject.SetActive(true);
    }

    public void CrabAndMudGo()
    {
        Canvas2.transform.position = new Vector3(240.27f, 2.6f, 91.7f);
        Canvas2.transform.LookAt(new Vector3(240.53f, 2.6f, 87.5f));
        Bird.SetActive(false);
        CanvasCH1.SetActive(false);
        TargetText.text = "";
        Crab.GetComponent<PathFollower>().enabled = true;
        MudskipperAn.Play("jump");
        Mudskipper.GetComponent<PathFollower>().enabled = true;
        QuestionCount++;
        TargetText.text = "生活在溼地生態系的彈塗魚和招潮蟹也出現了！\n讓我們來仔細觀察一下牠們身上有哪些特徵吧。";
        Invoke("CrabAndMudAnStop", 6.5f);
    }

    public void CrabAndMudAnStop()
    {
        TargetText.text = "";
        CanvasCH1.transform.position = new Vector3(240.27f, 2.6f, 91.7f);
        CanvasCH1.transform.LookAt(new Vector3(240.53f, 2.6f, 87.5f));
        CrabAn.Play("idle");
        Crab.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        MudskipperAn.Play("idle");
        Mudskipper.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        CrabTombGameObject.SetActive(true);
        CanvasCH1.SetActive(true);
        InfoText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void SelectGrassland()
    {
        if (Ch1_2Complete != true)
        {
            ButtonSound.Play();
        }
        StartCoroutine(web.php(GlobalSet.SID, "1", "1", WebPhp.php_method.Action));
        ChNum = 0;
        Ch1_1.SetActive(true);
        Ch1_2.SetActive(false);
        SelectMenu1.SetActive(false);
        CanvasCH1.SetActive(true);
        InfoText.text = QuestionArr[ChNum][0];
        ShowFirstQuestion();
    }

    public void SelectIce()
    {
        if (Ch1_1Complete != true)
        {
            ButtonSound.Play();
        }
        StartCoroutine(web.php(GlobalSet.SID, "1", "2", WebPhp.php_method.Action));
        ChNum = 1;
        InfoText.text = QuestionArr[ChNum][0];
        Ch1_1.SetActive(false);
        Ch1_2.SetActive(true);
        SelectMenu1.SetActive(false);
        CanvasCH1.SetActive(true);
        ShowFirstQuestion();
    }

    public void SelectHigh()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, "2", "15", WebPhp.php_method.Action));
        ChNum = 2;
        Ch2_1.SetActive(true);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        InfoText.text = QuestionArr[ChNum][0];
        CanvasCH1.transform.position = new Vector3(238.58f, 2.6f, 106.91f);
        CanvasCH1.transform.LookAt(new Vector3(238.53f, 2.6f, 107.41f));
        Canvas2.transform.position = new Vector3(238.58f, 2.6f, 106.91f);
        Canvas2.transform.LookAt(new Vector3(238.53f, 2.6f, 107.41f));
        ShowFirstQuestion();
    }

    public void SelectLow()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, "2", "16", WebPhp.php_method.Action));
        ChNum = 3;
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(true);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        InfoText.text = QuestionArr[ChNum][0];
        CanvasCH1.transform.position = new Vector3(240f, 2.6f, 91.77f);
        CanvasCH1.transform.LookAt(new Vector3(240f, 2.6f, 88.71f));
        Canvas2.transform.position = new Vector3(240f, 2.6f, 91.77f);
        Canvas2.transform.LookAt(new Vector3(240f, 2.6f, 88.71f));
        ShowFirstQuestion();
    }

    public void SelectWet()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, "2", "17", WebPhp.php_method.Action));
        ChNum = 4;
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(true);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        InfoText.text = QuestionArr[ChNum][0];
        CanvasCH1.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        CanvasCH1.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        Canvas2.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        Canvas2.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        ShowFirstQuestion();
    }

    public void SelectCoral()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, "2", "18", WebPhp.php_method.Action));
        ChNum = 5;
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(true);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        InfoText.text = QuestionArr[ChNum][0];
        CanvasCH1.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        CanvasCH1.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        Canvas2.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        Canvas2.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        ShowFirstQuestion();
    }

    public void Game()
    {
        Plane.SetActive(true);
        StartCoroutine(web.php(GlobalSet.SID, "1", "14", WebPhp.php_method.Action));
        GameController.Reset();
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
            ShowCongraText();
<<<<<<< Updated upstream
            //StartCoroutine(web.php(GlobalSet.SID, "2", "35", WebPhp.php_method.Action));
            //TargetText.text = "請選出適合在此環境中生存的動物";
            //TipText.text = "用右手將動物抓起吧！";
            //ShowEnterButtonCh2();
=======
>>>>>>> Stashed changes
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

    public void StartSelect()
    {
        ButtonSound.Play();
        Debug.Log(WSBtnNum);
        if (ChNum == 0 || ChNum == 1)
        {
            if (WSBtnNum == 0)
            { 
                SelectMenu1.SetActive(true);
                WSCH1Button.SetActive(false);
                CanvasCH1.SetActive(false);
            }
            else if (WSBtnNum == 1)
            {
                Ch1_1.SetActive(true);
                Ch1_2.SetActive(true);
                Terrain.SetActive(true);
                IceTerrain.SetActive(false);
                Zebra.SetActive(false);
                Lion.SetActive(false);
                Penguin.SetActive(false);
                InfoText.text = "認識了上面幾種生態系以及在裡面生活的動物後\n讓我們來玩個小遊戲吧！";
            }
            else if (WSBtnNum == 2)
            {
                WSCH1Button.GetComponentInChildren<Text>().text = "開始";
                InfoText.text = "仔細觀察周圍的環境，判斷這是什麼生態系，\n並把適合在這個生態系生活的動物抓出來，\n讓牠可以居住在舒適的地方吧。\n要小心如果選錯動物的話，\n動物可能會因為環境適應不良而無法在這裡生存哦！";
            }
            else if (WSBtnNum == 3)
            {
                Game();
                CanvasCH1.SetActive(false);
                TargetText.text = "剩餘動物：5";
            }
            else if (WSBtnNum == 4)
            {
                Game();
                CanvasCH1.SetActive(false);
                TargetText.text = "剩餘動物：5";
            }
            else if (WSBtnNum == 5)
            {
                InfoText.text = "恭喜你完成本單元！在這個單元裡，\n有沒有更加瞭解動物特徵與生活環境的關聯呢？\n動物為了適應環境並生存，\n會對應不同的生態系演化出不同的特徵與能力。\n想一想，你還知道哪些動物為了生存在草原或極地，\n擁有獨特的外觀特徵呢？";
            }
            else if (WSBtnNum == 6)
            {
                WSCH1Button.GetComponentInChildren<Text>().text = "回主選單";
                InfoText.text = "單元完成，內容已經記錄在探險筆記上面了，\n按A開啟/關閉探險筆記，回顧單元內容吧。";
            }
            else if (WSBtnNum == 7)
            {
                
            }
        }
        else if (ChNum > 1 && ChNum < 6)
        {
            if (WSBtnNum == 0)
            { 
                SelectMenu2.SetActive(true);
                WSCH1Button.SetActive(false);
                CanvasCH1.SetActive(false);
            }
            else if (WSBtnNum == 1)
            {
                WSCH1Button.GetComponentInChildren<Text>().text = "回主選單";
                InfoText.text = "單元完成，\n內容已經記錄在探險筆記上面了，\n按A開啟/關閉探險筆記，回顧單元內容吧。";
            }
            else if (WSBtnNum == 2)
            {

            }
        }
        WSBtnNum++;
    }
}
