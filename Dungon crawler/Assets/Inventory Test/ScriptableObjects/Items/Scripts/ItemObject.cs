using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public enum ItemType //can add new types here to expand capabilities
{
    Food,
    Helmet,
    Weapon,
    Boots,
    Chest,
    Default
}

public enum Attributes //these are for testing purposes only, will be replaced with my own
{
    Agility,
    Intellect,
    Stamina,
    Strength
}
public abstract class ItemObject : ScriptableObject
{
    //made using https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT
    public Sprite uiDisplay;
    public bool stackable;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

    public Item data = new Item();

    public Item CreateItem() // might not use
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int ID = -1;
    public ItemBuff[] buffs;

    public Item()
    {
        Name = "";
        ID = -1;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.data.ID;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
            {
                attribute = item.data.buffs[i].attribute
            };
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value, min, max;

    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        generateValue();
    }

    public void generateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
