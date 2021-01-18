using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Power Up", menuName = "Power Up")]
public class PowerUp : ScriptableObject
{
    public Sprite Image;
    public string Name;
    public bool Instant;
    public float Seconds;
}
