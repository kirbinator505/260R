using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //created using https://www.youtube.com/watch?v=mbzXIOKZurA
    public float moveSpeed = 5f;
    public Transform movePoint;

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
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
            }
        }
    }
}
