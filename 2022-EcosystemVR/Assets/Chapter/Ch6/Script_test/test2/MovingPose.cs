using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPose : MonoBehaviour
{
    
    public static Vector3 Base_Pos_L, Base_Pos_R; //移動中心位置(左/右)
    public int PoseKeepTime = 5; //設定中心的持續時間
    public float PoseKeepOffset = 10f; //設定中心的變動範圍
    public int PassPerSec = 10;
    public Vector3[] left,right;
    private bool SetPos = false; 
    public static Vector2 L_key, R_key;
    public static int side_L = 0, side_R = 0;
    public static float Angle_L, Angle_R;

    void Start()
    {
        

        
    }

    float FindAngle(Vector3 base_pos, Vector3 cont_pos)
    {
        float m_Angle;
        Vector2 pos1 = new Vector2(base_pos.y, base_pos.z);
        Vector2 pos2 = new Vector2(cont_pos.y, cont_pos.z);
        m_Angle = Vector2.Angle(pos1, pos2);
        return m_Angle;
    }


    IEnumerator SetBasePos()
    {
        //Debug.Log("StartPos");
        float pps = 1f / PassPerSec;
        WaitForSeconds wait = new WaitForSeconds(pps);

        left = new Vector3[PassPerSec * PoseKeepTime];
        right= new Vector3[PassPerSec * PoseKeepTime];
        for (int i = 0; i < PassPerSec * PoseKeepTime; i++)
        {
            left[i] = GlobalSet.LeftHand.Position;
            right[i] = GlobalSet.RightHand.Position;
            yield return wait;
        }

        Vector3 vectorsum = Vector3.zero;
        foreach(Vector3 i in left)vectorsum += i;
        Base_Pos_L = vectorsum / (PassPerSec * PoseKeepTime);


        vectorsum = Vector3.zero;
        foreach (Vector3 i in right) vectorsum += i;
        Base_Pos_R = vectorsum / (PassPerSec * PoseKeepTime);

        SetPos = true;
    }

    float timer;
    Vector2 temp_L = Vector2.zero;
    Vector2 temp_R = Vector2.zero;
    int stat = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (GlobalSet.LeftHand.ButtonA) StartCoroutine( SetBasePos());
        if (SetPos)
        {
            Vector3 temp = GlobalSet.LeftHand.Position - Base_Pos_L;
            /*            L_key = new Vector2(temp.y >= 0 ? 1 : -1, temp.z >= 0 ? 1 : -1) ;
                        if ((temp_L == new Vector2(1, 1) && L_key == new Vector2(-1, 1)) ||
                            (temp_L == new Vector2(-1, 1) && L_key == new Vector2(-1, -1)) ||
                            (temp_L == new Vector2(-1, -1) && L_key == new Vector2(1, -1)) ||
                            (temp_L == new Vector2(1, -1) && L_key == new Vector2(1, 1))) side_L = 1;
                        else if((temp_L == new Vector2(1, 1) && L_key == new Vector2(1, -1)) ||
                            (temp_L == new Vector2(1, -1) && L_key == new Vector2(-1, -1)) ||
                            (temp_L == new Vector2(-1, -1) && L_key == new Vector2(-1, 1)) ||
                            (temp_L == new Vector2(-1, 1) && L_key == new Vector2(1, 1))) side_L = -1;
                        temp_L = L_key;
            */
            temp = GlobalSet.RightHand.Position - Base_Pos_R;
            R_key = new Vector2(temp.y >= 0 ? 1 : -1, temp.z >= 0 ? 1 : -1);
            if ((temp_R == new Vector2(1, 1) && R_key == new Vector2(-1, 1)) ||
                (temp_R == new Vector2(-1, 1) && R_key == new Vector2(-1, -1)) ||
                (temp_R == new Vector2(-1, -1) && R_key == new Vector2(1, -1)) ||
                (temp_R == new Vector2(1, -1) && R_key == new Vector2(1, 1))) side_R = 1;
            else if ((temp_R == new Vector2(1, 1) && R_key == new Vector2(1, -1)) ||
                (temp_R == new Vector2(1, -1) && R_key == new Vector2(-1, -1)) ||
                (temp_R == new Vector2(-1, -1) && R_key == new Vector2(-1, 1)) ||
                (temp_R == new Vector2(-1, 1) && R_key == new Vector2(1, 1))) side_R = -1;
            else side_R = 0;

            temp_R = R_key;
        }

        Angle_L = FindAngle(Base_Pos_L, GlobalSet.LeftHand.Position);
        Angle_R = FindAngle(Base_Pos_R, GlobalSet.RightHand.Position);

  


       // LookingObj.transform.Rotate(new Vector3(0,GlobalSet.HeadSet.Rotation.y,0));
    }



    Quaternion ResetQuaternion(Quaternion quaternion,bool x , bool y , bool z , bool w)
    {
        Quaternion newq;
        newq = quaternion;
        if (!x) newq.x = 0;
        else if (!y) newq.y = 0;
        else if (!z) newq.z = 0;
        else if (!w) newq.w = 0;
        return newq;
    }

}
