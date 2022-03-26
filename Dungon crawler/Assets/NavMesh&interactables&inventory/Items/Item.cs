using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "new Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
