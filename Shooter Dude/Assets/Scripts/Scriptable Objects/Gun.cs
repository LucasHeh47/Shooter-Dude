using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{

    public float Price;
    public float RestockPrice;
    public AudioClip ShootSound;
    public Sprite GunImage;
    public Sprite GunImageInvView;
    public Sprite ProjectileImage;
    public string GunName;
    public bool DefaultGun = false;
    public float BulletSpeed;
    public float ReloadTime;
    public int ClipSize;
    public int AmmoInClip;
    public int Ammo;
    public int CurrentAmmo;
    public bool Pierces;

    public GunManager.RarityTypes Rarity;

    // COMMON
    public float CommonDamage;
    public float CommonFireRate;
    public float CommonRange;

    // UNCOMMON
    public float UnCommonDamage;
    public float UnCommonFireRate;
    public float UnCommonRange;

    // RARE
    public float RareDamage;
    public float RareFireRate;
    public float RareRange;

    // EPIC
    public float EpicDamage;
    public float EpicFireRate;
    public float EpicRange;

    // LEGENDARY
    public float LegendaryDamage;
    public float LegendaryFireRate;
    public float LegendaryRange;

    public float CommonToUnCommonCost;
    public float UnCommonToRareCost;
    public float RareToEpicCost;
    public float EpicToLegendaryCost;

}
