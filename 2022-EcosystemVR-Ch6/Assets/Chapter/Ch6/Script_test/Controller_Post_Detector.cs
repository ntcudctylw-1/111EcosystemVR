using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Post_Detector : MonoBehaviour
{
    public enum Side
    {
        Left,Right
    }
    public enum Button
    {
        A, B
    }


    public Side BaseOnController;
    public Button OnWitchButtonDownReset;
    GlobalSet.Hand BaseOnHand;
    bool initialization = false;
    Vector3 BasePosition;
    public float AngleRelateToBasePosition;
    private void Awake()
    {
       
        

    }

    private void Update()
    {
        //以哪隻手為基準
        if (BaseOnController == Side.Left)
            BaseOnHand = GlobalSet.LeftHand;
        else
            BaseOnHand = GlobalSet.RightHand;
        
        if (OnWitchButtonDownReset == Button.A) { 
            if (BaseOnHand.ButtonA)StartCoroutine( ResetBasePosition());

        }
        else { 
            if (BaseOnHand.ButtonB) StartCoroutine(ResetBasePosition());
        }


        if (!initialization)
        {
            //Debug.Log("請初始化");
        }


        AngleRelateToBasePosition = GetAngle(BasePosition, BaseOnHand.Position);
    }
    private IEnumerator ResetBasePosition()
    {
        initialization = true;
        int sample = 30;
        int keeptime = 3;
        //Debug.Log("初始化中");
        Vector3[] posdata = new Vector3[sample];
        for(int i = 0; i < sample; i++)
        {
            posdata[i] = BaseOnHand.Position;
            //Debug.Log(i);
            yield return new WaitForSeconds((float)keeptime / (float)sample);
        }
        Vector3 vectorsum = Vector3.zero;
        foreach (Vector3 i in posdata) vectorsum += i;
        BasePosition = vectorsum / (sample);
    }
    float GetAngle(Vector3 base_pos, Vector3 cont_pos)
    {
        float m_Angle;
        Vector2 pos1 = new Vector2(base_pos.y, base_pos.z);
        Vector2 pos2 = new Vector2(cont_pos.y, cont_pos.z);
        Vector2 diference = pos2 - pos1;
        float sign = (pos2.y < pos1.y) ? -1.0f : 1.0f;
        return (Vector2.Angle(Vector2.right, diference) * sign - 180) * -1;
  
        
    }

}
