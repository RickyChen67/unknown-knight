using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Unknown/Create new monster")]
public class Monster : ScriptableObject
{
    [SerializeField] string monsterName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite sprite;

    [SerializeField] int maxHealth;
    [SerializeField] int maxArmor;

    // Base Stats
    [SerializeField] int strength;
    [SerializeField] int toughness;
    [SerializeField] int speed;
    [SerializeField] List<Abilities> abilities;

    public string Name { get { return monsterName; } }
    public string Description { get { return description; } }
    public Sprite Sprite { get { return sprite; } }
    public int Health { get {  return maxHealth; } }
    public int Armor { get {  return maxArmor; } }
    public int Strength { get {  return toughness; } }
    public int Toughness { get {  return toughness; } }
    public int Speed { get { return speed; } }
    public List<Abilities> Abilities { get { return abilities; } }
    //public List<LearnableAbility > LearnableAbilities { get { return learnableAbilities; } }
}

public class LearnableAbility
{
    [SerializeField] Abilities ability;
    [SerializeField] int level;

    public Abilities Ability {  get { return ability;} }
    public int Level { get { return level; } }
}
