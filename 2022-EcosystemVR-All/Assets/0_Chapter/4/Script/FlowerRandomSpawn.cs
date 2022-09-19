using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerRandomSpawn : MonoBehaviour
{
    public GameObject[] grids;
    [System.Serializable]
    public class Flower
    {
        public GameObject flower;
        public List<int> spawned;
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
    public int Spawn()
    {
        int flowerNum = Random.Range(0, flowers.Length);
        if (flowers[flowerNum].spawned.Count == 0)
        {
            //print("new");
            int gridNum = Random.Range(0, grids.Length);
            
            Destroy(grids[gridNum].transform.GetChild(0).gameObject);
            Instantiate(flowers[flowerNum].flower, grids[gridNum].transform);
            flowers[flowerNum].spawned.Add(gridNum);
            level.flowerCount++;
            print("First = " + gridNum.ToString());
            return 0;
        }
        else
        {
            //print("follow");
            int gridNum = Random.Range(0, flowers[flowerNum].spawned.Count);
            //print(gridNum);
            string col = grids[flowers[flowerNum].spawned[gridNum]].gameObject.name;
            string row = grids[flowers[flowerNum].spawned[gridNum]].transform.parent.gameObject.name;
           
            int[] index = new int[] {1,1,1,1};//¤W¤U¥ª¥k
            if (col == "1") index[0] = 0;
            if (col == "5") index[1] = 0;
            if (row == "1") index[2] = 0;
            if (row == "5") index[3] = 0;
            int side;
            do
                side = Random.Range(0, 4);
            while (index[side] == 0);
            //print(col + "-" + row +"   side =" + side.ToString());
            int id = flowers[flowerNum].spawned[gridNum];
            if (side == 1) id += 1;
            if (side == 0) id -= 1;
            if (side == 3) id += 5;
            if (side == 2) id -= 5;

            foreach (var item in flowers)
            {
                if (item.spawned.Contains(id)) return 0;
            }

            //print(string.Format("{0}-{1}-{2}-{3}-{4}-{5}", flowerNum,col, row, index[side], side, id));
            
            Destroy(grids[id].transform.GetChild(0).gameObject);
            level.flowerCount++;
            Instantiate(flowers[flowerNum].flower, grids[id].transform);
            flowers[flowerNum].spawned.Add(id);

        }


        if (level.flowerCount == grids.Length) Gameover();
        return 0;
    }

    private void Awake()
    {
        grids = GameObject.FindGameObjectsWithTag("grid");

        StartCoroutine(GameStart());
        nextActionTime = level.timeInvoke;
    }

    void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime += level.timePerRound;
            for (int i = 0; i < level.numberPerSpawnCycle; i++)Spawn();
        }
    }

    IEnumerator GameStart()
    {
        foreach (var item in grids)
        {
            Instantiate(grass, item.transform);
            yield return new WaitForSeconds(0.06f);
        }
        level.flowerCount = 0; 
    }

    void Gameover()
    {

    }

    public void RemoveFlower(GameObject obj)
    {
        
        if(obj.transform.childCount > 0)
        {
            GameObject child = obj.transform.GetChild(0).gameObject;
            if (child.tag == "flower")
            {
                Destroy(child);
                Instantiate(grass, obj.transform);
                foreach (var item in flowers)
                {
                    if (item.spawned.Contains(System.Array.IndexOf(grids, obj)))
                    {
                        item.spawned.Remove(System.Array.IndexOf(grids, obj));
                    }
                }
            }
        }
        
        
        
    }
}
