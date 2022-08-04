using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Update : MonoBehaviour
{
    public Text UI_PC, UI_VR;

    public string[] State;
    private void Update()
    {
        UI_PC.text = State[GetComponent<Levels>().Level];
        UI_VR.text = State[GetComponent<Levels>().Level];
    }
}
