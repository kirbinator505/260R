using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public Vector3SO SnapPos;
    private Camera cam;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GridSnap()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, groundLayer))
        {
            SnapPos.pos = new Vector3(Mathf.Round(raycastHit.point.x), 0, Mathf.Round(raycastHit.point.y));
        }
    }
}
