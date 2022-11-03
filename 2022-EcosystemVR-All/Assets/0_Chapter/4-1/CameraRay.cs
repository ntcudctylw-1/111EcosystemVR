using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Vector3 CameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));

            if (Physics.Raycast(CameraCenter, Camera.main.transform.forward, out hit, 5))
            {
                Transform objectHit = hit.transform;
                if (objectHit.tag == "grid")
                {
                    objectHit.GetComponent<Ch4_Grid>().RemoveFlower();
                    objectHit.GetComponent<BoxCollider>().enabled = false;
                    Score.AddScore();
                }
            }
            /*
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.DrawRay(ray.direction, hit.point, Color.yellow);
                //Debug.Log("1 " + objectHit.name);
                if (objectHit.tag == "grid")
                {
                    print(hit);
                }
            }*/
        }
    }
}
