using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SickleCollision : MonoBehaviour
{
    public GameObject hitObj;
    public string hitGridName;
    public FlowerRandomSpawn randomSpawn;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "grid")
        {
            hitObj = other.gameObject;
            hitGridName = GridName(hitObj);
            randomSpawn.RemoveFlower(hitObj);
            hitObj = null;
            hitGridName = null;
        }
    }

    string GridName(GameObject game)
    {
        return string.Format("{0}-{1}", game.transform.parent.name.ToString(), game.name.ToString()); 
    }
}
