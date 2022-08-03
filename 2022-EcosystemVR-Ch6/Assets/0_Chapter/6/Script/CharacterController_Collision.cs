using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Serialization;

public class CharacterController_Collision : MonoBehaviour
{

    

    [System.Serializable]
    public class CollisionEvent : UnityEvent { }
    
    
    protected CharacterController_Collision()
    { }

    public enum Filter
    {
        Tag,
        GameObject,
        Name
    } 
    public enum HitAction
    {
        None,
        Disappear
    }
    

    [System.Serializable]
    public class InteractableObject
    {
        public GameObject CollidObject;
        public Filter WithSame;
        public HitAction AfterCollid;
        [FormerlySerializedAs("onCollision")]
        [SerializeField]
        private CollisionEvent m_Collision = new CollisionEvent();

        public CollisionEvent onCollision
        {
            get { return m_Collision; }
            set { m_Collision = value; }
        }

        public void Doit()
        {
            m_Collision.Invoke();
        }

    }


    public InteractableObject[] interactable;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.gameObject.name);
        //Debug.Log(hit.gameObject.name);
        foreach (InteractableObject @object in interactable)
        {
            if(@object.WithSame == Filter.Tag)
            {
                if(hit.gameObject.tag == @object.CollidObject.tag)
                {
                    @object.Doit();
                    if (@object.AfterCollid == HitAction.Disappear) disappear(hit.gameObject);
                }
            }else if(@object.WithSame == Filter.GameObject)
            {
                if(hit.gameObject == @object.CollidObject)
                {
                    @object.Doit();
                    if (@object.AfterCollid == HitAction.Disappear) disappear(hit.gameObject);
                }
            }else if(@object.WithSame == Filter.Name)
            {
                if(hit.gameObject.name == @object.CollidObject.name)
                {
                    @object.Doit();
                    if (@object.AfterCollid == HitAction.Disappear) disappear(hit.gameObject);
                }
            }
        }
    }

    void disappear(GameObject obj)
    {
        obj.SetActive(false);
    }



    private void Update()
    {
        //Debug.Log(character2.detectCollisions);
    }
}
