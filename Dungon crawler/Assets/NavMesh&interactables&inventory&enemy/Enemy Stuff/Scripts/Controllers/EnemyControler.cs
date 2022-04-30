using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterCombat))]
public class EnemyControler : MonoBehaviour
{
    // made using https://www.youtube.com/watch?v=xppompv1DBg&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=11

    public float lookRadius = 5f;

    private Transform target;
    private NavMeshAgent agent, agentSpeed;
    private CharacterCombat combat;
    public Animator animator;
    private float speedPercent;
    private bool moving, walkToggle,stopWalkToggle;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        agentSpeed = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        moving = false;
    }

    void Update()
    {
        speedPercent = agentSpeed.velocity.magnitude / agentSpeed.speed;
        
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                faceTarget();
            }
        }
        
        if (speedPercent > 0.1)
        {
            moving = true;
            stopWalkToggle = true;
            if (walkToggle)
            {
                walkToggle = false;
                animator.SetTrigger("Walk");
                Debug.Log("moving");
            }
        }
        if (speedPercent < 0.1)
        {
            walkToggle = true;
            moving = false;
            if (stopWalkToggle)
            {
                stopWalkToggle = false;
                animator.SetTrigger("Stop walk");
                Debug.Log("stop");
            }
        }
    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
