using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void LateUpdate()
    {
        transform.forward = _camera.transform.forward;
    }
}
