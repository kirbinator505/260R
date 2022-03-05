using UnityEngine;
using UnityEngine.AI;

public class TMPTriggerEnemyPathfinding : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    private Ray ray;
    private RaycastHit hit;
    public Vector3SO playerPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.SetDestination(playerPos.pos);
        }
    }
}
