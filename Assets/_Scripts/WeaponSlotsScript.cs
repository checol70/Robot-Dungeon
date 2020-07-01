using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotScript : InventorySlotScript, ISlot
{
    Transform weaponHook;
    protected GameObject weapon;
    GameObject currentWeapon;

    public void SetWeaponHook(Transform hook)
    {
        weaponHook = hook;
    }
    public void AddItem(Transform item)
    {
        Instantiate(weapon, weaponHook);
    }
    public void RemoveItem(Transform item)
    {
        Destroy(currentWeapon);
    }
    public bool CheckItem(ItemType itemType)
    {
        return itemType == ItemType.weapon;
    }
}
