using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{

    public static ShopManager Instance;

    public TextMeshProUGUI UZIPrice;
    public TextMeshProUGUI M16Price;
    public TextMeshProUGUI AK47Price;
    public TextMeshProUGUI RemingtonPrice;
    public TextMeshProUGUI SniperPrice;
    public TextMeshProUGUI PistolPrice;

    public TextMeshProUGUI UZIUpgradePrice;
    public TextMeshProUGUI M16UpgradePrice;
    public TextMeshProUGUI AK47UpgradePrice;
    public TextMeshProUGUI RemingtonUpgradePrice;
    public TextMeshProUGUI SniperUpgradePrice;
    public TextMeshProUGUI PistolUpgradePrice;

    public GunManager manager;
    public PlayerCurrency currency;

    public bool InRange = true;

    public GameObject GunsTab;
    public GameObject UpgradesTab;
    public GameObject ArmorTab;
    public GameObject BoostsTab;

    public TextMeshProUGUI ReloadSpeedPriceText;
    public TextMeshProUGUI MovementSpeedPriceText;
    public TextMeshProUGUI IncreaseHealthPriceText;
    public float ReloadSpeedPrice;
    public float MovementSpeedPrice;
    public float IncreaseHealthPrice;
    public enum Boosts { ReloadSpeed = 0, MovementSpeed = 1, IncreaseHealth = 2 }

    public TextMeshProUGUI RepairTextPrice;

    public enum ShopTabs { Guns = 0, Upgrades = 1, Armor = 2, Boosts = 3 }

    void Start()
    {

        ReloadSpeedPriceText.SetText("$" + ReloadSpeedPrice.ToString());
        MovementSpeedPriceText.SetText("$" + MovementSpeedPrice.ToString());
        IncreaseHealthPriceText.SetText("$" + IncreaseHealthPrice.ToString());

        UZIPrice.SetText("$" + manager.UZI.Price.ToString());
        AK47Price.SetText("$" + manager.AK47.Price.ToString());
        M16Price.SetText("$" + manager.M16.Price.ToString());
        RemingtonPrice.SetText("$" + manager.Remington.Price.ToString());
        SniperPrice.SetText("$" + manager.Sniper.Price.ToString());
        PistolPrice.SetText("$" + manager.Pistol.Price.ToString());

        UZIUpgradePrice.SetText("$" + PlayerGun.Instance.GetUpgradeCost(manager.UZI).ToString());
        AK47UpgradePrice.SetText("$" + PlayerGun.Instance.GetUpgradeCost(manager.AK47).ToString());
        M16UpgradePrice.SetText("$" + PlayerGun.Instance.GetUpgradeCost(manager.M16).ToString());
        RemingtonUpgradePrice.SetText("$" + PlayerGun.Instance.GetUpgradeCost(manager.Remington).ToString());
        SniperUpgradePrice.SetText("$" + PlayerGun.Instance.GetUpgradeCost(manager.Sniper).ToString());
        PistolUpgradePrice.SetText("$" + PlayerGun.Instance.GetUpgradeCost(manager.Pistol).ToString());

        Instance = this;
    }

    void Update()
    {
        RepairTextPrice.SetText("$" + (((int)PlayerHealth.Instance.armorBar.maxValue - (int)PlayerHealth.Instance.armorBar.value) * 20).ToString());
    }

    public void PurchaseBoost(int boost)
    {
        if(boost == Boosts.ReloadSpeed.GetHashCode() && currency.money >= ReloadSpeedPrice)
        {
            currency.money -= ReloadSpeedPrice;
            PlayerBoosts.Instance.ActivateReloadSpeed();
            currency.CurrencyText.SetText("$" + currency.money.ToString());
        }
        if (boost == Boosts.MovementSpeed.GetHashCode() && currency.money >= MovementSpeedPrice)
        {
            currency.money -= MovementSpeedPrice;
            PlayerBoosts.Instance.ActivateMovementSpeed();
            currency.CurrencyText.SetText("$" + currency.money.ToString());
        }
        if (boost == Boosts.IncreaseHealth.GetHashCode() && currency.money >= IncreaseHealthPrice)
        {
            currency.money -= IncreaseHealthPrice;
            PlayerBoosts.Instance.ActivateIncreaseHealth();
            currency.CurrencyText.SetText("$" + currency.money.ToString());
        }
    }

    void UpdateUpgradeText()
    {
        if (PlayerGun.Instance.GetUpgradeCost(manager.UZI) != 58353)
        {
            UZIUpgradePrice.SetText(PlayerGun.Instance.GetUpgradeCost(manager.UZI).ToString());
        }
        else
        {
            UZIUpgradePrice.SetText("Maxed Out");
        }
        if (PlayerGun.Instance.GetUpgradeCost(manager.AK47) != 58353)
        {
            AK47UpgradePrice.SetText(PlayerGun.Instance.GetUpgradeCost(manager.AK47).ToString());
        }
        else
        {
            AK47UpgradePrice.SetText("Maxed Out");
        }
        if (PlayerGun.Instance.GetUpgradeCost(manager.M16) != 58353)
        {
            M16UpgradePrice.SetText(PlayerGun.Instance.GetUpgradeCost(manager.M16).ToString());
        }
        else
        {
            M16UpgradePrice.SetText("Maxed Out");
        }
        if (PlayerGun.Instance.GetUpgradeCost(manager.Remington) != 58353)
        {
            RemingtonUpgradePrice.SetText(PlayerGun.Instance.GetUpgradeCost(manager.Remington).ToString());
        }
        else
        {
            RemingtonUpgradePrice.SetText("Maxed Out");
        }
        if (PlayerGun.Instance.GetUpgradeCost(manager.Sniper) != 58353)
        {
            SniperUpgradePrice.SetText(PlayerGun.Instance.GetUpgradeCost(manager.Sniper).ToString());
        }
        else
        {
            SniperUpgradePrice.SetText("Maxed Out");
        }
        if (PlayerGun.Instance.GetUpgradeCost(manager.Pistol) != 58353)
        {
            PistolUpgradePrice.SetText(PlayerGun.Instance.GetUpgradeCost(manager.Pistol).ToString());
        }
        else
        {
            PistolUpgradePrice.SetText("Maxed Out");
        }
    }

    void UpdatePurchaseText()
    {
        UZIPrice.SetText(manager.UZI.Price.ToString());
        AK47Price.SetText(manager.AK47.Price.ToString());
        M16Price.SetText(manager.M16.Price.ToString());
        RemingtonPrice.SetText(manager.Remington.Price.ToString());
        SniperPrice.SetText(manager.Sniper.Price.ToString());
        PistolPrice.SetText(manager.Pistol.Price.ToString());
    }

    public void PurchaseGun(Gun gun)
    {
        if(currency.money >= gun.Price && !PlayerGun.Instance.DoesHaveGun(gun))
        {
            currency.money -= gun.Price;
            currency.CurrencyText.SetText("$" + currency.money.ToString());
            PlayerGun.Instance.AddNewGun(gun);
        }
    }

    public void UpgradeGun(Gun gun)
    {
        if(currency.money >= PlayerGun.Instance.GetUpgradeCost(gun))
        {
            currency.money -= PlayerGun.Instance.GetUpgradeCost(gun);
            currency.CurrencyText.SetText("$" + currency.money.ToString());
            PlayerGun.Instance.UpgradeGunRarity(gun);
            UpdateUpgradeText();
        }
    }

    public void UpdateTab(int tab)
    {
        if(ShopTabs.Upgrades.GetHashCode() == tab)
        {
            GunsTab.SetActive(false);
            ArmorTab.SetActive(false);
            BoostsTab.SetActive(false);
            UpgradesTab.SetActive(true);
        }
        if (ShopTabs.Guns.GetHashCode() == tab)
        {
            GunsTab.SetActive(true);
            ArmorTab.SetActive(false);
            BoostsTab.SetActive(false);
            UpgradesTab.SetActive(false);
        }
        if (ShopTabs.Armor.GetHashCode() == tab)
        {
            GunsTab.SetActive(false);
            ArmorTab.SetActive(true);
            BoostsTab.SetActive(false);
            UpgradesTab.SetActive(false);
        }
        if (ShopTabs.Boosts.GetHashCode() == tab)
        {
            GunsTab.SetActive(false);
            ArmorTab.SetActive(false);
            BoostsTab.SetActive(true);
            UpgradesTab.SetActive(false);
        }
    }
    
    public void PurchaseArmor(int amt)
    {
        if((int)PlayerHealth.Instance.armorBar.value+amt <= PlayerHealth.Instance.armorBar.maxValue)
        {
            if (PlayerCurrency.Instance.money >= amt * 20)
            {
                PlayerCurrency.Instance.money -= amt * 20;
                PlayerHealth.Instance.armorBar.value += amt;
            }
        }
        currency.CurrencyText.SetText("$" + currency.money.ToString());
    }

    public void RepairArmor()
    {
        int amt = (int) PlayerHealth.Instance.armorBar.maxValue - (int) PlayerHealth.Instance.armorBar.value;
        if (PlayerCurrency.Instance.money >= amt * 20)
        {
            PlayerCurrency.Instance.money -= amt * 20;
            PlayerHealth.Instance.armorBar.value += amt;
        }
        currency.CurrencyText.SetText("$" + currency.money.ToString());
    }

}
