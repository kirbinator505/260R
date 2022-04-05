using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //I'll need to find a way to replace this singleton with something else. The old inventory system had the inventory itself be a Scriptable Object, so that might be the solution
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

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
