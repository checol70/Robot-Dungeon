using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
