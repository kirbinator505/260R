using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UserInterface : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT

    public Player player;

    public InventoryObject inventory;
    public Dictionary<GameObject, InventorySlot> slostOnInterface = new Dictionary<GameObject, InventorySlot>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            inventory.Container.Items[i].parent = this;
        }
        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots(); // might be able to remove this and call the class with a game object to only update once something is picked up
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject,InventorySlot> slot in slostOnInterface)
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
    }public void OnExitInterface(GameObject obj)
    {
        MouseData.InterfaceMouseOver = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObj = new GameObject();
        var rt = mouseObj.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50); //this needs to match the rect transform size of the InventoryPrefab
        mouseObj.transform.SetParent(transform.parent);
        if (slostOnInterface[obj].item.ID >= 0)
        {
            var img = mouseObj.AddComponent<Image>();
            img.sprite = slostOnInterface[obj].ItemObject.uiDisplay;
            img.raycastTarget = false;
        }
        MouseData.tempItemDragged = mouseObj;
    }
    public void OnDragEnd(GameObject obj)
    {
        Destroy(MouseData.tempItemDragged);

        if (MouseData.InterfaceMouseOver == null)
        {
            slostOnInterface[obj].RemoveItem();
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