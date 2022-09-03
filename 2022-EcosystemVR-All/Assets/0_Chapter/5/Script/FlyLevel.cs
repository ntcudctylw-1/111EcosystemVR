using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class FlyLevel : MonoBehaviour
{
    public int Level = 0;
    
    public CharacterController character;
    public Charactor_Physics physics;
    public string[] Hip;
    public Text HipText;
    public Levels levels;
    public VR_Gesture gesture;


    private void Start()
    {
        character = GetComponent<Mode_Switch>().GetCharacterController();
        levels.L2.Brids.SetActive(false);
        levels.L2.Count.gameObject.SetActive(false);
        GameobjectAllSetActive(levels.L2.Plane, false);
        GameobjectAllSetActive(levels.L2.Barrier, false);
        ComponyBirds[] Tr_temp = levels.L2.Brids.GetComponentsInChildren<ComponyBirds>();
        GameObject[] temp = new GameObject[Tr_temp.Length];
        for (int i = 0; i < Tr_temp.Length; i++) temp[i] = Tr_temp[i].gameObject;
        levels.L2.BridsObject = temp;
        


    }
    private void Update()
    {
        if(Level < 1) levels.L1.colliderMaterial.color = levels.L1.Color_Out;
        if (Level == 1 && levels.L1.InTheRange) levels.L1.colliderMaterial.color = levels.L1.Color_In;
        if (Level == 1 && !levels.L1.InTheRange) levels.L1.colliderMaterial.color = levels.L1.Color_Out;
        if (Level > 1) levels.L1.colliderMaterial.color = levels.L1.Color_In;

        HipText.text = Hip[Level];

        if(Level == 2)
        {
            //Debug.Log(levels.L2.Brids.transform.localRotation);
            //Vector3 Camera_pos = GetComponent<Mode_Switch>().OnlyVR[2].transform.localPosition;
            Quaternion Camera_qua = new Quaternion(0, 0, 0, 0);//GetComponent<Mode_Switch>().OnlyVR[2].transform.localRotation;
            levels.L2.Brids.transform.localRotation = Quaternion.Euler(0,0, - gesture.Slope);
            GameobjectLocalRotate(levels.L2.BridsObject, Quaternion.Euler(0, 0, gesture.Slope / 2));
            //levels.L2.Brids.transform.localPosition = new Vector3(Camera_pos.x, 0, Camera_pos.z);
            if (levels.L2.End && character.isGrounded) PassLevel(2);
        }
    }


    public void TriggerEnter(int id, Collider collision)
    {
        if (id == 1 && Level == 1)
        {
            levels.L1.InTheRange = true;
            Debug.Log("SetColor(In)");
            levels.L1.Timer = StartCoroutine(CountTo(2,Level));
        }
        
        if(id == 4 && Level == 3)
        {
            Debug.Log("¸¨²Ä");
        }
    }

    public void TriggerExit(int id, Collider collision)
    {
        
        if (id == 1)
        {
            StopCoroutine(levels.L1.Timer);
            Debug.Log("SetColor(Out)");
            levels.L1.InTheRange = false;
            
        }
        if (id == 4)
        {

        }
    }
    public void TriggerStay(int id, Collider collision)
    {
        character.transform.Rotate(new Vector3(0, levels.L2.Brids.transform.up.x, 0));
        if (id == 2 && Level == 2) physics._horizionVelocity += (new Vector3(0,0, levels.L2.WindForce * Time.deltaTime) + levels.L2.Brids.transform.up*Time.deltaTime);
        if (id == 3 && Level == 2)
        {
            levels.L2.Setup = false;
            L2Reset();
        }
        if (id == 4 && Level == 2)
        {

        }

    }




    public void PassLevel(int levelID) 
    {
        
        if (levelID == 0) levels.L0.Pass = true;
        if (levelID == 1)
        {
            StopCoroutine(levels.L1.Timer);
            levels.L1.Pass = true;
            levels.L2.Setup = false;
            L2Reset();
        }
        if (levelID == 2) levels.L2.Pass = true;
        LevelCheck();
    }

    void LevelCheck()
    {
        if (levels.L0.Pass) Level = 1;
        if (levels.L1.Pass) Level = 2;
        if (levels.L2.Pass) Level = 3;
    }

    void L2Reset()
    {
        if (!levels.L2.Setup)
        {
            StopAllCoroutines();
            levels.L1.collider.gameObject.SetActive(false);
            GameobjectAllSetActive(levels.L2.Barrier, true);
            physics._verticalVelocity = 0;
            levels.L2.Setup = true;
            Level = 2;
            character.enabled = false;
            character.gameObject.transform.position = levels.L2.StartPosition.transform.position;
            character.enabled = true;
            physics.Gravity = -15f;
            levels.L2.flap.IsEnable = false;
            levels.L2.Brids.SetActive(true);
            levels.L2.WindForce = 0;
            StartCoroutine(CountTo(0,Level));
            levels.L2.Count.gameObject.SetActive(true);
            levels.L2.Count.text = "";
            levels.L2.End = false;


            GameobjectAllSetActive(levels.L2.Plane, true);

        }
        
    }

    [System.Serializable]
    public class Levels
    {
        public L0_Arg L0;
        public L1_Arg L1;
        public L2_Arg L2;

        [System.Serializable]
        public class L0_Arg
        {
            public bool Pass = false;
        }
        [System.Serializable]
        public class L1_Arg
        {
            public bool Pass = false;
            public SphereCollider collider;
            public Material colliderMaterial;
            public bool InTheRange;
            public Coroutine Timer;

            public Color Color_In;
            public Color Color_Out;
        }
        [System.Serializable]
        public class L2_Arg
        {
            public bool Pass = false;
            public bool Setup = false;
            public bool StartFly = false;
            public GameObject StartPosition;
            public GameObject EndPosition;
            public Flap flap;
            public GameObject Brids;
            public GameObject[] BridsObject;
            public Text Count;
            public float WindForce;
            public GameObject[] Plane;
            public GameObject[] Barrier;
            public float FlapSpeed;
            public int FlyTime = 40;
            public bool End = false;

        }

        public class L3_Arg
        {
            public bool Pass = false;
        }
    }

    public IEnumerator CountTo(int sec, float nowlevel)
    {
        for (int i = sec-1; i >= 0 ; i--)
        {
            Debug.Log("Wait" + i.ToString());
            if (!levels.L1.InTheRange && levels.L1.Timer != null)
            {
                Debug.Log("Stop");
                StopCoroutine(levels.L1.Timer);
            }
            if (nowlevel == 2.1f)
            {
                levels.L2.Count.text = i.ToString();
            }
            yield return new WaitForSeconds(1);
            
        }
        Debug.Log("End Count");
        if (levels.L1.InTheRange && nowlevel == 1)
        {
            PassLevel(1);
            StopCoroutine(levels.L1.Timer);
        }
        if (nowlevel == 2 )
        {

            levels.L2.Count.gameObject.SetActive(false);
            physics.Gravity = -15;
            levels.L2.flap.IsEnable = true;
            levels.L2.WindForce = 50;
            
            GameobjectAllAnimatorSetFloat(levels.L2.BridsObject, 2.4f);
            yield return new WaitForSeconds(2);
            GameobjectAllAnimatorSetFloat(levels.L2.BridsObject, 1f);
            StartCoroutine(CountTo(levels.L2.FlyTime,2.1f));
        }
        if(nowlevel == 2.1f)
        {
            character.enabled = false;
            character.gameObject.transform.position = levels.L2.EndPosition.transform.position;
            physics._horizionVelocity = new Vector3(0,5,0);
            character.enabled = true;
            levels.L2.End = true;
        }
        
    }

    void GameobjectAllSetActive(GameObject[] objs,bool active)
    {
        foreach(GameObject obj in objs)
        {
            obj.SetActive(active);
        }
    }
    void GameobjectLocalRotate(GameObject[] objs,Quaternion quaternion)
    {
        foreach(GameObject obj in objs)
        {
            obj.transform.localRotation = quaternion;
        }
    }
    void GameobjectAllAnimatorSetFloat(GameObject[] objs,float value)
    {
        foreach(GameObject obj in objs)
        {
            obj.GetComponent<Animator>().SetFloat("speed", value);
        }
    }



}
