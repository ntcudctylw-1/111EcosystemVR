using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ch6_1st : MonoBehaviour
{
    public GameObject AxisObj,Camera,Cat,SpawnPoint,Animate, SpawnPoint2,AnimateCanvas;
    private Vector3 MoveDirection;
    public CharacterController CharacterController;
    float  a = 0.02f, v_max = 1 ,gravity = 200f;
    float Speed = 3;
    public static float Moving;
    public Text UI;
    public int Health = 3, Food = 10;

    private void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        
        AxisObj.transform.localPosition = new Vector3(Camera.transform.forward.x, 0, Camera.transform.forward.z).normalized;

        if(Moving < v_max && HandAccelator.walk==1)
        {
            Moving = 1;
        }
        else
        {
            Moving -= a;
        }
        if (Moving < 0.01f) Moving = 0;
        if (Moving > 0.99f) Moving = 1;

        MoveDirection = Vector3.zero;
        if (CharacterController.isGrounded)
        {
            MoveDirection = new Vector3(AxisObj.transform.localPosition.x, 0, AxisObj.transform.localPosition.z);
            MoveDirection = transform.TransformDirection(MoveDirection);
            MoveDirection *= Speed * Moving;
            //Debug.Log(MoveDirection);
        }
        MoveDirection.y -= gravity * Time.deltaTime;
        CharacterController.Move(MoveDirection * Time.deltaTime);

        Transform newtransform = AxisObj.transform;
        newtransform.position = new Vector3(newtransform.position.x, Cat.transform.position.y, newtransform.position.z);

        
        Cat.transform.LookAt(newtransform);

    }

    public void ReSpawn()
    {
        CharacterController.enabled = false;
        
        this.transform.position = SpawnPoint.transform.position;
        CharacterController.enabled = true;
        Health -= 1;
        pass_checker();
        UI_Update();
    }

    void Get_a_lemon()
    {
        Food -= 1;
        pass_checker();
        UI_Update();
    }
    IEnumerator Get_Chicken()
    {
        Food -= 3;
        CharacterController.enabled = false;

        
        
        StartCoroutine(Animate.GetComponent<Steel>().spawn()) ;
        child_Switch(false);
        
        this.transform.position = SpawnPoint2.transform.position;
        AnimateCanvas.SetActive(true);
        
        
        yield return new WaitForSeconds(4);
        child_Switch(true);
        AnimateCanvas.SetActive(false);
        pass_checker();
        UI_Update();
        CharacterController.enabled = true;
    }

    void child_Switch(bool status)
    {
       
        for(int i = 0; i < this.transform.childCount; i++)
        {
            if(this.transform.GetChild(i).name != "XR Origin")
            this.transform.GetChild(i).gameObject.SetActive(status);
        }

        
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {

        if (collision.transform.tag == "Lemon") 
        {
            Get_a_lemon();
            collision.gameObject.SetActive(false);
        }
        if (collision.transform.tag == "Chicken")
        {
            StartCoroutine( Get_Chicken());
            collision.gameObject.SetActive(false);
        }
        
        

    }

    void UI_Update()
    {

        UI.text = string.Format("¥Í©R¡G{0}		°§¾j¡G{1}", Health, Food);

    }

    void pass_checker()
    {
        if(Health == 0)
        {

            GameObject.Find("Start").GetComponent<Loading>().unload();
            GameObject.Find("XR Origin").GetComponent<Goto>().To_Menu();
        }
    }


}
