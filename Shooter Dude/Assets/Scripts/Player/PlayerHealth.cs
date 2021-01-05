using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth Instance;

    public Slider slider;

    public float maxHealth;

    public bool isDead = false;

    void Start()
    {
        Instance = this;

        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    void Update()
    {
        if(slider.value <= 0)
        {
            isDead = true;
        }
    }

    void TakeDamage(float dmg)
    {
        slider.value -= dmg;
    }

}
