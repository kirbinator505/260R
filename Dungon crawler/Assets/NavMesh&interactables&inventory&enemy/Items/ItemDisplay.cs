using UnityEngine;

[CreateAssetMenu]
public class ItemDisplay : ScriptableObject
{
    private GameObject oldItem;
    public Transform parent;

    public void DisplayItem(GameObject obj)
    {
        if (oldItem != null)
        {
            Destroy(oldItem);
            oldItem = Instantiate(obj, parent);
        }
        else
        {
            oldItem = Instantiate(obj);
        }
    }

    public void ClearDisplay()
    {
        Destroy(oldItem);
    }
}
