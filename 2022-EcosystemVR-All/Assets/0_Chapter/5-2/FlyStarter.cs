using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyStarter : MonoBehaviour
{
    public bool startFlying = false;

    [SerializeReference]
    int startFlapTimes = 3;
    [SerializeReference]
    int FlapTimes = 0;

    [SerializeReference]
    FlyChecker checker;

    private void Update()
    {
        if (checker.flying) FlapTimes++;
        if (!startFlying && FlapTimes >= startFlapTimes)
        {
            startFlying = true;
            //GetComponent<MotionTime>().Play();
        }
    }
}
