using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class InventorySlotScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public static Transform previousSlot;
    ItemType allowedItems;
    public void OnPointerUp(PointerEventData eventData)
    {
        if(OnTopSlotScript.onTopSlot.childCount > 0)
        {
            GameObject go = OnTopSlotScript.onTopSlot.GetChild(0).gameObject;
            if (allowedItems == go.GetComponent<ItemScript>().GetItemType())
            {
                if (transform.childCount > 0)
                {
                    Transform previous = transform.GetChild(0);
                    previous.SetParent(previousSlot);
                    previous.position = Vector3.zero;
                    ItemTakenOut();
                }
                Transform t = OnTopSlotScript.onTopSlot.GetChild(0);
                t.SetParent(transform);
                t.localPosition = Vector3.zero;
                ItemPutIn();
            }
            else
            {
                Transform t = OnTopSlotScript.onTopSlot.GetChild(0);
                t.SetParent(previousSlot);
                t.localPosition = Vector3.zero;
            }
        }
    }

    protected virtual void ItemPutIn()
    {
        
    }
    protected virtual void ItemTakenOut()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(transform.childCount > 0)
        {
            Transform t = transform.GetChild(0);
            t.SetParent(OnTopSlotScript.onTopSlot.GetChild(0));
            previousSlot = transform;
            ItemTakenOut();
        }
    }

}
