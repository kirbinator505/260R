using UnityEngine;

[CreateAssetMenu]
public class BoolSO : ScriptableObject
{
    public bool value;

    public void setFalse()
    {
        value = false;
    }

    public void setTrue()
    {
        value = true;
    }
}
