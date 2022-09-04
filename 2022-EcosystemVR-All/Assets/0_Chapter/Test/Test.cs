using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    IEnumerator Go()
    {
        while (true)
        {
            this.transform.Rotate(new Vector3(0f, 10f, 0f));
            yield return new WaitForSeconds(0.1f);
        }
        

    }

    public bool Run;
    public bool Trigger;
    public bool Trigger2;

    private void Update()
    {
        if (Trigger && !Run)
        {
            Run = true;
            StartCoroutine(Go());
            
        }

        if (Trigger2)
        {
            Run = false;
            StopAllCoroutines();
        }
    }


}
