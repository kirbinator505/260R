using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEnemy : EnemyBase
{
    protected override void Update() //override allows an inherited function to be used differently than the parent
    {
        base.Update();
        DoDamage();
    }
}
