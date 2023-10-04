using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    private void OnMouseUp()
    {
        Debug.Log("current Obj is = "+gameObject.name);
    }
}
