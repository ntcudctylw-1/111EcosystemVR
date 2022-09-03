using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public enum Dimension
{
    z,x,y
}
public enum Direction
{
    More,Less
}

[System.Serializable]
public class CheckPoint 
{

    public GameObject Object;
    public Dimension Dimension;
    public Direction Direction;
    public bool Pass;
    [System.Serializable]
    public class nPassEvent : UnityEvent { }
    protected CheckPoint()
    { }
    [SerializeField]
    private nPassEvent m_nPass = new nPassEvent();

    public nPassEvent OnPass
    {
        get { return m_nPass; }
        set { m_nPass = value; }
    }

    public void Doit()
    {
        m_nPass.Invoke();
    }
}

public class CheckPoints : MonoBehaviour
{

    CharacterController character;
    public CheckPoint[] points;

    private void Start()
    {
        character = GetComponent<Mode_Switch>().GetCharacterController();
    }

    private void Update()
    {
        Vector3 Pos = character.gameObject.transform.position;
        foreach (CheckPoint i in points)
        {
            if (!i.Pass) 
            { 
                Vector3 pointpos = i.Object.transform.position;
                if (i.Dimension == Dimension.z)
                {
                    if (Pos.z > pointpos.z && i.Direction == Direction.More) i.Pass = true;
                    else if(Pos.z < pointpos.z && i.Direction == Direction.Less) i.Pass = true;
                }
                else if (i.Dimension == Dimension.y)
                {
                    if (Pos.y > pointpos.y && i.Direction == Direction.More) i.Pass = true;
                    else if(Pos.y < pointpos.y && i.Direction == Direction.Less) i.Pass = true;
                }
                else if (i.Dimension == Dimension.x)
                {
                    if (Pos.x > pointpos.x && i.Direction == Direction.More) i.Pass = true;
                    else if(Pos.x < pointpos.x && i.Direction == Direction.Less) i.Pass = true;
                }
            }
            if (i.Pass) i.Doit();
        }
    }
}