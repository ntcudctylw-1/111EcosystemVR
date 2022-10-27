using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [System.Serializable]
    public class NearGrids
    {
        public Grids up;
        public Grids down;
        public Grids left;
        public Grids right;
    }

    [System.Serializable]
    public class Grids 
    {
        public GameObject gameObject;
        public bool used = false;
    }

    public NearGrids grids;
    void Start()
    {
   }

    public void setNear()
    {
        FlowerRandomSpawn1 flowerRandom = FindObjectOfType<FlowerRandomSpawn1>();
        int self = int.Parse(this.name);
        if (self - 5 > 0) grids.up.gameObject = flowerRandom.grids[self - 5 - 1];
        if (self + 5 < 25) grids.down.gameObject = flowerRandom.grids[self + 5 - 1];
        if ((self - 1) % 5 < (self - 1 + 1) % 5 && self + 1 <= 25) grids.right.gameObject = flowerRandom.grids[self + 1 - 1];
        if ((self - 1) % 5 > (self - 1 - 1) % 5 && self - 1 > 0) grids.left.gameObject = flowerRandom.grids[self - 1 - 1];

    }
}
