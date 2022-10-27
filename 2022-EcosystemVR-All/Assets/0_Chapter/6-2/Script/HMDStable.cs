using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMDStable : MonoBehaviour
{
    [SerializeReference]
    private GameObject follow;
    void Update()
    {
        Quaternion q = follow.transform.localRotation;
        this.transform.localRotation = new Quaternion(q.x, 0, 0, 0) ;
        this.transform.LookAt(follow.transform);
    }
}
