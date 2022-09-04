using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleTest : MonoBehaviour
{
    public void FirstHoverEntered() => print("FirstHoverEntered" +" "+ Time.time);
    public void LastHoverExited() => print("LastHoverExited" + " " + Time.time);
    public void HoverEntered() => print("HoverEntered" + " " + Time.time);
    public void HoverExited() => print("HoverExited" + " " + Time.time);
    public void FirstSelectEntered() => print("FirstSelectEntered" + " " + Time.time);
    public void LastSelectEntered() => print("LastSelectEntered" + " " + Time.time);
    public void SelectEntered() => print("SelectEntered" + " " + Time.time);
    public void SelectExited() => print("SelectExited" + " " + Time.time);
    public void Activated() => print("Activated" + " " + Time.time);
    public void Deactivated() => print("Deactivated" + " " + Time.time);

}
