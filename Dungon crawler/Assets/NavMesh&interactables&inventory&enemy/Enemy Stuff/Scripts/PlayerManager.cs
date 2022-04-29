using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player, deathMenu;
    public Inventory playerInventory;

    public void KillPlayer()
    {
        deathMenu.gameObject.SetActive(true);
        playerInventory.ClearInventory();
    }
}
