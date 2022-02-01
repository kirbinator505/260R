using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera _camera;

    public void LateUpdate()
    {
        transform.forward = _camera.transform.forward;
    }
}
