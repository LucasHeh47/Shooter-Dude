using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Gun : ScriptableObject
{

    public Sprite GunImage;
    public string GunName;

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

}
