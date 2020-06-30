using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotScript : EquipmentSlotScript
{
    Transform weaponHook;

    public override void Equip()
    {

    }
    public override void UnEquip()
    {

    }
    public void SetWeaponHook(Transform hook)
    {
        weaponHook = hook;
    }
}
