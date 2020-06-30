using System;
[Flags]
public enum ItemType
{
    // any enum in this needs to be a power of 2, so that it will work as a flag.
    material = 1,
    weapon = 2,
    legs = 4,
    torso = 8,
    consumable = 16,
    utility = 32,
    any = material|weapon|legs|torso|consumable|utility
}