
using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactionRadius = 3f;

    private bool isFocus = false, hasInteracted = false;
    private Transform player;
    public Transform interactionTransform;
    private float distance;

    public virtual void Interact()
    {
        //this method is meant to be overwritten
        Debug.Log("interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= interactionRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, interactionRadius);
    }
}
