using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnTopSlotScript : MonoBehaviour
{
    //this is to make sure that whatever we grab is shown on top of everything, and to handle it following the mouse.
    private void Start()
    {
        InventorySlotScript.SetOnTopSlot(transform);
    }
    private void Update()
    {
        if(transform.childCount > 0)
        {
            Transform t = transform.GetChild(0);
            t.localPosition = Input.mousePosition;
        }
    }
}
