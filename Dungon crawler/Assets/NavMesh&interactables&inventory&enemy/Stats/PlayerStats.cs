using UnityEngine;

public class PlayerStats : CharacterStats
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    public EquipmentManager equipmentManager;
    public HealthBarScript healthBar;
    public Animator animator;
    private bool dead;
    void Start()
    {
        equipmentManager.onEquipmentChanged += OnEquipmentChanged;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating("SetCurrentHealth", 0f, 1f);
        dead = false;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    void SetCurrentHealth()
    {
        healthBar.SetHealth(currentHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealth(currentHealth);
    }

    public override bool Heal(int healing)
    {
        if (base.Heal(healing))
        {
            healthBar.SetHealth(currentHealth);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Die()
    {
        base.Die();
        if (!dead)
        {
            animator.SetTrigger("Death");
            dead = true;
        }
        equipmentManager.ClearAll();
        PlayerManager.instance.KillPlayer();
    }
}
