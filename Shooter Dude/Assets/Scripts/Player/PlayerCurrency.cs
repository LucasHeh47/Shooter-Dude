using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCurrency : MonoBehaviour
{

    public static PlayerCurrency Instance;

    public TextMeshProUGUI CurrencyText;

    public float money = 100;
    public float multiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        CurrencyText.SetText("$" + money.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectMoney(float amt)
    {
        money += amt * multiplier;
        CurrencyText.SetText("$" + money.ToString());
    }

}
