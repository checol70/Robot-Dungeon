using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class InventorySlotScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public static ISlot previousSlot;
    ISlot handler;
    private static Transform onTopSlot;

    public static void SetOnTopSlot(Transform _onTopSlot)
    {
        onTopSlot = _onTopSlot;
    }

    void Awake()
    {
        handler = gameObject.GetComponent<ISlot>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (onTopSlot.childCount > 0)
        {
            List<Transform> itemsToCenter = new List<Transform>();
            Transform lookingToPlace = onTopSlot.GetChild(0);
            ItemType lookingToPlaceItemType = lookingToPlace.gameObject.GetComponent<ItemScript>().GetItemType();
            itemsToCenter.Add(lookingToPlace);
            if (handler.CheckItem(lookingToPlaceItemType))
            {
                if(transform.childCount > 0)
                {
                    Transform currentlyHolding = transform.GetChild(0);
                    previousSlot.AddItem(currentlyHolding);
                    itemsToCenter.Add(currentlyHolding);
                }
                handler.AddItem(lookingToPlace);
            }
            else
            {
                previousSlot.AddItem(lookingToPlace);
            }
            ReCenterScript.Center(itemsToCenter.ToArray());
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
