using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{

    public Sprite EnemyImage;
    public string EnemyName;
    public float MovementSpeed;
    public float Damage;
    public float AttackRate;
    public float MaxHealth;
    public float DefaultMaxHealth;
    public float HealthMultiplier;

}
