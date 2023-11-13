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
    [SerializeField] string abilityName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite effect;
    [SerializeField] float powerAgainstHP;
    [SerializeField] float powerAgainstArmor;
    [SerializeField] int cooldown;
    [SerializeField] AbilityType abilityType;
    

    public string Name { get { return abilityName; } }
    public string Description { get { return description; } }
    public Sprite Effect { get { return effect; } }
    public float PowerAgainstHP { get {  return powerAgainstHP; } }
    public float PowerAgainstArmor { get {  return powerAgainstArmor; } }
    public int Cooldown { get {  return cooldown; } }
    public AbilityType Type { get {  return abilityType; } }
}
