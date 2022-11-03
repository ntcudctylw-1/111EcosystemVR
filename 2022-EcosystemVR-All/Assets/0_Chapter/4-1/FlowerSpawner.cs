using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlowerSpawner : MonoBehaviour
{
    [SerializeReference]
    private List<GameObject> flowers;
    [SerializeReference]
    private List<Ch4_Grid> grids;

    public int FlowerCount = 0;

    WebPhp web;


    public bool NewFlower(int gridID, int flowerID)
    {
        while (flowerID > flowers.Count) flowerID -= flowers.Count;
        if(grids[gridID].flowerID <= 0 )
        {
            Destroy(grids[gridID].Child);
            grids[gridID].Child = Instantiate(flowers[flowerID], grids[gridID].transform);
            grids[gridID].flowerID = flowerID;
            if (flowerID > 0)
            {
                FlowerCount++;
                grids[gridID].GetComponent<BoxCollider>().enabled = true;
            }
        }
        

        return true;
    }

    private void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("grid"))
        {
            grids.Add(item.GetComponent<Ch4_Grid>());
        }
        grids.Sort((x, y) => int.Parse(x.name).CompareTo(int.Parse(y.name)));
        web = FindObjectOfType<WebPhp>();


        //ResetSpawn();
    }

    public void ResetSpawn()
    {
        StartCoroutine(SpawnGress());
    }

    IEnumerator SpawnGress()
    {
        foreach (var item in grids)
        {
            item.boxCollider.enabled = false;
            NewFlower(int.Parse(item.name), 0);

            yield return 0.1f;
        }

    }

    public Ch4_Grid getGridByID(int gridid)
    {
        return grids[gridid];
    }

    public void RandomSpawn(int flowerid = -1,int gridid = -1)
    {
        if(flowerid == -1)
        flowerid = Random.Range(1, flowers.Count);
        if (gridid == -1)
        gridid = Random.Range(0, GetEmptyGrids().Count-1);
        //print(gridid);
        NewFlower(gridid, flowerid);
        
    }

    List<Ch4_Grid> GetEmptyGrids()
    {
        List<Ch4_Grid> ch4_Grids = new List<Ch4_Grid>();

        foreach (var item in grids)
            if (item.flowerID == 0) ch4_Grids.Add(item);
        return ch4_Grids;
    }

    public void InvoleStart(int sec) => Invoke("starEvents", sec);

    private void starEvents()
    {
        for(int i = 1; i < flowers.Count; i++)
        RandomSpawn(i);
    }

    private void Update()
    {
        if(FlowerCount == grids.Count)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        foreach (var item in grids)
        {
            Destroy(item.Child);
        }
        FindObjectOfType<HMDEvents>().EventTriggered(2);
        FindObjectOfType<GoToMenu>().InvokeLoadScene(5, 5);
    }
    public void WinGame()
    {
        foreach (var item in grids)
        {
            Destroy(item.Child);
        }
        FindObjectOfType<HMDEvents>().EventTriggered(1);
        FindObjectOfType<GoToMenu>().InvokeLoadScene(5,1);
    }



    public void RemoveFlower(GameObject target,int gridid)
    {
        if(target.transform.parent.GetComponent<Ch4_Grid>().flowerID == 1)//大花
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "47", WebPhp.php_method.Action));
        else
            StartCoroutine(web.php(GlobalSet.SID, GlobalSet.LID, "45", WebPhp.php_method.Action));
        Destroy(target);
        FlowerCount--;
        NewFlower(gridid, 0);
        CheckWin();
    }

    void CheckWin()
    {
        if(FlowerCount == 0)
        {
            WinGame();
        }
    }
}
