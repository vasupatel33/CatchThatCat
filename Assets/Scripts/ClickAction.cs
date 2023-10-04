using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    public int a;
    private void OnMouseUp()
    {
        Debug.Log("current Obj is = "+gameObject.name);
    
        Debug.Log("Middle Point is = " + GameManager.instance.middlePoint);
        //GameManager.instance.middlePoint = 
    }
}
