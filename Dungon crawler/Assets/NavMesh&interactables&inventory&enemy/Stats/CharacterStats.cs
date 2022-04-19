using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //made using https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    
    public Stat damage;
    public Stat armor;
    

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= armor.Getvalue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual bool Heal(int healing)
    {
        if (currentHealth < maxHealth)
        {
            if (currentHealth + healing > maxHealth)
            {
                currentHealth += (maxHealth - currentHealth);
                return true;
            }
            else
            {
                currentHealth += healing;
                return true;
            }
        }
        return false;
    }

    public virtual void Die()
    {
        //die in some way
        //this method is meant to be overwritten for each enemy
        Debug.Log(transform.name + " perished");
    }
}