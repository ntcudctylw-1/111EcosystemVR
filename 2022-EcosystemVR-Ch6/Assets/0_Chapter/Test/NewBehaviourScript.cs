using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Lion;

    private void Start()
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        Vector3 target = new Vector3(0, 0, 3f);
        while (Lion.transform.localPosition != target)
        {
            Lion.transform.localPosition = Vector3.Lerp(Lion.transform.localPosition, target, 3f * Time.deltaTime);
            yield return null;
        }
        
    }
}
