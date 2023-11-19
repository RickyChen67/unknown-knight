using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public MonsterObject Stats { get; set; }

    public int HP { get; set; }
    public int AR { get; set; }

    public Player(MonsterObject stats)
    {
        Stats = stats;
    }

    public int MaxHealth { get { return Mathf.FloorToInt(Stats.Toughness * 1.5f) + 10; } }
    public int MaxArmor { get { if (!Stats.HasArmor) return 0; return Mathf.FloorToInt(Stats.Toughness) + 10; } }
    public float CritRate { get { return Stats.Speed * 0.5f; } }

    public int RemainingStatPoints { get { return  (Stats.Level * 2 + 30) - (Stats.Strength + Stats.Toughness + Stats.Speed);  } }

    public List<Ability> Abilities { get {  return Stats.Abilities; } }
}
