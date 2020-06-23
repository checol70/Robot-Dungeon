using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentSlotScript : InventorySlotScript
{
    public abstract void Equip();
    public abstract void UnEquip();

    protected override void ItemPutIn()
    {
        Equip();
    }
    protected override void ItemTakenOut()
    {
        UnEquip();
    }
}
