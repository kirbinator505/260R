using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    new public string name = "new Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public Inventory inventory;
    public GameObject obj;

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
