using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitySlotScript : InventorySlotScript, ISlot
{
    public void AddItem(Transform item)
    {

    }
    public void RemoveItem(Transform item)
    {

    }
    public bool CheckItem(ItemType item)
    {
        return item == ItemType.utility;
    }
}
