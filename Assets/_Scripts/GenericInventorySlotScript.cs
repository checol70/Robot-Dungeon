using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInventorySlotScript : InventorySlotScript, ISlot
{
    public void AddItem(Transform transform)
    {

    }
    public void RemoveItem(Transform transform)
    {

    }
    public bool CheckItem(ItemType itemType)
    {
        return true;
    }
}
