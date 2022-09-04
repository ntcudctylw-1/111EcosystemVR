using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Steel_chicken_animate;
    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(1);
        GameObject a =  Instantiate(Steel_chicken_animate, this.transform).gameObject;
        a.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(a);
        
    }
}
