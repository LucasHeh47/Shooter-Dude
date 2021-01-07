using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance;

    public Vector3[] SpawnPoints;

    public GameObject enemy;

    public TextMeshProUGUI roundText;

    public bool startingRound = false;

    public float enemysThisRound;
    public int enemysRoundOne;
    public float enemysPerRoundMultiplier;

    public int EnemysOnMap = 0;
    public int Round = 0;

    public Enemy[] AllEnemys;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

        for(int i = 0; i < AllEnemys.Length; i++)
        {
            AllEnemys[i].MaxHealth = AllEnemys[i].DefaultMaxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemysOnMap == 0 && !startingRound)
        {
            StartCoroutine(NewRound());
        }
    }

    void StartRound()
    {
        for(int i = 0; i < enemysThisRound; i++)
        {
            Instantiate(enemy, SpawnPoints[Random.Range(0, SpawnPoints.Length)], transform.rotation);
        }
    }

    IEnumerator NewRound()
    {
        startingRound = true;
        Round++;
        roundText.SetText(Round.ToString());
        if (Round == 1)
        {
            enemysThisRound = enemysRoundOne;
        }
        else
        {
            enemysThisRound *= enemysPerRoundMultiplier;
        }
        if(Round < 15) enemy.GetComponent<EnemyHealth>().IncreaseHealth();
        yield return new WaitForSeconds(10);
        StartRound();
        startingRound = false;
    }
}
