using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/New Equipment Manager")]
public class EquipmentManager : ScriptableObject
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    private Equipment[] currentEquipment;

    public Inventory inventory;

    public ItemDisplay WeaponDisplay, ShieldDisplay;
    
    private Equipment oldItem = null;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Awake()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int) newItem.equipSlot;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        if (slotIndex == 3)
        {
            WeaponDisplay.DisplayItem(newItem.obj);
        }
        if (slotIndex == 4)
        {
            ShieldDisplay.DisplayItem(newItem.obj);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
            currentEquipment[slotIndex] = null;
            
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            if (slotIndex == 3)
            {
                WeaponDisplay.ClearDisplay();
            }
            if (slotIndex == 4)
            {
                ShieldDisplay.ClearDisplay();
            }
        }
    }
    
    public void ClearSlot(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            currentEquipment[slotIndex] = null;
            
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    public void ClearAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            ClearSlot(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))// will probably replace this call with a ui element as mobile doesn't have a keyboard
        {
            UnequipAll();
        }
    }
}
