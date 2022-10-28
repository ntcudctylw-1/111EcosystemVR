using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

using UnityEngine.XR.Interaction.Toolkit;

using PathCreation.Examples;
using Random=UnityEngine.Random;
#if UNITY_ANDROID
using Wave.OpenXR.Toolkit.Raycast;
#endif
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int SetChNum;
    WebPhp web;
    public GameObject SelectMenu1;
    public GameObject SelectMenu2;

    public AudioSource ButtonSound;
    public GameObject AllAns;

    public GameObject WSCH1Button;
    public int WSBtnNum = 0;

    public GameObject CanvasCH1;
    public GameObject Canvas2;
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

    
    public GameObject Lion1;
    public GameObject Zebra1;
    public GameObject Lion2;
    public GameObject Zebra2;
    public GameObject Bear1;
    public GameObject Penguin1;
    public GameObject PenguinFa1;
    public GameObject Sealdog1;
    public GameObject Bear2;
    public GameObject Penguin2;
    public GameObject PenguinFa2;
    public GameObject Sealdog2;
    public GameObject Oncorhynchus;
    public GameObject Cat;
    public GameObject Bird;
    public GameObject Crab;
    public GameObject Mudskipper;
    public GameObject Fish;
    public GameObject Siganus;
    public GameObject Moorish;
    public GameObject Angelfish;

    public Animator LionAn1;
    public Animator ZebraAn1;
    public Animator LionAn2;
    public Animator ZebraAn2;
    public Animator BearAn1;
    public Animator BearAn2;
    public Animator SealdogAn1;
    public Animator SealdogAn2;
    public Animation PenguinAn1;
    public Animation PenguinAn2;
    public Animator OncorhynchusAn;
    public Animator CatAn;
    public Animator BirdAn;
    public Animator CrabAn;
    public Animator MudskipperAn;
    public Animator FishAn;

    public GameObject LionHairGameObject;
    public GameObject LionTeethGameObject;
    public GameObject ZebraLinesGameObject;
    public GameObject ZebraFootGameObject;
    public GameObject BearHairGameObject;
    public GameObject SealdogSkinGameObject;
    public GameObject PenguinFeatherGameObject;
    public GameObject OncorhynchusLinesGameObject;
    public GameObject CatFaceGameObject;
    public GameObject CatLinesGameObject;
    public GameObject BirdMouthGameObject;
    public GameObject BirdFeatherGameObject;
    public GameObject CrabTombGameObject;
    public GameObject MudskipperSkinGameObject;
    public GameObject FishColorGameObject;

    bool LionHair = false;
    bool LionTeeth = false;
    bool ZebraLines = false;
    bool ZebraFoot = false;
    bool CatFace = false;
    bool CatLines = false;
    bool BirdMouth = false;
    bool BirdFeather = false;

    public int ZebraNum = 0;
    public int LionNum = 0;
    public int CatNum = 0;
    public int BirdNum = 0;
    
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

    public Text ThermometerText;
    public Text RainText;

    public GameObject RightHandController;
    public GameObject LeftHandController;

    public bool Wait = false;

    public GameObject CH3;

    public GameObject[] NoteArr;
    public int Page = 0;
    public GameObject NextButton;
    public GameObject LastButton;
    public GameObject CompleteImage;

    public VideoPlayer LionVideoPlayer;
    public GameObject LionVideo;
    public VideoPlayer ZebraVideoPlayer;
    public GameObject ZebraVideo;

    public AudioSource[] CH1Audio;
    public AudioSource[] CH2Audio;

    public bool SLearn = false;

    public string[][] TemAndRainArr = {new string [] {"24℃", "300mm"}
    , new string[] {"-20℃", "150mm"}
    , new string[] {"12℃", "2200mm"}
    , new string[] {"25℃", "2010mm"}
    , new string[] {"23℃", "1300mm"}
    , new string[] {"25℃", "2736mm"}};

    public string[][] QuestionArr = {
    new string[] {"我們現在來到了草原生態系。\n看一看旁邊顯示的溫度計，\n你覺得現在的環境感覺如何？" //0 草原
    , "四處看看草原生態系的景象，\n並觀察一下附近的植物有什麼特徵呢？"
    , "你覺得斑馬有哪些特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
    , "很好，斑馬的特徵有牠身上黑白相間的條紋和牠的蹄。\n再來讓我們觀察旁邊的獅子，\n你覺得獅子有哪些特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了極地生態系。\n看一看旁邊顯示的溫度計，\n你覺得現在的環境感覺如何？" //1 極地
    , "四處看看極地生態系的景象，\n你覺得四周的環境有什麼特別的地方嗎？"
    , "觀察北極熊，你覺得北極熊\n有哪個部位可以幫助牠保暖呢？\n移動手把或準星點選該部位。"
    , "北極熊身上厚重的毛皮能幫助牠保暖，\n讓牠可以在這麼寒冷的環境底下生存。\n再觀察一旁的海豹，\n你覺得海豹有哪個部位可以幫助牠保暖呢？\n移動手把或準星點選該部位。"
    , "觀察企鵝，你覺得企鵝\n有哪個部位可以幫助牠保暖呢？\n移動手把或準星點選該部位。？"
    }, new string[] {"我們現在來到了高山溪流生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //2 高山
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n櫻花鉤吻鮭的外型有什麼特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了淺山生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //3 淺山
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n你覺得石虎的外型有什麼特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了溼地生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //4 濕地
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n你覺得黑面琵鷺的外型有什麼特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
    , "仔細看一下，\n你覺得招潮蟹的外型有什麼特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
    , "仔細看一下，\n你覺得彈塗魚的外型有什麼特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
    }, new string[] {"我們現在來到了珊瑚礁生態系。\n觀察一下畫面上的溫度計和降雨量，\n你覺得現在的環境溫溼度如何？" //5 珊瑚礁
    , "移動你的視線，\n四處看看周圍的環境，\n觀察一下環境有什麼特徵呢？"
    , "仔細看一下，\n熱帶魚的外型有什麼特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。"
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
        Scene scene = SceneManager.GetActiveScene();
        print(scene.name[2]);
        if (scene.name[2] != null)
        {
            switch (int.Parse(scene.name[2].ToString()))
            {
                case 1:
                    SetChNum = 0;
                    break;
                case 2:
                    SetChNum = 2;
                    break;
                case 3:
                    SetChNum = 6;
                    break;
            }
        }
        ChNum = SetChNum;
        

        SLearn = GlobalSet.guideMode == GlobalSet.GuideMode.Self;


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
            #if UNITY_ANDROID
            RightHandController.GetComponent<RaycastPointer>().enabled = true;
#endif
            CH3.SetActive(true);
        }
        web = GetComponent<WebPhp>();
        PenguinAn1 = Penguin1.GetComponent<Animation>();
        NoteCH();
    }

    void Update()
    {
        if (NoteOpen == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (ZebraFoot == true && ZebraLines == true)
        {
            ZebraFoot = false;
            ZebraLines = false;
            Invoke("ZebraVideoPlay", 2);
            Invoke("CheckLion", 13);
        }
        if (LionHair == true && LionTeeth == true)
        {
            LionHair = false;
            LionTeeth = false;
            Invoke("LionVideoPlay", 2);
            Invoke("LionVideoEnd", 17);
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
        if (ChNum != 6)
        {
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
            if (Input.GetKeyDown(KeyCode.Tab))
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
        }
    }

    public void CheckLion()
    {
        CH1Audio[1].Play();
        ZebraVideo.SetActive(false);
        LionHairGameObject.SetActive(true);
        LionTeethGameObject.SetActive(true);
        QuestionCount++;
        if (SLearn == true)
        {
            InfoText.text = QuestionArr[ChNum][QuestionCount];
        }
        else
        {
            InfoText.text = "再來讓我們觀察旁邊的獅子，\n你覺得獅子有哪些特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。";
        }
        TargetText.text = "獅子特徵：" + LionNum + " / 2";
    }

    public void CheckMud()
    {
        CanvasCH1.SetActive(true);
        MudskipperSkinGameObject.SetActive(true);
        QuestionCount++;
        InfoText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void CheckIce()
    {
        CanvasCH1.SetActive(true);
        TargetText.text = "";
        InfoText.text = "觀察完草原的生態了，\n接下來觀察極地的生態吧！";
    }

    public void CheckGrassland()
    {
        CanvasCH1.SetActive(true);
        TargetText.text = "";
        InfoText.text = "觀察完極地的生態了，\n接下來觀察草原的生態吧！";
    }

    public void CH2Done()
    {
        CanvasCH1.SetActive(true);
        if (ChNum == 2)
        {
            InfoText.text = "觀察完高山溪流的生態了，\n接下來觀察其他的生態系吧！";            
        }
        else if (ChNum == 3)
        {
            TargetText.text = "";
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
        CanvasCH1.SetActive(true);
        WSCH1Button.SetActive(true);
        InfoText.text = "恭喜你完成本單元！\n在這個單元裡，有沒有更加認識\n台灣的各種特殊生態系以及特有動物呢？\n動物為了適應環境並生存，\n會對應不同的生態系演化出不同的特徵與能力。\n想一想，你還知道哪些動物\n為了生存在台灣的特殊生態系，\n而擁有獨特的外觀特徵呢？";
    }

    public void ShowCongraText()
    {
        if (ChNum == 0 || ChNum == 1)
        {
            CanvasCH1.SetActive(true);
            InfoText.text = "死亡數：" + GameController.DeadNum;
        }
    }

    public void ShowEnterButton()
    {
        CanvasCH1.SetActive(true);
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

    public void ShowFirstQuestion()
    {
        InfoText.text = QuestionArr[ChNum][0];
        QuestionCount = 0;
        AllAns.SetActive(true);
        TemRain.SetActive(true);
        ThermometerText.text = TemAndRainArr[ChNum][0];
        RainText.text = TemAndRainArr[ChNum][1];
        if (ChNum == 0)
        {
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "3", WebPhp.php_method.Action));
        }
        else if (ChNum == 1)
        {
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "9", WebPhp.php_method.Action));
        }
        else if (ChNum == 2)
        {
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "19", WebPhp.php_method.Action));
        }
        else if (ChNum == 3)
        {
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "22", WebPhp.php_method.Action));
        }
        else if (ChNum == 4)
        {
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "26", WebPhp.php_method.Action));
        }
        else if (ChNum == 5)
        {
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "32", WebPhp.php_method.Action));
        }
        AnsButton1.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][0];
        AnsButton2.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][1];
        AnsButton3.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][2];
    }

    public void ShowNextQuestion()
    {
        TemRain.SetActive(false);
        AnsButton1.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][0];
        AnsButton2.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][1];
        AnsButton3.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][2];
        InfoText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void CheckAnswer()
    {
        ButtonSound.Play();
        if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == AnswerArr[ChNum][QuestionCount])
        {
            if (QuestionCount + 1 < QuestionArr[ChNum].Length)
            {
                QuestionCount++;
                if (QuestionArr[ChNum][QuestionCount] == "你覺得斑馬有哪些特徵呢？\n移動手把或準星點選，把這些特徵找出來吧。")
                {
                    StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "4", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 1 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "10", WebPhp.php_method.Action));
                    CheckAnimal();
                    
                    AllAns.SetActive(false);
                }
                else if (ChNum == 2 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "20", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 3 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "23", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 4 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "27", WebPhp.php_method.Action));
                    CheckAnimal();
                    AllAns.SetActive(false);
                }
                else if (ChNum == 5 && QuestionCount == 2)
                {
                    StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "33", WebPhp.php_method.Action));
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

    public void LionAudio()
    {
        CH1Audio[1].Play();
    }

    public void SealdogAudio()
    {
        CH1Audio[3].Play();
    }

    public void CheckAnimal()
    {
        CanvasCH1.SetActive(false);
        if (ChNum == 0)
        {
            CH1Audio[0].Play();
            Invoke("LionAudio", 2);
            LionAn1.Play("walk");
            ZebraAn1.Play("run");
            Lion1.GetComponent<PathFollower>().enabled = true;
            Zebra1.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在草原上的斑馬和獅子出現了！\n讓我們來仔細觀察一下牠們有哪些特徵吧。";
        }
        else if (ChNum == 1)
        {
            CH1Audio[2].Play();
            Invoke("SealdogAudio", 1.5f);
            BearAn1.Play("run");
            SealdogAn1.Play("run");
            Bear1.GetComponent<PathFollower>().enabled = true;
            Sealdog1.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在極地裡的北極熊和海豹出現了！\n讓我們來仔細觀察一下牠們有哪些特徵吧。";
        }
        else if (ChNum == 2)
        {
            Oncorhynchus.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在高山溪流生態系的櫻花鉤吻鮭出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        }
        else if (ChNum == 3)
        {
            CatAn.Play("move");
            Cat.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "生活在淺山生態系的石虎出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        }
        else if (ChNum == 4)
        {
            CH2Audio[2].Play();
            BirdAn.Play("move");
            Bird.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "會在溼地生態系活動的黑面琵鷺出現了！\n讓我們來仔細觀察一下牠身上有哪些特徵吧。";
        }
        else if (ChNum == 5)
        {
            Fish.GetComponent<PathFollower>().enabled = true;
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
            CH1Audio[0].Play();
            LionAn1.Play("idle");
            ZebraAn1.Play("idle");
            Lion1.GetComponent<PathFollower>().enabled = false;
            Zebra1.GetComponent<PathFollower>().enabled = false;
            Zebra1.transform.LookAt(new Vector3(239.5f, 0.26f, 102f));
            Lion1.transform.LookAt(new Vector3(239.6f, 0.26f, 94f));
            ZebraFootGameObject.SetActive(true);
            ZebraLinesGameObject.SetActive(true);
            TargetText.text = "斑馬特徵：" + ZebraNum + " / 2";
        }
        else if (ChNum == 1)
        {
            if (Bear1.activeSelf)
            {
                CH1Audio[2].Play();
            }
            else
            {
                CH1Audio[4].Play();
            }
            TargetText.text = "";
            BearAn1.Play("idle");
            SealdogAn1.Play("idle");
            PenguinAn1.Play("idle");
            Bear1.GetComponent<PathFollower>().enabled = false;
            Sealdog1.GetComponent<PathFollower>().enabled = false;
            PenguinFa1.GetComponent<PathFollower>().enabled = false;
            Sealdog1.transform.LookAt(new Vector3(239.5f, 0.26f, 102f));
            Bear1.transform.LookAt(new Vector3(239.6f, 0.26f, 94f));
            PenguinFa1.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            BearHairGameObject.SetActive(true);
        }
        else if (ChNum == 2)
        {
            OncorhynchusLinesGameObject.SetActive(true);
            TargetText.text = "";
        }
        else if (ChNum == 3)
        {
            CatAn.Play("idle");
            CatFaceGameObject.SetActive(true);
            CatLinesGameObject.SetActive(true);
            TargetText.text = "石虎特徵：" + CatNum + " / 2";
        }
        else if (ChNum == 4)
        {
            CH2Audio[2].Play();
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
        if (ChNum == 0 || ChNum == 1)
        {
            if (Feature == "LionHair")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "7", WebPhp.php_method.Action));
                LionHair = true;
                LionHairGameObject.SetActive(false);
                LionNum++;
                TargetText.text = "獅子特徵：" + LionNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "通常只有雄性的獅子脖子上會有鬃毛，\n是為了可以在打鬥中保護自己的頭部和脖子。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            if (Feature == "LionTeeth")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "8", WebPhp.php_method.Action));
                LionTeeth = true;
                LionTeethGameObject.SetActive(false);
                LionNum++;
                TargetText.text = "獅子特徵：" + LionNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "獅子銳利的牙齒，讓牠可以\n在草原上更容易捕捉獵物、溫飽自己的肚子。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            if (Feature == "ZebraLines")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "5", WebPhp.php_method.Action));
                ZebraLines = true;
                ZebraLinesGameObject.SetActive(false);
                ZebraNum++;
                TargetText.text = "斑馬特徵：" + ZebraNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "斑馬身上的黑白紋路可以混淆斑馬的天敵的視覺，\n讓他沒辦法鎖定獵物。\n同時黑白相間的紋路還可以調節身體的溫度呢！";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            if (Feature == "ZebraFoot")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "6", WebPhp.php_method.Action));
                ZebraFoot = true;
                ZebraFootGameObject.SetActive(false);
                ZebraNum++;
                TargetText.text = "斑馬特徵：" + ZebraNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "斑馬的蹄可以讓牠在草原環境裡更快速的移動，\n避免被牠的天敵獵捕。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            if (Feature == "BearHair")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "11", WebPhp.php_method.Action));
                BearHairGameObject.SetActive(false);
                SealdogSkinGameObject.SetActive(true);
                QuestionCount++;
                InfoText.text = QuestionArr[ChNum][QuestionCount];
                CH1Audio[3].Play();
                if (SLearn == true)
                {
                    if (DisableWhenPC.IsPC == true)
                    {
                        InfoText.text = "北極熊身上厚重的毛皮能幫助牠保暖，\n讓牠可以在這麼寒冷的環境底下生存。\n再觀察一旁的海豹，\n你覺得海豹有哪個部位可以幫助牠保暖呢？\n移動準星並點選該部位。";
                    }
                    else
                    {
                        InfoText.text = "北極熊身上厚重的毛皮能幫助牠保暖，\n讓牠可以在這麼寒冷的環境底下生存。\n再觀察一旁的海豹，\n你覺得海豹有哪個部位可以幫助牠保暖呢？\n移動手把並點選該部位。";
                    }
                }
                else
                {
                    if (DisableWhenPC.IsPC == true)
                    {
                        InfoText.text = "再觀察一旁的海豹，\n你覺得海豹有哪個部位可以幫助牠保暖呢？\n移動準星並點選該部位。";
                    }
                    else
                    {
                        InfoText.text = "再觀察一旁的海豹，\n你覺得海豹有哪個部位可以幫助牠保暖呢？\n移動手把並點選該部位。";
                    }
                }
            }
            if (Feature == "SealdogSkin")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "12", WebPhp.php_method.Action));
                SealdogSkinGameObject.SetActive(false);
                Invoke("PenguinGo", 2);
                if (SLearn == true)
                {
                    InfoText.text = "海豹有一層用來保暖的厚厚的皮下脂肪，\n並提供食物儲備，並產生浮力，\n讓牠可以漂浮在水面上。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            if (Feature == "PenguinFeather")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "13", WebPhp.php_method.Action));
                PenguinFeatherGameObject.SetActive(false);
                Ch1_2Complete = true;
                if (Ch1_1Complete == false)
                {
                    Invoke("CheckGrassland", 2);
                    Invoke("SelectGrassland", 4);
                }
                if (SLearn == true)
                {
                    InfoText.text = "企鵝身上的羽毛，具備防水、防風的功能。\n而且牠也有厚達2到3公分的皮下脂肪，\n可以讓企鵝保持體溫。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
        }
        else if (ChNum == 2)
        {
            if (Feature == "OncorhynchusLines")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "21", WebPhp.php_method.Action));
                OncorhynchusLinesGameObject.SetActive(false);
                SM2Button1.interactable = false;
                Ch2_1Complete = true;
                Ch2Complete++;
                if (SLearn == true)
                {
                    InfoText.text = "櫻花鉤吻鮭的身體側扁呈紡錘狀，背部青綠色，\n腹部為銀白色，體側中央有橢圓形雲紋斑點，\n牠像流水一般的身體線條，\n讓牠能夠更輕鬆的在快速流動中的水流裡移動。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
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
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "24", WebPhp.php_method.Action));
                CatFaceGameObject.SetActive(false);
                CatFace = true;
                CatNum++;
                TargetText.text = "石虎特徵：" + CatNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "額頭有兩條灰白色縱帶，\n最大特徵是耳後有一塊淡黃色的圓斑。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            else if (Feature == "CatLines")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "25", WebPhp.php_method.Action));
                CatLinesGameObject.SetActive(false);
                CatLines = true;
                CatNum++;
                TargetText.text = "石虎特徵：" + CatNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "石虎的身體、四肢、尾巴都有斑點的花紋。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
        }
        else if (ChNum == 4)
        {
            if (Feature == "BirdMouth")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "28", WebPhp.php_method.Action));
                BirdMouthGameObject.SetActive(false);
                BirdMouth = true;
                BirdNum++;
                TargetText.text = "黑面琵鷺特徵：" + BirdNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "黑面琵鷺有著長長的黑色扁平嘴巴，\n覓食的時候會以扁平的嘴喙\n在淺水中左右撈動，來尋找食物。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            else if (Feature == "BirdFeather")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "29", WebPhp.php_method.Action));
                BirdFeatherGameObject.SetActive(false);
                BirdFeather = true;
                BirdNum++;
                TargetText.text = "黑面琵鷺特徵：" + BirdNum + " / 2";
                if (SLearn == true)
                {
                    InfoText.text = "當黑面琵鷺在繁殖期的時候，\n牠的冠羽和胸前的羽毛會有明顯的黃色哦。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            else if (Feature == "CrabTomb")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "30", WebPhp.php_method.Action));
                CrabTombGameObject.SetActive(false);
                Invoke("CheckMud", 2);
                if (SLearn == true)
                {
                    InfoText.text = "雄性招潮蟹的大螯除了拿來防禦、威嚇之外，\n在繁殖期間還會在沙灘上不斷的揮舞大螯來求偶，\n直到漲潮的時候才會停止。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
            }
            else if (Feature == "MudskipperSkin")
            {
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "31", WebPhp.php_method.Action));
                InfoText.text = "彈塗魚潮溼的皮膚可以幫助呼吸，\n胸鰭能推動身體前進。";
                MudskipperSkinGameObject.SetActive(false);
                Ch2_3Complete = true;
                SM2Button3.interactable = false;
                Ch2Complete++;
                if (SLearn == true)
                {
                    InfoText.text = "彈塗魚潮溼的皮膚可以幫助呼吸，\n胸鰭能推動身體前進。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
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
                ButtonSound.Play();
                StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "34", WebPhp.php_method.Action));
                FishColorGameObject.SetActive(false);
                Ch2_4Complete = true;
                SM2Button4.interactable = false;
                Ch2Complete++;
                if (SLearn == true)
                {
                    InfoText.text = "大多數的熱帶魚都有著光彩奪目的顏色，\n是為了配合珊瑚礁的色彩，\n並逃避天敵的捕食。";
                }
                else
                {
                    CanvasCH1.SetActive(false);
                    InfoText.text = "";
                }
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
        CH1Audio[4].Play();
        CanvasCH1.SetActive(false);
        Bear1.SetActive(false);
        Sealdog1.SetActive(false);
        PenguinAn1.Play("walk");
        PenguinFa1.GetComponent<PathFollower>().enabled = true;
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
        StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "1", WebPhp.php_method.Action));
        ChNum = 0;
        Ch1_1.SetActive(true);
        Ch1_2.SetActive(false);
        SelectMenu1.SetActive(false);
        CanvasCH1.SetActive(true);
        ShowFirstQuestion();
    }

    public void SelectIce()
    {
        if (Ch1_1Complete != true)
        {
            ButtonSound.Play();
        }
        StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "2", WebPhp.php_method.Action));
        ChNum = 1;
        Ch1_1.SetActive(false);
        Ch1_2.SetActive(true);
        SelectMenu1.SetActive(false);
        CanvasCH1.SetActive(true);
        ShowFirstQuestion();
    }

    public void SelectHigh()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "15", WebPhp.php_method.Action));
        ChNum = 2;
        Ch2_1.SetActive(true);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        CanvasCH1.transform.position = new Vector3(238.58f, 2.6f, 106.91f);
        CanvasCH1.transform.LookAt(new Vector3(238.53f, 2.6f, 107.41f));
        Canvas2.transform.position = new Vector3(238.58f, 2.6f, 106.91f);
        Canvas2.transform.LookAt(new Vector3(238.53f, 2.6f, 107.41f));
        ShowFirstQuestion();
    }

    public void SelectLow()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "16", WebPhp.php_method.Action));
        ChNum = 3;
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(true);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        CanvasCH1.transform.position = new Vector3(240f, 2.6f, 91.77f);
        CanvasCH1.transform.LookAt(new Vector3(240f, 2.6f, 88.71f));
        Canvas2.transform.position = new Vector3(240f, 2.6f, 91.77f);
        Canvas2.transform.LookAt(new Vector3(240f, 2.6f, 88.71f));
        ShowFirstQuestion();
    }

    public void SelectWet()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "17", WebPhp.php_method.Action));
        ChNum = 4;
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(true);
        Ch2_4.SetActive(false);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        CanvasCH1.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        CanvasCH1.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        Canvas2.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        Canvas2.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        ShowFirstQuestion();
    }

    public void SelectCoral()
    {
        ButtonSound.Play();
        StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "18", WebPhp.php_method.Action));
        ChNum = 5;
        Ch2_1.SetActive(false);
        Ch2_2.SetActive(false);
        Ch2_3.SetActive(false);
        Ch2_4.SetActive(true);
        SelectMenu2.SetActive(false);
        CanvasCH1.SetActive(true);
        CanvasCH1.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        CanvasCH1.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        Canvas2.transform.position = new Vector3(246.23f, 2.6f, 99.07f);
        Canvas2.transform.LookAt(new Vector3(253.67f, 2.6f, 99.71f));
        ShowFirstQuestion();
    }

    public void Game()
    {
        Plane.SetActive(true);
        StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "14", WebPhp.php_method.Action));
        GameObject.Find("LevelController").GetComponent<GameController>().Reset();
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
            Lion2.SetActive(false);
            Zebra2.SetActive(false);
            Bear2.SetActive(false);
            Penguin2.SetActive(false);
            Sealdog2.SetActive(false);
        }
        Lion2.SetActive(true);
        Zebra2.SetActive(true);
        Bear2.SetActive(true);
        Penguin2.SetActive(true);
        Sealdog2.SetActive(true);
        LionAn2.Play("idle", 0, 0f);
        ZebraAn2.Play("idle", 0, 0f);
        BearAn2.Play("idle", 0, 0f);
        SealdogAn2.Play("idle", 0, 0f);
        PenguinAn2.Play("idle");
        Penguin2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        PenguinFa2.transform.localEulerAngles = new Vector3(0, -124, 0);
        Zebra2.transform.position = new Vector3(242, -0.2f, 102);
        Lion2.transform.position = new Vector3(240, -0.2f, 102);
        Sealdog2.transform.position = new Vector3(241, 2f, 95);
        Bear2.transform.position = new Vector3(245, -0.2f, 95);
        PenguinFa2.transform.position = new Vector3(242, 1, 100);
        Penguin2.transform.localPosition = new Vector3(0, 0, 0);

        Lion2.GetComponent<XRGrabInteractable>().enabled = true;
        Zebra2.GetComponent<XRGrabInteractable>().enabled = true;
        Bear2.GetComponent<XRGrabInteractable>().enabled = true;
        Sealdog2.GetComponent<XRGrabInteractable>().enabled = true;
        Penguin2.GetComponent<XRGrabInteractable>().enabled = true;

        Lion2.GetComponent<BoxCollider>().enabled = true;
        Zebra2.GetComponent<BoxCollider>().enabled = true;
        Bear2.GetComponent<BoxCollider>().enabled = true;
        Sealdog2.GetComponent<BoxCollider>().enabled = true;
        Penguin2.GetComponent<BoxCollider>().enabled = true;
        
        LookAtCamera();
    }
    
    public void LookAtCamera()
    {
        if (ChNum == 0 || ChNum == 1)
        {
            Zebra2.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Lion2.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            Sealdog2.transform.LookAt(new Vector3(239.53f, 2, 98.3f));
            Bear2.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
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
                Zebra1.SetActive(false);
                Lion1.SetActive(false);
                Penguin1.SetActive(false);
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
                if (DisableWhenPC.IsPC == true)
                {
                    InfoText.text = "單元完成，內容已經記錄在探險筆記上面了，\n按TAB開啟/關閉探險筆記，回顧單元內容吧。";
                }
                else
                {
                    InfoText.text = "單元完成，內容已經記錄在探險筆記上面了，\n按A開啟/關閉探險筆記，回顧單元內容吧。";
                }
                CompleteImage.SetActive(true);
            }
            else if (WSBtnNum == 7)
            {
                SceneManager.LoadScene("Menu");
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
                if (DisableWhenPC.IsPC == true)
                {
                    InfoText.text = "單元完成，內容已經記錄在探險筆記上面了，\n按TAB開啟/關閉探險筆記，回顧單元內容吧。";
                }
                else
                {
                    InfoText.text = "單元完成，內容已經記錄在探險筆記上面了，\n按A開啟/關閉探險筆記，回顧單元內容吧。";
                }
                CompleteImage.SetActive(true);
            }
            else if (WSBtnNum == 2)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        WSBtnNum++;
    }

    public void NoteCH()
    {
        if (ChNum == 0 || ChNum == 1)
        {
            Page = 0;
            NoteArr[0].SetActive(true);
        }
        else if (ChNum > 1 && ChNum < 6)
        {
            Page = 5;
            NoteArr[5].SetActive(true);
        }
    }

    public void NextPage()
    {
        ButtonSound.Play();
        if (ChNum == 0 || ChNum == 1)
        {
            NoteArr[Page].SetActive(false);
            NoteArr[Page + 1].SetActive(true);
            if (Page + 2 == 5) //下一頁是最後一頁
            {
                NextButton.SetActive(false);
            }
        }
        else if (ChNum > 1 && ChNum < 6)
        {
            NoteArr[Page].SetActive(false);
            NoteArr[Page + 1].SetActive(true);
            if (Page + 2 == 11) //下一頁是最後一頁
            {
                NextButton.SetActive(false);
            }
        }
        Page++;
        LastButton.SetActive(true);
    }

    public void LastPage()
    {
        ButtonSound.Play();
        if (ChNum == 0 || ChNum == 1)
        {
            NoteArr[Page].SetActive(false);
            NoteArr[Page - 1].SetActive(true);
            if (Page - 2 < 0) //上一頁是第一頁
            {
                LastButton.SetActive(false);
            }
        }
        else if (ChNum > 1 && ChNum < 6)
        {
            NoteArr[Page].SetActive(false);
            NoteArr[Page - 1].SetActive(true);
            if (Page - 2 < 5) //上一頁是第一頁
            {
                LastButton.SetActive(false);
            }
        }
        Page--;
        NextButton.SetActive(true);
    }

    public void LionVideoPlay()
    {
        CanvasCH1.SetActive(true);
        LionVideo.SetActive(true);
        LionVideoPlayer.Play();
        InfoText.text = "身為恆溫動物的獅子，\n需要透過伸出舌頭喘氣的方式，\n幫助自己散熱、\n適應周圍環境的溫度變化。";
    }

    public void LionVideoEnd()
    {
        LionVideo.SetActive(false);
        Ch1_1Complete = true;
        if (Ch1_2Complete != true)
        {
            Invoke("CheckIce", 2);
            Invoke("SelectIce", 4);
        }
    }
    
    public void ZebraVideoPlay()
    {
        CanvasCH1.SetActive(true);
        ZebraVideo.SetActive(true);
        ZebraVideoPlayer.Play();
        InfoText.text = "斑馬藉由透過皮膚排汗，\n來幫助自己達到散熱的效果、\n適應周圍環境的溫度變化。";
    }
}
