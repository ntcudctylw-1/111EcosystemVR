using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viverse : MonoBehaviour
{
    public Button button;
    private void Awake() {
        button.onClick.AddListener(()=>{
            Application.OpenURL("viversebusiness://");
        }

        );
    }
}
