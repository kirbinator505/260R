using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT

    public InventoryObject inventory;
    public GameObject inventoryPrefab;

    public int X_START, Y_START;
    public int X_SPACE_BETWEEN_ITEMS, NUMBER_OF_COLUMNS, Y_SPACE_BETWEEN_ITEMS;

    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];
            
            if (itemsDisplayed.ContainsKey(slot))
            {
                itemsDisplayed[inventory.Container.Items[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                    slot.amount.ToString("n0");
            }
            else
            {
                DisplaySet(i);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            DisplaySet(i);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + ((X_SPACE_BETWEEN_ITEMS *(i % NUMBER_OF_COLUMNS))), Y_START + ((-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMNS))), 0f);
    }

    private void DisplaySet(int i)
    {
        InventorySlot slot = inventory.Container.Items[i];
        var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
        obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite =
            inventory.dataBase.GetItem[slot.item.ID].uiDisplay;
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
        itemsDisplayed.Add(slot, obj); 
    }
    
}
