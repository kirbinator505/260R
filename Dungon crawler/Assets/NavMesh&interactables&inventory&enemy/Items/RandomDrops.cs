using UnityEngine;
using Random = UnityEngine.Random;

public class RandomDrops : MonoBehaviour
{
    public ItemList itemInventory;
    private int doesDrop, dropsWhat;
    public int dropChanceDivider, DropChanceTarget;
    public GameObject itemPrefab;
    public void Start()
    {
        RandomDrop();
    }

    public void RandomDrop()
    {
        doesDrop = Random.Range(0, 100);
        Debug.Log(doesDrop);
        if (doesDrop % dropChanceDivider == DropChanceTarget)
        {
            dropsWhat = Random.Range(0, itemInventory.itemsList.Length);
            Debug.Log(itemInventory.itemsList[dropsWhat].name + " dropped");
            GameObject droppedItem = Instantiate(itemPrefab, new Vector3(this.transform.position.x, 1f, this.transform.position.z), Quaternion.identity);
            droppedItem.GetComponent<ItemPickup>().item = itemInventory.itemsList[dropsWhat];
        }
    }
}
