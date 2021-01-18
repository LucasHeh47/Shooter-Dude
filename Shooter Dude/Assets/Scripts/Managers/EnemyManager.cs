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

    public int Kills;

    public int enemysThisRound;
    public int enemysLeft;
    public int enemysRoundOne;
    public float enemysPerRoundMultiplier;

    public int EnemysOnMap = 0;
    public int Round = 0;

    public Enemy[] AllEnemys;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Kills = 0;
        for(int i = 0; i < AllEnemys.Length; i++)
        {
            AllEnemys[i].MaxHealth = AllEnemys[i].DefaultMaxHealth;
        }
    }

    public void IncKills()
    {
        Kills++;
        if(Kills == 50 && GlobalManager.Instance.CurrentChallenge.Name == "Slayer")
        {
            GlobalManager.Instance.finishedChallenge = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemysOnMap == 0 && enemysLeft == 0 && !startingRound)
        {
            StartCoroutine(NewRound());
        }
    }

    IEnumerator StartRound()
    {
        for(int i = 0; i < enemysThisRound; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemy, SpawnPoints[Random.Range(0, SpawnPoints.Length)], transform.rotation);
        }
    }

    IEnumerator NewRound()
    {
        startingRound = true;
        PlayerCurrency.Instance.CollectMoney(10f + Round*10f);
        Round++;
        if (Round == 10 && GlobalManager.Instance.CurrentChallenge.Name == "Survivor")
        {
            GlobalManager.Instance.finishedChallenge = true;
        }
        if (Round == 30 && GlobalManager.Instance.CurrentChallenge.Name == "Expert")
        {
            GlobalManager.Instance.finishedChallenge = true;
        }
        roundText.SetText(Round.ToString());
        if (Round == 1)
        {
            enemysThisRound = enemysRoundOne;
        }
        else
        {
            enemysThisRound = (int) (enemysThisRound * enemysPerRoundMultiplier);
        }
        enemysLeft = enemysThisRound;
        if(Round < 15) enemy.GetComponent<EnemyHealth>().IncreaseHealth();
        yield return new WaitForSeconds(10);
        StartCoroutine(StartRound());
        startingRound = false;
    }
}
