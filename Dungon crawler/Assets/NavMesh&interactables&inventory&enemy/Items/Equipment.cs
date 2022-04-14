using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifier;
    public EquipmentManager equipmentManager;

    public override void Use()
    {
        base.Use();
        equipmentManager.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
