using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegSlotScript : InventorySlotScript, ISlot
{
    public void AddItem(Transform item)
    {
        //Here is where we will handle the leg spawning mechanic.
    }
    public void RemoveItem(Transform item)
    {
        //Here is where we will handle the leg removing mechanic.
    }
    public bool CheckItem(ItemType itemType)
    {
        return itemType == ItemType.legs;
    }
}
