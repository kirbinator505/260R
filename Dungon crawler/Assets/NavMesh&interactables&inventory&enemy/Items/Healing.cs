using UnityEngine;

[CreateAssetMenu()]
public class Healing : Item
{
    public int value;
    private PlayerStats player;

    void Start()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    public override void Use()
    {
        base.Use();
        player.Heal(value);
    }
}
