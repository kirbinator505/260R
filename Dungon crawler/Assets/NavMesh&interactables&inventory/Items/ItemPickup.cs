using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    private bool wasPickedUp;
    public override void Interact()
    {
        PickUp();
        
        
    }

    void PickUp()
    {
        Debug.Log("Picking Up " + item.name);
        wasPickedUp = Inventory.instance.AddItem(item);
        
        if(wasPickedUp)
            Destroy(gameObject);
    }
}
