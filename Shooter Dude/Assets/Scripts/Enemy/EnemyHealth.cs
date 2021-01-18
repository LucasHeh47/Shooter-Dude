using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public static EnemyHealth Instance;

    public Enemy enemy;
    public GameObject healthBarObj;
    private Slider healthBar;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar = healthBarObj.GetComponent<Slider>();
        healthBar.maxValue = enemy.MaxHealth;
        healthBar.value = enemy.MaxHealth;
        EnemyManager.Instance.EnemysOnMap++;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarObj.transform.position = CameraFollowPlayer.Instance.gameObject.GetComponent<Camera>().WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z));
    }

    void TakeDamage(float dmg)
    {
        healthBar.value -= dmg;
        if (healthBar.value <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        int random = Random.Range(0, 100);
        if (random == 69)
        {
            PowerUpManager.Instance.SpawnRandomPowerUp(transform.position);
        }
        Destroy(gameObject);
        EnemyManager.Instance.EnemysOnMap--;
        EnemyManager.Instance.enemysLeft--;
        EnemyManager.Instance.Kills++;
        PlayerCurrency.Instance.CollectMoney(enemy.MoneyDrop);
        PlayerCurrency.Instance.CurrencyText.SetText("$" + PlayerCurrency.Instance.money.ToString());
    }

    public void IncreaseHealth()
    {
        enemy.MaxHealth *= enemy.HealthMultiplier;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            if(col.gameObject.GetComponent<Bullet>().Active) TakeDamage(PlayerGun.Instance.GetDamage(GunManager.Instance.GetGunByBulletImage(col.gameObject.GetComponent<SpriteRenderer>().sprite)));

            if (!GunManager.Instance.GetGunByBulletImage(col.gameObject.GetComponent<SpriteRenderer>().sprite).Pierces)
            {
                col.gameObject.GetComponent<Bullet>().Active = false;
                Destroy(col.gameObject);
            }
        }
    }

}
