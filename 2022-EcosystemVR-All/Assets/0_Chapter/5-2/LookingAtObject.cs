using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtObject : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.LookAt(target);
    }

    public void ResetTarget(GameObject a) => target = a.transform;
}
