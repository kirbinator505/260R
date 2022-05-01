using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject itemPrefab;

    public List<Item> items = new List<Item>();

    public int space = 20;

    public bool AddItem(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Full inventory");
                return false;
            }
            
            items.Add(item);
         
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Drop(Item item)
    {
        if (item != null)
        {
            itemPrefab.GetComponent<ItemPickup>().item = item;
            GameObject droppedItem = Instantiate(itemPrefab, new Vector3(PlayerManager.instance.player.transform.position.x, 1f, PlayerManager.instance.player.transform.position.z), Quaternion.identity);
            droppedItem.transform.parent = null;
            items.Remove(item);
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public void ClearInventory()
    {
        foreach (var item in items)
        {
            Remove(item);
        }
    }
}
