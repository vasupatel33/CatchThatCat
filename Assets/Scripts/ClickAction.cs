using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    //public int a;
    private void OnMouseUp()
    {
        Debug.Log("current Obj is = "+gameObject.name);
        GameManager.instance.ClickedObjectFun(this.gameObject);
    }
}
