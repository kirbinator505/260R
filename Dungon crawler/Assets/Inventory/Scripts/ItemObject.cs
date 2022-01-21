using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=SGz3sbZkfkg
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem()
    {
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }
}
