using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    private InventorySlot[] slots;
    public Inventory inventory;
    public GameObject inventoryUI;
    
    void Start()
    {
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); //might use something else to activate and deactivate inventory
        }
    }

    void UpdateUI()
    {
        Debug.Log("updating ui");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        
    }
}
