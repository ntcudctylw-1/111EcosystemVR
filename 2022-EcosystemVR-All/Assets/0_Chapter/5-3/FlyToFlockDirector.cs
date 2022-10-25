using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToFlockDirector : MonoBehaviour
{
    public bool go;

    [SerializeReference]
    private Transform Target;
    
    [SerializeReference]
    private Transform XrOrigin;
    
    [SerializeReference]
    private Transform XrCamera;

    [SerializeReference]
    private float step = 0.3f;

    [SerializeReference]
    private float OverHeight = 0.3f;



    private void Start()
    {

    }

    private void Update()
    {
        if (XrCamera.transform.localPosition.y > OverHeight) go = true;

        if (go)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothFly());
            go = false;
        }
    }

    IEnumerator SmoothFly()
    {
        for (int i = 0; i < 100; i++)
        {
            XrOrigin.transform.position = Vector3.Lerp(XrOrigin.position,
                                                       Target.position,
                                                       step);
            yield return null;
        }
    }
}
