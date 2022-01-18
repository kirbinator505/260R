using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //made using https://www.youtube.com/watch?v=lE1ss-F-rMk
    public IntSO currentHealth, maxHealth; //changed normal ints to scriptable objects

    public HealthBarScript healthBar; //gonna have to find a way around this reference

    void Start()
    {
        currentHealth.value = maxHealth.value;
        healthBar.SetMaxHealth(maxHealth.value);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HurtPlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            HealPlayer(1);
        }
    }

    public void HurtPlayer(int damage) //probably going to change this
    {
        currentHealth.value -= damage;
        
        healthBar.SetHealth(currentHealth.value);
    }

    public void HealPlayer(int heal)
    {
        currentHealth.value += heal;
        
        if (currentHealth.value > maxHealth.value)
        {
            currentHealth.value = maxHealth.value;
        }
        
        healthBar.SetHealth(currentHealth.value);
    }
}
