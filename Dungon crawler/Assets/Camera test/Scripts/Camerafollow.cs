using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Vector3SO playerPos;
    public GameObject cameraObj; //put camera game object here
    public float xAdd, yAdd, zAdd; //this, as well as camera rotation, should be set after movement is figured out, and also probably turned into a Vector3
    private Vector3 cameraObjPos;

    void Start()
    {
        cameraObjPos = playerPos.pos;
        cameraObjPos.x += xAdd;
        cameraObjPos.y += yAdd;
        cameraObjPos.z += zAdd;
        cameraObj.transform.position = cameraObjPos;

    }

    // Update is called once per frame
    void Update()
    {
        cameraObjPos = playerPos.pos;
        cameraObjPos.x += xAdd;
        cameraObjPos.y += yAdd;
        cameraObjPos.z += zAdd;
        cameraObj.transform.position = cameraObjPos;
    }
}
