using UnityEngine;

[CreateAssetMenu]
public class ItemDisplay : ScriptableObject
{
    private GameObject oldItem;
    public Transform parentTransform;

    public void DisplayItem(GameObject obj)
    {
        if (oldItem != null)
        {
            Destroy(oldItem);
            oldItem = Instantiate(obj, parentTransform);
        }
        else
        {
            oldItem = Instantiate(obj, parentTransform);
        }
    }

    public void ClearDisplay()
    {
        Destroy(oldItem);
    }
}
