using System.Collections;
using UnityEditor;
using UnityEngine;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject item;
    public Item _item;

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
