using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTBUFFSTUFF : MonoBehaviour
{
    public GameObject GroundObjectThing;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < GroundObjectThing.GetComponent<GroundItem>()._item.buffs.Length; i++)
            {
               // Debug.Log(GroundObjectThing.GetComponent<GroundItem>()._item.buffs[i].value);
               GroundObjectThing.GetComponent<GroundItem>()._item.buffs[i].value = 1;
            }
        }
    }
}
