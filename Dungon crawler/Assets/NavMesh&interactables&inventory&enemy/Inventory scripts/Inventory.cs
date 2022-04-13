using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //while this script is on a game manager, it could easily be moved to a player, and probably will be

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
}
