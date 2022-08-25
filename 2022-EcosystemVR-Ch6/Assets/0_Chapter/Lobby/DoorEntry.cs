using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEntry : MonoBehaviour
{
    Coroutine coroutine;
    public void Selected()
    {
        if(coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(LocalRotate(90));
    }

    public void DeSelected()
    {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(LocalRotate(0));
    }

    public void Activated(string SceneName)
    {
        if (gameObject.activeSelf)
        {
            this.GetComponent<DoorEntry>().enabled = false;
            StopCoroutine(coroutine);
            coroutine = null;
            SceneManager.LoadScene(SceneName);
        }

    }

    IEnumerator LocalRotate(float angle)
    {
        while(transform.GetChild(0).transform.localRotation.y != angle)
        {
            transform.GetChild(0).transform.localRotation = Quaternion.Slerp(transform.GetChild(0).transform.localRotation, Quaternion.Euler(new Vector3(0, angle, 0)), 3f * Time.deltaTime);
            yield return null;
        }
        
    }
}
