using UnityEngine;

public class SetItemSprite : MonoBehaviour
{
    public GameObject leItem;
    public void Start()
    {
        leItem.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
            leItem.GetComponent<GroundItem>().item.uiDisplay;
    }
}
