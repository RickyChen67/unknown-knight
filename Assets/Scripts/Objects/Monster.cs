using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public string Name { get { return monsterName; } }
    public string Description { get { return description; } }
    public Sprite Sprite { get { return sprite; } }
    public int Health { get {  return maxHealth; } }
    public int Armor { get {  return maxArmor; } }
    public int Strength { get {  return strength; } }
    public int Toughness { get {  return toughness; } }
    public int Speed { get { return speed; } }
}
