using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RandomDrops))]
public class EnemyStats : CharacterStats
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    private RandomDrops dropOnDeath;
    public Animator animator;
    private bool dead;
    private WaitForSeconds wait;
    public void Start()
    {
        dropOnDeath = GetComponent<RandomDrops>();
        animator = GetComponentInChildren<Animator>();
        dead = false;
        wait = new WaitForSeconds(1);
    }

    public override void Die()
    {
        base.Die();
        
        if (!dead)
        {
            animator.SetTrigger("Death");
            dead = true;
        }

        dropOnDeath.RandomDrop();

        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return wait;
        Destroy(gameObject);
    }
}
