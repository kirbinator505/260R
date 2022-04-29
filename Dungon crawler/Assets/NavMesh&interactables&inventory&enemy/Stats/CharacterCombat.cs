using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    public float attackSpeed = 1;
    private float attackCooldown;
    
    public float attackDelay = .6f;

    public Animator animator;
    public event System.Action OnAttack;

    private CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown < 0)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            animator.SetTrigger("Attack");
            if (OnAttack != null)
            {
                OnAttack();
            }
            
            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.Getvalue());
    }
}
