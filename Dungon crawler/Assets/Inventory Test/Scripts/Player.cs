using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT

    //public MouseItem mouseItem = new MouseItem();
    
    public InventoryObject inventory;
    public InventoryObject equipment;

    public void OnTriggerEnter(Collider other) //will probably replace this with a pickup prompt
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            if (inventory.AddItem(_item, 1))
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void Update() //this is just to run the save and load stuff, will bind it to something else
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save(); //this is what I'll need to bind to something else, probably application.quit and some other autosave function
            equipment.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load(); //this will be bound to the application loading
            equipment.Load();
        }
    }

    private void OnApplicationQuit() //this is just used to clear inventory during testing, don't use for actual game or all items will get deleted

    {
        inventory.Container.clear();
        equipment.Container.clear();
    }
}
