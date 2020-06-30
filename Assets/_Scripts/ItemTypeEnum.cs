public enum ItemType
{
    material = 0,
    weapon,
    legs,
    torso,
    consumable,
    utility,
    any = material|weapon|legs|torso|consumable|utility
}
