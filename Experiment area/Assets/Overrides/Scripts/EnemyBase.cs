using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    void Start()
    {
        
    }

    protected virtual void Update() //protected is a version of private that can be inherited
    {
        Run();
    }

    protected void Run()
    {
        Debug.Log("run");
    }

    protected void DoDamage()
    {
        Debug.Log("Do damage");
    }
}
