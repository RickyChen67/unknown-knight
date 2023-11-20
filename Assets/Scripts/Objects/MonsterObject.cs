using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Unknown/Create new monster")]
public class MonsterObject : ScriptableObject
{
    [SerializeField] string monsterName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite monster;
    [SerializeField] AnimatorController animator;

    [SerializeField] bool hasArmor;
    [SerializeField] int level;

    // Base Stats
    [SerializeField] int strength;
    [SerializeField] int toughness;
    [SerializeField] int speed;

    [SerializeField] List<Ability> abilities;
    [SerializeField] List<LearnableAbilities> learnableAbilities;

    public string Name { get { return monsterName; } }
    public string Description { get { return description; } }
    public Sprite Monster { get { return monster; } }
    public AnimatorController Animator { get { return animator; } }
    public bool HasArmor { get { return hasArmor; } }
    public int Level { get { return level; } }
    public int Strength { get { return strength; } }
    public int Toughness { get { return toughness; } }
    public int Speed { get { return speed; } }
    public List<Ability> Abilities { get { return abilities; } }
    public List<LearnableAbilities> LearnableAbilities { get { return learnableAbilities; } }
}

[Serializable]
public class LearnableAbilities
{
    public Ability ability;
    public int level;
}