using UnityEngine;

public class Player : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT

    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other) //will probably replace this with a pickup prompt
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit() //this is just used to clear inventory during testing, don't use for actual game or all items will get deleted
    
    {
        inventory.Container.Clear();
    }
}
