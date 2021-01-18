using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Challenge", menuName = "Challenge")]
public class Challenge : ScriptableObject
{
    public string Name;
    public string Objective;
    public int ExpReward;
}
