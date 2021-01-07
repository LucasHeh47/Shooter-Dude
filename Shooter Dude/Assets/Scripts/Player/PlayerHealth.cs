using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth Instance;

    public Slider slider;
    public Slider armorBar;

    public float maxHealth;
    public float maxArmor;

    private float healthRegenRate = 5;

    private float regenDelay = 1;

    private float regenedHealth;

    private float lastDmgTime;

    public bool isDead = false;

    void Start()
    {
        Instance = this;

        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        armorBar.maxValue = maxArmor;
    }

    public void RegenHealth()
    {
        regenedHealth += healthRegenRate * Time.deltaTime;
        int flooredRegendedHealth = Mathf.FloorToInt(regenedHealth);
        regenedHealth -= flooredRegendedHealth;
        Heal(flooredRegendedHealth);
    }

    void Update()
    {
        if(lastDmgTime >= 0 && Time.time - lastDmgTime >= regenDelay)
        {
            RegenHealth();
        }
    }

    public void TakeDamage(float dmg)
    {
        float dmgToDo = dmg;
        if(armorBar.value == dmgToDo)
        {
            armorBar.value = 0;
            return;
        }
        if(armorBar.value > 0)
        {
            if(dmgToDo > armorBar.value)
            {
                dmgToDo -= armorBar.value;
                armorBar.value = 0;
            }
            else
            {
                armorBar.value -= dmgToDo;
                    return;
            }
        }
        slider.value -= dmgToDo;
        regenedHealth = 0;
        lastDmgTime = Time.time;
        if(slider.value <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
    }

    public void Heal(int amt)
    {
        slider.value = Mathf.Clamp(slider.value + amt, 0, slider.maxValue);
        if( slider.value == slider.maxValue)
        {

        }
    }

}
