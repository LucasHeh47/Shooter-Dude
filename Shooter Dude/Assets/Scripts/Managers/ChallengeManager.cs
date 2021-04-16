using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChallengeManager : MonoBehaviour
{

    public static ChallengeManager Instance;

    public TextMeshProUGUI goalText;
    public TextMeshProUGUI rewardText;

    public Challenge[] AllChallenges;
    public Challenge CurrentChallenge;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (GlobalManager.Instance.CurrentChallenge != null) CurrentChallenge = GlobalManager.Instance.CurrentChallenge;
        if (CurrentChallenge == null || GlobalManager.Instance.finishedChallenge)
        {
            if (GlobalManager.Instance.finishedChallenge) GlobalManager.Instance.finishedChallenge = false;
            FinishedChallenge();
        }
        goalText.SetText(CurrentChallenge.Objective);
        rewardText.SetText(CurrentChallenge.ExpReward + " Experience");
        GlobalManager.Instance.CurrentChallenge = CurrentChallenge;

        GlobalManager.Instance.SaveToPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishedChallenge()
    {
        if (CurrentChallenge != null)
        {
            ExpManager.Instance.UpdateExp(CurrentChallenge.ExpReward);
            ExpManager.Instance.UpdateUI();
        }
        CurrentChallenge = AllChallenges[Random.Range(0, AllChallenges.Length)];
        goalText.SetText(CurrentChallenge.Objective);
        rewardText.SetText(CurrentChallenge.ExpReward + " Experience");
    }

}
