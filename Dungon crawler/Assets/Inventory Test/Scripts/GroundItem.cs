using System.Collections;
using UnityEditor;
using UnityEngine;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject item;
    public WaitForSeconds wfsobject = new WaitForSeconds(1f);
    public Item _item;

    public void Start()
    {
        StartCoroutine(IsItNew());
    }

    IEnumerator IsItNew()
    {
        yield return wfsobject;
        if (item.IsNewItem)
        {
            _item = item.CreateItem();
            //Debug.Log("it's new");
        }
    }

    public void OnBeforeSerialize()
    {
        #if UNITY_EDITOR
        GetComponentInChildren<SpriteRenderer>().sprite = item.uiDisplay;
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
        #endif
    }

    public void OnAfterDeserialize()
    {
        
    }
}
