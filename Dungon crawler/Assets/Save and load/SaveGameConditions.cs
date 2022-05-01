using UnityEngine;

public class SaveGameConditions : MonoBehaviour
{
    public GameActions_SO SaveGame;
    private void OnApplicationQuit()
    {
        SaveGame.raiseNoArgs.Invoke();
    }
}
