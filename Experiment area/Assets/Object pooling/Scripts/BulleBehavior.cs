using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BulleBehavior : MonoBehaviour
{
    private Rigidbody rbObj;
    private WaitForSeconds wfsObj;
    public float force = 10, holdTime = 2f;
    public Transform startPoint;

    private void Awake()
    {
        wfsObj = new WaitForSeconds(holdTime);
        rbObj = GetComponent<Rigidbody>();
        rbObj.useGravity = false;
    }
    private IEnumerator Start()
    {
        rbObj.WakeUp();
        rbObj.velocity = Vector3.right * force;
        yield return wfsObj;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        rbObj.Sleep();
    }
    
    
}
