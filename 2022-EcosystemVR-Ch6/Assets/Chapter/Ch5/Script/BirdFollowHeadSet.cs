using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollowHeadSet : MonoBehaviour
{
    
    public GameObject Bird;


    private void Start()
    {
        Debug.Log(GlobalSet.playMode);
        GlobalSet.playMode = GlobalSet.PlayMode.VR;
    }
    private void Update()
    {
        if(GlobalSet.playMode == GlobalSet.PlayMode.VR)
        Bird.transform.position = GlobalSet.HeadSet.Position;
    }
}
