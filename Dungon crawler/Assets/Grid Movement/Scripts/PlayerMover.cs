using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=mbzXIOKZurA
    public float moveSpeed = 5f;
    public Transform movePoint;
    private Vector3 movement;

    public LayerMask whatStopsMovement; //this will be how we detect the layer that stops movement on the tile map (Currently, the object used as a brush must have the correct layer, not the grid used(may be because the brush uses prefabs))

    void Start()
    {
        movePoint.parent = null;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //the tutorial uses Physics2D.OverlapCircle to return a boolean, but Physics.OverlapSphere doesn't. Physics.CheckSphere does
                if (!Physics.CheckSphere(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movement.Set(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    movePoint.position += movement;
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics.CheckSphere(movePoint.position + new Vector3(0f, 0f, Input.GetAxisRaw("Vertical")), .2f, whatStopsMovement))
                {
                    movement.Set(0f, 0f, Input.GetAxisRaw("Vertical"));
                    movePoint.position += movement;
                }
            }
        }
    }
}
