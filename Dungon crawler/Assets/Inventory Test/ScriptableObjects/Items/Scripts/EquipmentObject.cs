using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float atkBonus, defenseBonus;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
