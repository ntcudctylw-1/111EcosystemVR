using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class mapController : MonoBehaviour
{
    [Serializable]
    public class posistion
    {
        public Vector3 world_Posision;
        public Vector3 ImagePosision;
    }

    private Image img;


    public posistion start, end;
    public float multiplier;

    private void Start()
    {
        img = GetComponent<Image>();
        float world = (end.world_Posision.z - start.world_Posision.z);
        float image = (end.ImagePosision.y - start.ImagePosision.y);

        multiplier = image / world;

    }

    private void Update()
    {
        img.rectTransform.localPosition = new Vector3(17.7f, start.ImagePosision.y + ( transform.position * multiplier).z,0) ;
    }
}
