using UnityEngine;

public class DisplayOnGround : MonoBehaviour
{
    public void DisplayItemOnGround(Item item)
    {
        Instantiate(item.obj, this.transform);
    }
}
