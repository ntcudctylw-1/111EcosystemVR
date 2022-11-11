using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQuailty : MonoBehaviour
{ 
    public void SetQuality(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
    }
}
