using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffect
{

}

[CreateAssetMenu(fileName = "Ability", menuName = "Unknown/Create new ability")]
public class AbilityObject : ScriptableObject
{
    [SerializeField] string abilityName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite effect;
    [SerializeField] float damageAgainstHP;
    [SerializeField] float damageAgainstArmor;
    [SerializeField] int cooldown;
    [SerializeField] StatusEffect statusEffect;


    public string Name { get { return abilityName; } }
    public string Description { get { return description; } }
    public Sprite Effect { get { return effect; } }
    public float PowerAgainstHP { get { return damageAgainstHP; } }
    public float PowerAgainstArmor { get { return damageAgainstArmor; } }
    public int Cooldown { get { return cooldown; } }
    public StatusEffect StatusEffect { get { return statusEffect; } }
}
