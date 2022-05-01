using UnityEngine;
using UnityEngine.Events;

public class CreateBaseSave : MonoBehaviour
{
    public UnityEvent createBaseSave, loadSave;
    public BoolSO isGamePlayed;
    void Start()
    {
        if (isGamePlayed.value == false)
        {
            createBaseSave.Invoke();
            isGamePlayed.value = true;
        }
        else
        {
            loadSave.Invoke();
        }
    }
}
