using UnityEngine;

public class ItemPickup : Interactable
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
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
