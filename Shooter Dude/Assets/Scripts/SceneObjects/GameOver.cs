using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI roundsText;

    // Start is called before the first frame update
    void Start()
    {
        roundsText.SetText("Rounds Survived: " + (GlobalManager.Instance.RoundMadeTo-1).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
