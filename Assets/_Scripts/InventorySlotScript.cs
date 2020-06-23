using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ItemType
{
    material = 0,
    weapon,
    legs,
    torso,
    consumable,
    utility
}

public class InventorySlotScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public void OnPointerUp(PointerEventData eventData)
    {
        if(OnTopSlotScript.onTopSlot.childCount > 0)
        {
            Transform t = OnTopSlotScript.onTopSlot.GetChild(0);
            t.SetParent(transform);
            t.localPosition = Vector3.zero;
            ItemPutIn();
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
            ItemTakenOut();
        }
    }

}
