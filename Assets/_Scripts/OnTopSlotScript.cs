using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is only to make sure that whatever we grab is shown on top of everything.
public class OnTopSlotScript : MonoBehaviour
{
    public static Transform onTopSlot;
    private void Awake()
    {
        if(onTopSlot == null)
        {
            onTopSlot = transform;
        }
        if(transform != onTopSlot)
        {
            Destroy(this);
        }
    }
    private void Update()
    {
        if(transform.childCount > 0)
        {
            Transform t = transform.GetChild(0);
            t.position = Input.mousePosition;
        }
    }
}
