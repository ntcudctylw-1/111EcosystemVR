using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate_New : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Parent;
    public bool Is_Playing;
    public int Play_Second = 10;
    public bool Go_Play = false;
    public GameObject Canvas_PC, Canvas_VR,Cat;

    public void Play()
    {
        StartCoroutine(Go());
        IEnumerator Go()
        {
            StartCoroutine(GetComponent<Spwan_Player>().Respawn(1));
            Cat.SetActive(false);
            if (GlobalSet.playMode == GlobalSet.PlayMode.PC)
            {
                Canvas_PC.SetActive(true);

            }
            if (GlobalSet.playMode == GlobalSet.PlayMode.VR) 
            { 
                Canvas_VR.SetActive(true); 
            }
            Is_Playing = true;
            GameObject Temp = Instantiate(Prefab, Parent.transform);
            Temp.SetActive(true);
            yield return new WaitForSeconds(Play_Second);
            Is_Playing = false;
            Destroy(Temp);
            if (GlobalSet.playMode == GlobalSet.PlayMode.PC) 
            { 
                Canvas_PC.SetActive(false); 
            }
            if (GlobalSet.playMode == GlobalSet.PlayMode.VR) 
            {
                Canvas_VR.SetActive(false);
            }
            Cat.SetActive(true);
            Debug.Log("Spawn");
            
        }

    }

    private void Update()
    {
        if (Go_Play)
        {
            Play();
            Go_Play = false;
        }
    }


}
