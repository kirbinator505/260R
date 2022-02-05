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
    

   

    public Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
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
        foreach (KeyValuePair<GameObject,InventorySlot> _slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.dataBase.GetItem[_slot.Value.item.ID].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public abstract void CreateSlots();



    public void OnEnter(GameObject obj)
    {
        player.mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
        {
            player.mouseItem.hoverItem = itemsDisplayed[obj];
        }
    }
    public void OnExit(GameObject obj)
    {
        player.mouseItem.hoverObj = null;
        player.mouseItem.hoverItem = null;
    }
    public void OnEnterInterface(GameObject obj)
    {
        player.mouseItem.UI = obj.GetComponent<UserInterface>();
    }public void OnExitInterface(GameObject obj)
    {
        player.mouseItem.UI = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObj = new GameObject();
        var rt = mouseObj.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50); //this needs to match the rect transform size of the InventoryPrefab
        mouseObj.transform.SetParent(transform.parent);
        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObj.AddComponent<Image>();
            img.sprite = inventory.dataBase.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.raycastTarget = false;
        }
        player.mouseItem.obj = mouseObj;
        player.mouseItem.item = itemsDisplayed[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        var itemOnMouse = player.mouseItem;
        var mouseHoverItem = itemOnMouse.hoverItem;
        var mouseHoverObj = itemOnMouse.hoverObj;
        var getItemObject = inventory.dataBase.GetItem;
        
        if (itemOnMouse.UI != null)
        {
            if (mouseHoverObj)
            {
                if(mouseHoverItem.CanPlaceInSlot(getItemObject[itemsDisplayed[obj].ID]) && (mouseHoverItem.item.ID <= -1 || (mouseHoverItem.item.ID >= 0 && itemsDisplayed[obj].CanPlaceInSlot(getItemObject[mouseHoverItem.item.ID]))))
                    inventory.MoveItem(itemsDisplayed[obj], mouseHoverItem.parent.itemsDisplayed[itemOnMouse.hoverObj]);
            }
            else
            {
                inventory.RemoveItem(itemsDisplayed[obj].item);
            }
            Destroy(itemOnMouse.obj);
            itemOnMouse.item = null;
        }
    }
    public void OnDrag(GameObject obj)
    {
        if (player.mouseItem.obj != null)
        {
            player.mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
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

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
    public UserInterface UI;
}