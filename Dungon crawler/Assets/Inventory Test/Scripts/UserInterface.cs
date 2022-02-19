using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UserInterface : MonoBehaviour
{
    //mostly created using https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT

    public InventoryObject inventory;
    public GameObject groundItemPrefab;
    public Vector3SO dropLocationSO;
    public UnityEvent itemDropped;
    public Dictionary<GameObject, InventorySlot> slostOnInterface = new Dictionary<GameObject, InventorySlot>();
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            inventory.GetSlots[i].parent = this;
            inventory.GetSlots[i].OnAfterUpdate += OnSlotUpdate;
        }
        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    private void OnSlotUpdate(InventorySlot slot)
    {
        
        if (slot.item.ID >= 0)
        {
            slot.SlotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().sprite = slot.ItemObject.uiDisplay;
            slot.SlotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            slot.SlotDisplay.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount == 1 ? "" : slot.amount.ToString("n0");
        }
        else
        {
            slot.SlotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
            slot.SlotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            slot.SlotDisplay.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    public abstract void CreateSlots();
    

    public void OnEnter(GameObject obj)
    {
        MouseData.slotHoveredOver = obj;
    }
    public void OnExit(GameObject obj)
    {
        MouseData.slotHoveredOver = null;
    }
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.InterfaceMouseOver = obj.GetComponent<UserInterface>();
    }
    public void OnExitInterface(GameObject obj)
    {
        MouseData.InterfaceMouseOver = null;
    }
    public void OnDragStart(GameObject obj)
    {
        MouseData.tempItemDragged = CreateTempItem(obj);
    }
    public void OnDragEnd(GameObject obj)
    {
        Destroy(MouseData.tempItemDragged);

        if (MouseData.InterfaceMouseOver == null)
        {
            if (slostOnInterface[obj].item.ID >= 0)
            {
                DropItem(obj);
            }
            return;
        }

        if (MouseData.slotHoveredOver)
        {
            InventorySlot mouseHoverSlotData = MouseData.InterfaceMouseOver.slostOnInterface[MouseData.slotHoveredOver];
            inventory.SwapItems(slostOnInterface[obj], mouseHoverSlotData);
        }
    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItemDragged != null)
        {
            MouseData.tempItemDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public GameObject CreateTempItem(GameObject obj)
    {
        GameObject tempItem = null;
        if (slostOnInterface[obj].item.ID >= 0)
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(50, 50); //this needs to match the rect transform size of the InventoryPrefab
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
            img.sprite = slostOnInterface[obj].ItemObject.uiDisplay;
            img.raycastTarget = false;
        }
        return tempItem;
    }

    public void DropItem(GameObject obj)
    {
        itemDropped.Invoke();
        Vector3 position = dropLocationSO.pos;
        var groundOBJ = Instantiate(groundItemPrefab, position, Quaternion.identity, transform);
        groundOBJ.GetComponent<GroundItem>().item = inventory.dataBase.ItemObjects[slostOnInterface[obj].item.ID];
        groundOBJ.GetComponent<GroundItem>().item.data.buffs = slostOnInterface[obj].item.buffs;
        groundOBJ.transform.parent = null;
        slostOnInterface[obj].RemoveItemAmount();
    }
    protected void  AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    
}

public static class MouseData
{
    public static GameObject tempItemDragged;
    public static GameObject slotHoveredOver;
    public static UserInterface InterfaceMouseOver;
}

public static class ExtensionMethods
{
    public static void UpdateSlotDisplay(this Dictionary<GameObject, InventorySlot> _slotsOnInterface)
    {
        
        foreach (KeyValuePair<GameObject,InventorySlot> slot in _slotsOnInterface)
        {
            if (slot.Value.item.ID >= 0)
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = slot.Value.ItemObject.uiDisplay;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = slot.Value.amount == 1 ? "" : slot.Value.amount.ToString("n0");
            }
            else
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
}