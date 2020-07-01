using System;
[Flags]
public enum ItemType
{
    // any enum in this needs to be a power of 2, so that it will work as a flag. this way we can have some slots carry multiple types.
    material = 1,
    weapon = 2,
    legs = 4,
    torso = 8,
    consumable = 16,
    utility = 32
}