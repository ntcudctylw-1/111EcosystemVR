using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerStep : MonoBehaviour
{
    [Range(0, 5)]
    public int step=0;
    public int childCount = 0;
    private int pre_step = 0;

    private void Start()
    {
        float a = Random.RandomRange(3f, 4.5f);
        this.transform.localScale = new Vector3(a, a, a);
        childCount = transform.childCount;
        check();
    }

    private void Update()
    {
        if (pre_step != step)
        {
            check();
        }
    }

    void check()
    {
        pre_step = step;
        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(step).gameObject.SetActive(true);
    }

}
