using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public static PowerUpManager Instance;

    public PowerUp[] powerUps;
    public PowerUp DoubleCash;
    public PowerUp Medic;
    public PowerUp MaxAmmo;

    public GameObject PowerUpObj;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPowerUp(PowerUp powerUp, Vector3 pos)
    {
        GameObject obj = Instantiate(PowerUpObj, pos, transform.rotation);
        obj.GetComponent<PowerUpSpawn>().power = powerUp;
    }

    public void SpawnRandomPowerUp(Vector3 pos)
    {
        PowerUp powerUp = powerUps[Random.Range(0, powerUps.Length)];
        Debug.Log(powerUp.Name);
        GameObject obj = Instantiate(PowerUpObj, pos, transform.rotation);
        obj.GetComponent<PowerUpSpawn>().power = powerUp;
    }

}
