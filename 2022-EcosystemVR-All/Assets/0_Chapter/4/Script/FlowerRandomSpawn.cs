using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerRandomSpawn : MonoBehaviour
{
    public List<GameObject> grids;
    WebPhp web;
    [System.Serializable]
    public class Flower
    {
        public GameObject flower;
        public List<GameObject> spawned;
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
    public void Spawn(int iid = -1)
    {
        int flowerNum;
        if (iid == -1)
            flowerNum = Random.Range(0, flowers.Length);
        else
            flowerNum = iid;
        if (flowers[flowerNum].spawned.Count == 0)
        {
            print("new " + iid.ToString());
            int gridNum = Random.Range(0, grids.Count);
            int id = int.Parse(grids[gridNum].name);
            Destroy(grids[id].transform.GetChild(0).gameObject);
            Instantiate(flowers[flowerNum].flower, grids[id].transform);
            flowers[flowerNum].spawned.Add(grids[id]);
            level.flowerCount++;
            
            print("First = " + id.ToString());
            grids.Remove(grids[id]);
            //return 0;
        }
        else
        {
            //print("follow");
            GameObject gridtarget = flowers[flowerNum].spawned[Random.Range(0, flowers[flowerNum].spawned.Count)];
            int id = int.Parse(gridtarget.name);
            int[] index = new int[] { 1, 1, 1, 1 };
            int col = id % 5;
            int row = int.Parse(gridtarget.transform.parent.name);
            if (col == 1) index[0] = 0; //上
            if (col == 0) index[1] = 0; //下
            if (row == 1) index[2] = 0; //右
            if (row == 5) index[3] = 0; //左
            int side;
            do
                side = Random.Range(0, 4);
            while (index[side] == 0);

            if (side == 0) id -= 1;
            if (side == 1) id += 1;
            if (side == 2) id -= 5;
            if (side == 3) id += 5;

            if (!grids.Contains(GameObject.Find(id.ToString())))
            {
                Spawn();
            }

            Destroy(GameObject.Find(id.ToString()).transform.GetChild(0).gameObject);
            level.flowerCount++;
            Instantiate(flowers[flowerNum].flower, GameObject.Find(id.ToString()).transform);
            flowers[flowerNum].spawned.Add(GameObject.Find(id.ToString()));
            grids.Remove(GameObject.Find(id.ToString()));
            /*
            //print(gridNum);
            int id = int.Parse(grids[gridNum].name);
            string col = grids[flowers[flowerNum].spawned[id]].gameObject.name;
            string row = grids[flowers[flowerNum].spawned[id]].transform.parent.gameObject.name;

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
            int id2 = flowers[flowerNum].spawned[id];
            if (side == 1) id2 += 1;
            if (side == 0) id2 -= 1;
            if (side == 3) id2 += 5;
            if (side == 2) id2 -= 5;
            //
            //foreach (var item in flowers)
            //{
             //   if (item.spawned.Contains(id2)) //return null;
            //}

            //print(string.Format("{0}-{1}-{2}-{3}-{4}-{5}", flowerNum,col, row, index[side], side, id));

            Destroy(grids[id2].transform.GetChild(0).gameObject);
            level.flowerCount++;
            Instantiate(flowers[flowerNum].flower, grids[id2].transform);
            flowers[flowerNum].spawned.Add(id2);
            grids.Remove(grids[id2]);
            */
        }


        if (level.flowerCount == 20) Gameover();
        //return 0;
    }

    private void Awake()
    {
        web = FindObjectOfType<WebPhp>();
        ResetFlower();

        StartCoroutine(GameStart());
        nextActionTime = level.timeInvoke;
    }

    void Update()
    {
        if (flowers[0].spawned.Count == 0)
        {
            for (int i = 0; i < level.numberPerSpawnCycle; i++) Spawn(0);
        }
        if (flowers[1].spawned.Count == 0)
        {
            for (int i = 0; i < level.numberPerSpawnCycle; i++) Spawn(1);
        }
        /*
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + level.timePerRound;
            for (int i = 0; i < level.numberPerSpawnCycle; i++)Spawn();
        }
        */
    }

    IEnumerator GameStart()
    {

        foreach (var item in grids)
        {
            if(item.transform.childCount > 0)
            {
                Destroy(item.transform.GetChild(0));
            }
            Instantiate(grass, item.transform);
            yield return new WaitForSeconds(0.06f);
        }
        level.flowerCount = 0; 
    }

    void Gameover()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ch4");
    }

    public void RemoveFlower(GameObject obj)
    {
        
        if(obj.transform.childCount > 0)
        {
            GameObject child = obj.transform.GetChild(0).gameObject;
            if (child.tag == "flower")
            {
                if (child.name.Contains("flowerA"))
                {
                    // print("大花咸豐草");
                    
                    StartCoroutine(web.php(GlobalSet.SID, "11", "45", WebPhp.php_method.Action));
                }

                if (child.name.Contains("flowerB"))
                {
                    //  print("小花蔓澤蘭");
                    StartCoroutine(web.php(GlobalSet.SID, "11", "47", WebPhp.php_method.Action));
                }


                Destroy(child);
                Instantiate(grass, obj.transform);
                foreach (var item in flowers)
                {
                    if (item.spawned.Contains(obj))
                    {
                        level.flowerCount--;
                        //item.spawned.Remove(System.Array.IndexOf(grids, obj));
                        item.spawned.Remove(obj);
                        grids.Add(obj);
                    }
                }
            }
        }
        
        
        
    }

    public void ResetFlower()
    {
        grids = new List<GameObject>();
        flowers[0].spawned = new List<GameObject>();
        flowers[1].spawned = new List<GameObject>();
        foreach (var item in GameObject.FindGameObjectsWithTag("grid"))
        {
            grids.Add(item);
        }
    }
}
