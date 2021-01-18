using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string CharacterName;
    public bool Default;
    public Sprite TopDown;
    public Sprite SideView;
    public Animator TopDownAnimation;
    public Animator SideViewAnimation;
}
