using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public Inventory inventory;
    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking Up " + item.name);
        
        if(inventory.AddItem(item))
            Destroy(gameObject);
    }
}
