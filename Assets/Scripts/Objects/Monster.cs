using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Unknown/Create new monster")]
public class Monster : ScriptableObject
{
    public string monsterName;

    [TextArea]
    public string description;

    public Sprite sprite;

    public int currentHealth;
    public int maxHealth;
    public int currentArmor;
    public int maxArmor;
    public float criticalChance;
    
    // Base Stats
    public int strength;
    public int toughness;
    public int speed;

    public List<Abilities> abilities;
    public List<Items> items;
}
