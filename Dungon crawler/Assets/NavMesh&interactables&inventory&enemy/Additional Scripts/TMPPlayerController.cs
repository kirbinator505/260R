using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class TMPPlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    private Ray ray;
    private RaycastHit hit;
    public Vector3SO playerPos;
    private Interactable interactable, focus;
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // move out agent (Will make this the destination ball in the grid movement thing)
                agent.SetDestination(hit.point);
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))// this uses right click, I'm going to have to find some way to convert this to touch
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        playerPos.pos = transform.position;
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();
        focus = null;
        StopFollowingTarget();
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.interactionRadius * 0.8f;
        agent.updateRotation = false;
        
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

            target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }
}
