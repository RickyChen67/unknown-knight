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
    public int MaxArmor { get { if (Stats.Armor <= 0) return 0; return Mathf.FloorToInt(Stats.Toughness) + 10; } }
    public float CritRate {  get { return Stats.Speed * 0.5f; } }

    public int BasicAttack { get { return Mathf.FloorToInt(Stats.Strength); } }
    public string BasicAttackDescription { get { return $"Basic attack. Deals {Mathf.FloorToInt(Stats.Strength)} AR damage and {Mathf.FloorToInt(Stats.Strength * 0.5f)} HP damage to armored enemies. {Mathf.FloorToInt(Stats.Strength)} HP damage otherwise."; } }

    public bool TakeDamage(MonsterManager attacker)
    {
        int damage = Mathf.FloorToInt(attacker.Stats.Strength * Random.Range(0.9f, 1f));
        if (AR > 0)
        {
            AR -= damage;
            if (AR <= 0)
            {
                AR = 0;
            }
        }
        else
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                return true;
            }
        }
        return false;

    }
}
