using UnityEngine;

[RequireComponent(typeof(RandomDrops))]
public class EnemyStats : CharacterStats
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    private RandomDrops dropOnDeath;
    public void Start()
    {
        dropOnDeath = GetComponent<RandomDrops>();
    }

    public override void Die()
    {
        base.Die();
        
        //add ragdoll/ death animation
        
        dropOnDeath.RandomDrop();
        
        Destroy(gameObject);
    }
}
