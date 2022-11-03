using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFlower : MonoBehaviour
{
    public bool growUp = false;
    [SerializeField]
    private float growStage = 0;
    [SerializeField]
    private float growSpeed = 1;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private int id;



    private void Update()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if(growStage < 100)
        {
            growStage += Time.deltaTime * growSpeed;
            if (growStage > 100 && !growUp)
            {
                growUp = true;

                FindObjectOfType<FlowerRandomSpawn1>().Spawn(id,this);

            }
            animator.SetFloat("grow", growStage);
        }
        
    }
}
