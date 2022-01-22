using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType //can add new types here to expand capabilities
{
    Food,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    //made using https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
