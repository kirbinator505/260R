using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour, IHealth, IMove
{
    public ScriptableObject powerUp;
    private IPowerUp powerUpObj;

    public void Start()
    {
        powerUpObj = powerUp as IPowerUp;
        print(powerUpObj.PowerLevel);
    }
    
    public float Health { get; set; }
    
    public float Speed { get; set; }
    public void Walk()
    {
        throw new System.NotImplementedException();
    }

    void IMove.Run()
    {
        throw new System.NotImplementedException();
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void Idle()
    {
        throw new System.NotImplementedException();
    }

    void IHealth.Run()
    {
        throw new System.NotImplementedException();
    }
}
