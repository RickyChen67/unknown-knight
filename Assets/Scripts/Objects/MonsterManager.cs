using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager
{
    public Monster Stats { get; set; }
    public int Level { get; set; }
    int statPoints;

    public int HP { get; set; }
    public int AR { get; set; }
    public List<AbilityManager> AbilityList { get; set; }

    public MonsterManager(Monster _stats, int _level)
    {
        Stats = _stats;
        Level = _level;
        if (Level == 1) { statPoints = 2; }
        HP = MaxHealth;
        AR = MaxArmor;

        AbilityList = new List<AbilityManager>();
        foreach (var ability in _stats.Abilities)
        {
            AbilityList.Add(new AbilityManager(ability));
            //if (ability.Level <= level)
            //    AbilityList.Add(new AbilityManager(ability.Ability));
        }
    }

    public int MaxHealth { get { return Mathf.FloorToInt(Stats.Toughness * 1.5f) + 10; } }
    public int MaxArmor { get { if (Stats.Armor < 0) return 0; return Mathf.FloorToInt(Stats.Toughness) + 10; } }
    public float CritRate {  get { return Stats.Speed * 0.5f; } }
}
