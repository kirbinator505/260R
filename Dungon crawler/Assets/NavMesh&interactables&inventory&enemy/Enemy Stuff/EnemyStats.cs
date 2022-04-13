using UnityEngine;

[RequireComponent(typeof(RandomDrops))]
public class EnemyStats : CharacterStats
{
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
