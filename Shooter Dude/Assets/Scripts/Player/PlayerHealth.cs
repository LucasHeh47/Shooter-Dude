using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth Instance;

    public Slider slider;
    public Slider armorBar;

    public float maxHealth;
    public float maxArmor;

    private float healthRegenRate = 10;
    public TextMeshProUGUI selfReviveText;

    public int SelfRevives = 0;

    private float regenDelay = 1;

    private float regenedHealth;

    public int enemysKilled;

    private float lastDmgTime;

    public bool isDead = false;

    void Start()
    {
        Instance = this;

        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        enemysKilled = 0;

        armorBar.maxValue = maxArmor;
    }

    public void IncrementSelfRevive()
    {
        SelfRevives++;
        selfReviveText.SetText(SelfRevives.ToString());
    }

    public void RegenHealth()
    {
        regenedHealth += healthRegenRate * Time.deltaTime;
        int flooredRegendedHealth = Mathf.FloorToInt(regenedHealth);
        regenedHealth -= flooredRegendedHealth;
        Heal(flooredRegendedHealth);
    }

    public void MedicPowerUp()
    {
        slider.value = slider.maxValue;
        armorBar.value = armorBar.maxValue;
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
        if(SelfRevives > 0)
        {
            SelfRevives--;
            selfReviveText.SetText(SelfRevives.ToString());
            slider.value = slider.maxValue;
            return;
        }
        isDead = true;
        GlobalManager.Instance.RoundMadeTo = EnemyManager.Instance.Round;
        GlobalManager.Instance.expToAdd = (enemysKilled * 10) + (EnemyManager.Instance.Round * 20);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GlobalManager.Instance.LoadScene("Waves Game Over");
    }

    public void Heal(int amt)
    {
        slider.value = Mathf.Clamp(slider.value + amt, 0, slider.maxValue);
        if( slider.value == slider.maxValue)
        {

        }
    }

}
