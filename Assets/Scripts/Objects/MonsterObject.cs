using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Unknown/Create new monster")]
public class MonsterObject : ScriptableObject
{
    [SerializeField] string monsterName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] GameObject monster;  // Needs to change for image/animator

    [SerializeField] bool hasArmor;
    [SerializeField] int level;

    // Base Stats
    [SerializeField] int strength;
    [SerializeField] int toughness;
    [SerializeField] int speed;

    [SerializeField] List<AbilityObject> abilities;

    public string Name { get { return monsterName; } }
    public string Description { get { return description; } }
    public GameObject Monster { get { return monster; } }
    public bool HasArmor { get { return hasArmor; } }
    public int Level { get { return level; } }
    public int Strength { get { return strength; } }
    public int Toughness { get { return toughness; } }
    public int Speed { get { return speed; } }
    public List<AbilityObject> Abilities { get { return abilities; } }
}
