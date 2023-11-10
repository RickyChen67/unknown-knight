using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    Physical,
    Fire,
    Water,
    Electric,
    Earth,
    Poison,

}

[CreateAssetMenu(fileName = "Ability", menuName = "Unknown/Create new ability")]
public class Abilities : ScriptableObject
{
    public string abilityName;

    [TextArea]
    public string description;

    public Sprite effect;
    public float cooldown;
    public AbilityType abilityType;
}
