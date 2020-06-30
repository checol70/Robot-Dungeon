using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlot
{
    void AddItem(Transform item);
    void RemoveItem(Transform item);
    bool CheckItem(ItemType item);
}
