using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    //created using https://www.youtube.com/watch?v=SGz3sbZkfkg
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
}
