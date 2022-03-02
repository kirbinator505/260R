using UnityEngine;
using UnityEngine.AI;

public class TMPPlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // move out agent (Will make this the destination ball in the grid movement thing)
                agent.SetDestination(hit.point);
            }
        }
    }
}
