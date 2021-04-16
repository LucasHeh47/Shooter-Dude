using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (GetComponent<PowerUpSpawn>().power.Name == "Max Ammo")
            {
                PlayerGun.Instance.ReloadAllGunsCompletely();
            }
            if (GetComponent<PowerUpSpawn>().power.Name == "Medic")
            {
                PlayerHealth.Instance.MedicPowerUp();
            }
            if (GetComponent<PowerUpSpawn>().power.Name == "Double Cash")
            {
                PowerUpManager.Instance.StartDoubleCash();
            }
            if (GetComponent<PowerUpSpawn>().power.Name == "Self Revive")
            {
                PlayerHealth.Instance.IncrementSelfRevive();
            }
        }
    }
}
