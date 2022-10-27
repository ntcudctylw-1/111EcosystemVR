using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTranfer : MonoBehaviour
{

    public GameObject game;

    public void transfer(GameObject parent)
    {
        game.transform.SetParent(parent.transform);
    }
}
