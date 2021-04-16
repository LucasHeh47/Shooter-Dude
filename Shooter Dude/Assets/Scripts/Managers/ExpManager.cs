using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{

    public static ExpManager Instance;

    public Slider expBar;
    public TextMeshProUGUI lvlTest;

    public int startingExp;

    public bool addingXp;

    public int expToAdd;

    public int PlayerExp;
    public int PlayerExpToLevelUp;
    public int PlayerLevel;
    public int PlayerTotalExp;

    // Start is called before the first frame update
    void Start()
    {
        expToAdd = GlobalManager.Instance.expToAdd;

        PlayerExp = GlobalManager.Instance.PlayerExp;
        PlayerLevel = GlobalManager.Instance.PlayerLevel;
        PlayerExpToLevelUp = GlobalManager.Instance.PlayerExpToLevelUp;
        PlayerTotalExp = GlobalManager.Instance.PlayerTotalExp;

        expBar.maxValue = GlobalManager.Instance.PlayerExpToLevelUp;
        expBar.value = GlobalManager.Instance.PlayerExp;
        lvlTest.SetText(GlobalManager.Instance.PlayerLevel.ToString());

        if (PlayerLevel == 0)
        {
            PlayerLevel = 1;
            PlayerExpToLevelUp = startingExp;
            expBar.maxValue = PlayerExpToLevelUp;
            expBar.value = PlayerExp;
            lvlTest.SetText(PlayerLevel.ToString());
        }

        UpdateExp(expToAdd);

        Instance = this;
        SaveExp();

        expBar.maxValue = GlobalManager.Instance.PlayerExpToLevelUp;
        expBar.value = GlobalManager.Instance.PlayerExp;
        lvlTest.SetText(GlobalManager.Instance.PlayerLevel.ToString());

        GlobalManager.Instance.SaveToPlayerData();
    }

    public void UpdateUI()
    {
        expBar.value = GlobalManager.Instance.PlayerExp;
        lvlTest.SetText(GlobalManager.Instance.PlayerLevel.ToString());
    }

    public void SaveExp()
    {
        GlobalManager.Instance.PlayerExp = PlayerExp;
        GlobalManager.Instance.PlayerLevel = PlayerLevel;
        GlobalManager.Instance.PlayerExpToLevelUp = PlayerExpToLevelUp;
        GlobalManager.Instance.PlayerTotalExp = PlayerTotalExp;
    }

    public void UpdateExp(int exp)
    {
        if (exp <= 0) return;
        Debug.Log("Updating exp... Current exp and level:" + PlayerExp + " " + PlayerLevel);
        PlayerExp += exp;
        PlayerTotalExp += exp;
        if(PlayerExpToLevelUp < PlayerExp)
        {
            bool looping = true;
            while(looping)
            {
                if (PlayerExp < PlayerExpToLevelUp) looping = false;
                if(PlayerExp > PlayerExpToLevelUp) LevelUp();
            }
        }
        expToAdd = 0;
        GlobalManager.Instance.expToAdd = 0;
        UpdateUI();
        Debug.Log("Updated exp... Current exp and level:" + PlayerExp + " " + PlayerLevel);
    }

    public void LevelUp()
    {
        PlayerLevel++;
        PlayerExp -= PlayerExpToLevelUp;
        PlayerExpToLevelUp = (int) (PlayerExpToLevelUp * 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
