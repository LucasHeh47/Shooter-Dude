using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GlobalManager : MonoBehaviour
{

    public static GlobalManager Instance;
    public AudioManager audioManager;

    PlayerData playerData;

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

        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Load();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Load()
    {
        Debug.Log("Open");
        playerData = PlayerDataManager.LoadData();

        if (playerData == null)
        {
            playerData = new PlayerData();
        }
        else
        {
            LoadFromPlayerData();
        }
        Debug.Log("End of Open");
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Close");
        PlayerDataManager.SaveData(playerData);
        Debug.Log("End of Close");
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SaveToPlayerData()
    {
        playerData.CurrentChallenge = CurrentChallenge;
        playerData.PlayerTotalExp = PlayerTotalExp;
        playerData.PlayerExp = PlayerExp;
        playerData.PlayerLevel = PlayerLevel;
        playerData.PlayerExpToLevelUp = PlayerExpToLevelUp;
    }

    public void LoadFromPlayerData()
    {
        CurrentChallenge = playerData.CurrentChallenge;
        PlayerTotalExp = playerData.PlayerTotalExp;
        PlayerExp = playerData.PlayerExp;
        PlayerExpToLevelUp = playerData.PlayerExpToLevelUp;
        PlayerLevel = playerData.PlayerLevel;
    }

}

[System.Serializable]
public class PlayerData
{

    public int PlayerLevel;
    public int PlayerExpToLevelUp;
    public int PlayerExp;
    public int PlayerTotalExp;
    public Challenge CurrentChallenge;

    /*public PlayerData()
    {
        PlayerLevel = GlobalManager.Instance.PlayerLevel;
        PlayerExpToLevelUp = GlobalManager.Instance.PlayerExpToLevelUp;
        PlayerExp = GlobalManager.Instance.PlayerExp;
        PlayerTotalExp = GlobalManager.Instance.PlayerTotalExp;
        CurrentChallenge = GlobalManager.Instance.CurrentChallenge;
    }*/

}
