using UnityEngine;

[CreateAssetMenu()]
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
