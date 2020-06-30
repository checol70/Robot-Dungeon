using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotScript : InventorySlotScript, ISlot
{
    Transform weaponHook;

    public void SetWeaponHook(Transform hook)
    {
        weaponHook = hook;
    }
    public void AddItem(Transform item)
    {

    }
    public void RemoveItem(Transform item)
    {

    }
    public bool CheckItem(ItemType itemType)
    {
        return itemType == ItemType.weapon;
    }
}
