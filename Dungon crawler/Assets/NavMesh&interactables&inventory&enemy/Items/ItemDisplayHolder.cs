using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDisplayHolder : MonoBehaviour
{
    public ItemDisplay itemDisplay;

    public void Awake()
    {
        itemDisplay.parent = this.transform;
    }
}
