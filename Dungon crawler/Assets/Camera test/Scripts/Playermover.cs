using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Playermover : MonoBehaviour
{
    private Rigidbody player;
    public Vector3SO playerPos;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(Vector3.forward);
            Debug.Log("W");
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.AddForce(Vector3.back);
            Debug.Log("S");
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(Vector3.left);
            Debug.Log("A");
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(Vector3.right);
            Debug.Log("D");
        }

        playerPos.pos = player.transform.position; // gets player position and feeds it to Vector3SO
    }
}
