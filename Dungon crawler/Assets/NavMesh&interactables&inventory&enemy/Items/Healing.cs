using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Healing Item")]
public class Healing : Item
{
    public int value;

    public override void Use()
    {
       base.Use();
       
       if(PlayerManager.instance.player.GetComponent<PlayerStats>().Heal(value)) 
           RemoveFromInventory();
    }
}
