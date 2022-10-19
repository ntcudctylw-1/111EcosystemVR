using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerRandomSpawn1 : MonoBehaviour
{
    public List<GameObject> grids;
    WebPhp web;
    [System.Serializable]
    public class Flower
    {
        public GameObject flower;
        public List<GameObject> spawned;
    }

    [System.Serializable]
    public class SpawnedFlower
    {
        public GameObject @object;
        public GameObject chest_left;
        public GameObject chest_right;
        public GameObject chest_up;
        public GameObject chest_down;
    }

    public Flower[] flowers;
    public GameObject grass;
    [System.Serializable]
    public class Level
    {
        public int numberPerSpawnCycle = 1;
        public float timePerRound = 3;
        public float timeInvoke = 3;
        public int flowerCount = 0;
    }

    public Level level;
    private float nextActionTime = 0.0f;


    public void Spawn(int iid = -1 , AFlower gamePick = null)
    {
        Grid grid = gamePick.transform.parent.gameObject.GetComponent<Grid>();
        List<GameObject> objects = new List<GameObject>();
        if (grid.grids.down.used != true && grid.grids.down.gameObject != null) objects.Add(grid.grids.down.gameObject);
        if (grid.grids.up.used != true && grid.grids.up.gameObject != null) objects.Add(grid.grids.up.gameObject);
        if (grid.grids.left.used != true && grid.grids.left.gameObject != null) objects.Add(grid.grids.left.gameObject);
        if (grid.grids.right.used != true && grid.grids.right.gameObject != null) objects.Add(grid.grids.right.gameObject);

        if(objects.Count != 0)
        {
            //print(int.Parse(objects[Random.Range(0, objects.Count)].name));
            int solt = int.Parse(objects[Random.Range(0, objects.Count)].name) - 1;
            Destroy(grids[solt].transform.GetChild(0).gameObject);
            Instantiate(flowers[iid].flower, grids[solt].transform);
            if (grid.grids.down.gameObject != null)
                grid.grids.down.gameObject.GetComponent<Grid>().grids.up.used = true;
            if (grid.grids.up.gameObject != null)
                grid.grids.up.gameObject.GetComponent<Grid>().grids.down.used = true;
            if (grid.grids.right.gameObject != null)
                grid.grids.right.gameObject.GetComponent<Grid>().grids.left.used = true;
            if (grid.grids.left.gameObject != null)
                grid.grids.left.gameObject.GetComponent<Grid>().grids.right.used = true;
            grid.GetComponent<BoxCollider>().enabled = true;
            flowers[iid].spawned.Add(grids[solt]);
        }
        else
        {
            FirstSpawn(iid);
        }
        
    }
    public void FirstSpawn(int iid = -1)
    {
        int solt = Random.Range(0, grids.Count);
        //print(solt);
        if (grids[solt].transform.GetChild(0).tag != "grass") FirstSpawn(iid);
        else
        {
            Destroy(grids[solt].transform.GetChild(0).gameObject);
            Instantiate(flowers[iid].flower, grids[solt].transform);
            int self = int.Parse(grids[solt].name);
            Grid grid = grids[solt].GetComponent<Grid>();
            if(grid.grids.down.gameObject != null)
                grid.grids.down.gameObject.GetComponent<Grid>().grids.up.used = true;
            if(grid.grids.up.gameObject != null)
                grid.grids.up.gameObject.GetComponent<Grid>().grids.down.used = true;
            if(grid.grids.right.gameObject != null)
                grid.grids.right.gameObject.GetComponent<Grid>().grids.left.used = true;
            if(grid.grids.left.gameObject != null)
                grid.grids.left.gameObject.GetComponent<Grid>().grids.right.used = true;
            flowers[iid].spawned.Add(grids[solt]);
            grid.GetComponent<BoxCollider>().enabled = true;
        }

        

    }



    
    public void RemoveFlower(GameObject game)
    {
        GameDirector.score += 100;
        if (game.transform.GetChild(0).name.Contains("flowerA"))
        {
            flowers[0].spawned.Remove(game);
        }
        else if (game.transform.GetChild(0).name.Contains("flowerB"))
        {
            flowers[1].spawned.Remove(game);
        }
        int solt = int.Parse(game.name) - 1;
        Grid grid = game.GetComponent<Grid>();
        if (grid.grids.down.gameObject != null)
            grid.grids.down.gameObject.GetComponent<Grid>().grids.up.used = false;
        if (grid.grids.up.gameObject != null)
            grid.grids.up.gameObject.GetComponent<Grid>().grids.down.used = false;
        if (grid.grids.right.gameObject != null)
            grid.grids.right.gameObject.GetComponent<Grid>().grids.left.used = false;
        if (grid.grids.left.gameObject != null)
            grid.grids.left.gameObject.GetComponent<Grid>().grids.right.used = false;

        game.GetComponent<BoxCollider>().enabled = false;
        Destroy(game.transform.GetChild(0).gameObject);
        Instantiate(grass, game.transform);

    }

    public void ResetFlower()
    {
        grids = new List<GameObject>();
        flowers[0].spawned = new List<GameObject>();
        flowers[1].spawned = new List<GameObject>();
        foreach (var item in GameObject.FindGameObjectsWithTag("grid"))
        {
            grids.Add(item);
            item.GetComponent<BoxCollider>().enabled = false;
        }
        FirstSpawn(0);
        FirstSpawn(1);
    }

    private void Start()
    {
        print("HI");
        grids = new List<GameObject>();
        web = FindObjectOfType<WebPhp>();
        foreach (var item in GameObject.FindGameObjectsWithTag("grid"))
        {
            grids.Add(item);
            
        }foreach (var item in grids)
        {
            item.GetComponent<Grid>().setNear();

        }
        
        StartCoroutine(GrassGrow());
    }

    IEnumerator GrassGrow()
    {
        foreach (var item in grids)
        {
            if (item.transform.childCount > 0)
            {
                Destroy(item.transform.GetChild(0));
            }
            Instantiate(grass, item.transform);
            yield return new WaitForSeconds(0.06f);
        }
        level.flowerCount = 0;
    }

    


}

