using UnityEngine;

//[RequireComponent(typeof(GameObject))]
public class ParentToChildAttributeTransfer : MonoBehaviour
{
    public GameObject parent;
    private int parentLayer, childCount;

    void Start()
    {
        //parent = GetComponent<GameObject>();
        
        parentLayer = parent.gameObject.layer; //gets the layer of the parent
        childCount = parent.transform.childCount; //gets the number of children
        
        for (int i = 0; i < childCount; i++) //starting at zero, sets the layer of each child to the layer of the parent
        {
            parent.transform.GetChild(i).gameObject.layer = parentLayer;
        }
    }
}
