using System.Collections;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{

    public GameObject prefab;
    public Item SpawnedItem;
    public GameObject[] SpawnedObjArray;
    public float waitTime;
    private GameObject SpawnedObject;
    private Vector3 pos;
    private WaitForSeconds wfs;
    private bool itemTaken;
    void Start()
    {
        wfs = new WaitForSeconds(waitTime);
        pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        prefab.GetComponent<ItemPickup>().item = SpawnedItem;
        SpawnedObject = Instantiate(prefab, pos, Quaternion.identity);
        SpawnedObjArray[0] = SpawnedObject;
        InvokeRepeating("CheckIfGone", 0.5f ,1.2f);
    }
    
    void CheckIfGone()
    {
        if (SpawnedObjArray[0] == null)
        {
            itemTaken = true;
        }

        if (itemTaken)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        yield return wfs;
        itemTaken = false;
        prefab.GetComponent<ItemPickup>().item = SpawnedItem;
        SpawnedObject = Instantiate(prefab, pos, Quaternion.identity);
        SpawnedObjArray[0] = SpawnedObject;
    }
}
