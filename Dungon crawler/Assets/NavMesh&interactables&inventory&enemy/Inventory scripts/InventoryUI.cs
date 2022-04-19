using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    public Transform itemsParent;
    private InventorySlot[] slots;
    public Inventory inventory;
    public GameObject inventoryUI;
    
    void Start()
    {
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
        UpdateUI();
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

    public void OpenClose()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
