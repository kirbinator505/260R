using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    //made using https://www.youtube.com/watch?v=BLfNP4Sc_iA
    
    public Slider slider;


    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth; //will probably remove this at some point so health doesn't reset
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
