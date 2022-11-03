using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch4_Grid : MonoBehaviour
{
    [SerializeReference]
    public GameObject Child;
    [SerializeReference]
    public List<Ch4_Grid> grid_Near;
    [SerializeReference]
    public BoxCollider boxCollider;
    private FlowerSpawner flowerSpawner;
    public int flowerID = -1;

    public void removeChild() => Destroy(Child);

    public void enableCollider(bool a) => boxCollider.enabled = a;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        flowerSpawner = FindObjectOfType<FlowerSpawner>();
        Invoke("SetNeighboor", 2f);
    }

    void SetNeighboor()
    {
        int self = int.Parse(name);
        if (self - 5 >= 0) grid_Near.Add(flowerSpawner.getGridByID(self - 5));
        if (self + 5 < 25) grid_Near.Add(flowerSpawner.getGridByID(self + 5 ));
        if ((self+1) % 5 > (self ) % 5 && self + 1 < 25) grid_Near.Add(flowerSpawner.getGridByID(self + 1));
        if ((self-1) % 5 < (self ) % 5 && self - 1 >= 0) grid_Near.Add(flowerSpawner.getGridByID(self - 1));
    }

    public void RemoveFlower()
    {
        flowerID = -1;
        flowerSpawner.RemoveFlower(Child, int.Parse(name));
    }


}

