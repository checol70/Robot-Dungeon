using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class InventorySlotScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public static ISlot previousSlot;
    ISlot handler;
    void Awake()
    {
        handler = gameObject.GetComponent<ISlot>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnTopSlotScript.onTopSlot.childCount > 0)
        {
            Transform lookingToPlace = OnTopSlotScript.onTopSlot.GetChild(0);
            ItemType lookingToPlaceItemType = lookingToPlace.gameObject.GetComponent<ItemScript>().GetItemType();
            if (handler.CheckItem(lookingToPlaceItemType))
            {
                if(transform.childCount > 0)
                {
                    Transform currentlyHolding = transform.GetChild(0);
                    previousSlot.AddItem(currentlyHolding);
                    currentlyHolding.localPosition = Vector3.zero;
                }
                handler.AddItem(lookingToPlace);
            }
            else
            {
                previousSlot.AddItem(lookingToPlace);
            }
            lookingToPlace.localPosition = Vector3.zero;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(transform.childCount > 0)
        {
            Transform currentlyHolding = transform.GetChild(0);
            handler.RemoveItem(currentlyHolding);
        }
    }

}
