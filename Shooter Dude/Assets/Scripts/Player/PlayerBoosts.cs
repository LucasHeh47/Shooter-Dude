using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosts : MonoBehaviour
{

    public static PlayerBoosts Instance;

    public bool ReloadSpeed = false;
    public bool MovementSpeed = false;
    public bool IncreaseHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        ReloadSpeed = false;
        MovementSpeed = false;
        IncreaseHealth = false;

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateReloadSpeed()
    {
        if (!ReloadSpeed)
        {
            ReloadSpeed = true;
            PlayerGun.Instance.ReloadSpeed = 2.00f;
        }
    }

    public void ActivateMovementSpeed()
    {
        if (!MovementSpeed)
        {
            MovementSpeed = true;
            PlayerMovement.Instance.MovementSpeed *= 1.5f;
        }
    }

    public void ActivateIncreaseHealth()
    {
        if (!IncreaseHealth)
        {
            IncreaseHealth = true;
            PlayerHealth.Instance.slider.maxValue *= 2.5f;
        }
    }

}
