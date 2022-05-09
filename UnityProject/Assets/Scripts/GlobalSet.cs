using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSet : MonoBehaviour
{
    public string SID;//學號
    public long EntryTime, ExitTime; // 進入和離開學習單元的時間
    public string ServerIP = ""; //SQL ServerIP
    public bool NetworkMode; //true: 記錄在遠端  false: 記錄在本地
    public int[] Score;//各關卡分數



    void Portfolio(string TargetName/*目標對象*/)
    {
        //單元 
        //按鈕狀態
        //時間
    }

}
