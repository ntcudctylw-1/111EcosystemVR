using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch6_Demo_ : MonoBehaviour
{
    public HMDController controller;
    public List<string> list;
    public FlyCollider collider;
    public HMDEvents events;

    private void Update()
    {
        controller.displayTexts[0] = list[0];
        if (collider.inTheCollider)
        {
            events.EventTriggered(1);
        }
    }
}
