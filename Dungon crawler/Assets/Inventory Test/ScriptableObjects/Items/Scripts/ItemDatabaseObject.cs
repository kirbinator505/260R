using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    //created using https://www.youtube.com/watch?v=232EqU1k9yQ&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=2
    //need to find some way to automate populating the database the first time
    public ItemObject[] ItemObjects;
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    //won't use this 
    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < ItemObjects.Length; i++)
        {
            ItemObjects[i].data.ID = i;
            GetItem.Add(i, ItemObjects[i]);
        }
    }
}
