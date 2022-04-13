using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "new Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public Inventory inventory;

    public virtual void Use()
    {
        //use the item
        
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        inventory.Remove(this);
    }
}
