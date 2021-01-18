using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{

    public static GlobalManager Instance;
    public AudioManager audioManager;

    // VARIABLES
    public int PlayerLevel;
    public int PlayerExpToLevelUp;
    public int PlayerExp;
    public int PlayerTotalExp;
    public Challenge CurrentChallenge;

    // NON SAVE VARIABLES
    public int RoundMadeTo;
    public int expToAdd;
    public bool finishedChallenge;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}

public class PlayerData
{

    public int PlayerLevel;
    public int PlayerExpToLevelUp;
    public int PlayerExp;
    public int PlayerTotalExp;
    public Challenge CurrentChallenge;

}
