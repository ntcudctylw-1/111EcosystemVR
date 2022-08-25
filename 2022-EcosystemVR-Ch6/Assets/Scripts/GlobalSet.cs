using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayMode))]
public class GlobalSet : MonoBehaviour
{
<<<<<<< Updated upstream
    

    public string SID;//¾Ç¸¹
    public long EntryTime, ExitTime; // ¶i¤J©MÂ÷¶}¾Ç²ß³æ¤¸ªº®É¶¡
    public string ServerIP = "www.ylw.idv.tw:81"; //SQL ServerIP
    public bool NetworkMode; //true: °O¿ý¦b»·ºÝ  false: °O¿ý¦b¥»¦a
    public int[] Score;//¦UÃö¥d¤À¼Æ
=======
    public string SID;//ï¿½Ç¸ï¿½
    public long EntryTime, ExitTime; // ï¿½iï¿½Jï¿½Mï¿½ï¿½ï¿½}ï¿½Ç²ß³æ¤¸ï¿½ï¿½ï¿½É¶ï¿½
    public string ServerIP = ""; //SQL ServerIP
    public bool NetworkMode; //true: ï¿½Oï¿½ï¿½ï¿½bï¿½ï¿½ï¿½ï¿½  false: ï¿½Oï¿½ï¿½ï¿½bï¿½ï¿½ï¿½a
    public int[] Score;//ï¿½Uï¿½ï¿½ï¿½dï¿½ï¿½ï¿½ï¿½
>>>>>>> Stashed changes

    public enum PlayMode
    {
        Auto,
        VR,
        PC
    }

    void Portfolio(string TargetName/*ï¿½Ø¼Ð¹ï¿½H*/)
    {
        //ï¿½æ¤¸ 
        //ï¿½ï¿½ï¿½sï¿½ï¿½ï¿½A
        //ï¿½É¶ï¿½~
    }



    //VRï¿½ï¿½ï¿½ï¿½//

    public static XRIDefaultInputActions inputActions;
    


    public struct VRTrigger
    {
        public float Value; //ï¿½ï¿½ï¿½sï¿½ï¿½
        public bool OnPress;//ï¿½ï¿½ï¿½ï¿½ï¿½Uï¿½ï¿½ï¿½s
        public bool OnPressing;//ï¿½ï¿½ï¿½sï¿½ï¿½ï¿½ï¿½
        public bool OnLeave;//ï¿½ï¿½ï¿½sï¿½ï¿½ï¿½}
    }

    public struct Hand
    {
        public Vector3 Position;//ï¿½ï¿½m
        public Quaternion Rotation;//ï¿½ï¿½ï¿½à¨¤ï¿½ï¿½
        public bool ButtonA;//ï¿½Uï¿½ï¿½ï¿½s
        public bool ButtonB;//ï¿½Wï¿½ï¿½ï¿½s
        public VRTrigger Trigger;//ï¿½ï¿½ï¿½ï¿½ï¿½Oï¿½ï¿½
        public VRTrigger Grip;//ï¿½ì´¤ï¿½Oï¿½ï¿½
    }
    public struct Head
    {
        public Vector3 Position;//ï¿½ï¿½m
        public Quaternion Rotation;//ï¿½ï¿½ï¿½à¨¤ï¿½ï¿½

    }
    public static Hand LeftHand;//ï¿½ï¿½ï¿½â±±ï¿½î¾¹
    public static Hand RightHand;//ï¿½kï¿½â±±ï¿½î¾¹
    public static Head HeadSet;//ï¿½Yï¿½ï¿½

    public static PlayMode playMode;
    public PlayMode SetMode = PlayMode.VR;

    private void Update()   
    {
        LeftHand.Position = inputActions.XRILeftHand.Position.ReadValue<Vector3>();
        LeftHand.Rotation = inputActions.XRILeftHand.Rotation.ReadValue<Quaternion>();
        LeftHand.Trigger.Value = inputActions.XRILeftHandInteraction.ActivateValue.ReadValue<float>();
        LeftHand.Trigger.OnPressing = inputActions.XRILeftHandInteraction.Activate.ReadValue<float>() == 1 ? true : false;
        LeftHand.Grip.Value = inputActions.XRILeftHandInteraction.SelectValue.ReadValue<float>();
        LeftHand.Grip.OnPressing = inputActions.XRILeftHandInteraction.Select.ReadValue<float>() == 1 ? true : false;
        LeftHand.ButtonA = inputActions.XRILeftHandInteraction.ButtonA.ReadValue<float>() == 1 ? true : false;
        //Debug.Log(LeftHand.ButtonA);
        LeftHand.ButtonB = inputActions.XRILeftHandInteraction.ButtonB.ReadValue<float>() == 1 ? true : false;


        RightHand.Position = inputActions.XRIRightHand.Position.ReadValue<Vector3>();
        RightHand.Rotation = inputActions.XRIRightHand.Rotation.ReadValue<Quaternion>();
        RightHand.Trigger.Value = inputActions.XRIRightHandInteraction.ActivateValue.ReadValue<float>();
        RightHand.Trigger.OnPressing = inputActions.XRIRightHandInteraction.Activate.ReadValue<float>() == 1 ? true : false;
        RightHand.Grip.Value = inputActions.XRIRightHandInteraction.SelectValue.ReadValue<float>();
        RightHand.Grip.OnPressing = inputActions.XRIRightHandInteraction.Select.ReadValue<float>() == 1 ? true : false;
        RightHand.ButtonA = inputActions.XRIRightHandInteraction.ButtonA.ReadValue<float>() == 1 ? true : false;
        RightHand.ButtonB = inputActions.XRIRightHandInteraction.ButtonB.ReadValue<float>() == 1 ? true : false;



        HeadSet.Position = inputActions.XRIHead.Position.ReadValue<Vector3>();
        HeadSet.Rotation = inputActions.XRIHead.Rotation.ReadValue<Quaternion>();
        playMode = SetMode;
    }

    private void Awake()
    {
        if (playMode == PlayMode.Auto && Application.platform == RuntimePlatform.Android)
        {
            SetMode = PlayMode.VR;
        }
        else if (playMode == PlayMode.Auto && Application.platform == RuntimePlatform.WindowsPlayer)
        {
            SetMode = PlayMode.PC;
        }
        playMode = SetMode;
        inputActions = new XRIDefaultInputActions();
        inputActions.Enable();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnDestroy()
    {
        inputActions.Dispose();
    }


}