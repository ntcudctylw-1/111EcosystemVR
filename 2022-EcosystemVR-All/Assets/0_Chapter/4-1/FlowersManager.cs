using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersManager : MonoBehaviour
{
    [SerializeReference]
    List<FlowerStep> flowers;
    [Range(0, 5)]
    public int step = 0;
    private int pre_step = 0;
    public float timer;
    bool spreaded = false;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            flowers.Add(transform.GetChild(i).GetComponent<FlowerStep>());
            transform.GetChild(i).GetComponent<FlowerStep>().step = step;
        }
    }

    private void Update()
    {
        if (pre_step != step)
        {
            pre_step = step;
            foreach (var item in flowers)
            {
                item.step = step;
            }
        }
        timer += Time.deltaTime;
        if (timer > 1f && step < transform.GetChild(0).GetComponent<FlowerStep>().childCount-1) 
        {
            timer = 0;
            step++;
        }


        if(step == transform.GetChild(0).GetComponent<FlowerStep>().childCount -1 && timer > 3f)
        {
            timer = 0;
            spreaded = true;
            Ch4_Grid grid = transform.parent.GetComponent<Ch4_Grid>();
            List<Ch4_Grid> spawnableGrid = new List<Ch4_Grid>();
            foreach (var item in grid.grid_Near)
            {
                if (item.flowerID != grid.flowerID) spawnableGrid.Add(item);
            }
            if (spawnableGrid.Count != 0)
            {
                int gridid = int.Parse(spawnableGrid[Random.Range(0, spawnableGrid.Count - 1)].name);
                FindObjectOfType<FlowerSpawner>().NewFlower(gridid, grid.flowerID);
            }
            else
            {
                this.enabled = false;
                //FindObjectOfType<FlowerSpawner>().RandomSpawn(grid.flowerID);
            }
            
        }
    }

}
