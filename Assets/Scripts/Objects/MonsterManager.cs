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
    public int defendAR;

    public MonsterManager(Monster _stats, int _level)
    {
        Stats = _stats;
        Level = _level;
        if (Level == 1) { statPoints = 2; }
        HP = MaxHealth;
        AR = MaxArmor;

        //AbilityList = new List<AbilityManager>();
        //foreach (var ability in _stats.Abilities)
        //{
        //    AbilityList.Add(new AbilityManager(ability));
        //    //if (ability.Level <= level)
        //    //    AbilityList.Add(new AbilityManager(ability.Ability));
        //}
    }

    public int MaxHealth { get { return Mathf.FloorToInt(Stats.Toughness * 1.5f) + 10; } }
    public int MaxArmor { get { if (Stats.Armor <= 0) return 0; return Mathf.FloorToInt(Stats.Toughness) + 10; } }
    public float CritRate {  get { return Stats.Speed * 0.5f; } }

    public int BasicAttack { get { return Mathf.FloorToInt(Stats.Strength); } }
    public string BasicAttackDescription { get { return $"Basic attack. Deals {BasicAttack} AR damage and {Mathf.FloorToInt(BasicAttack * 0.5f)} HP damage to armored enemies, {BasicAttack} HP damage otherwise"; } }

    public int Defend {  get { return Mathf.FloorToInt(MaxArmor * 0.5f);  } }
    public string DefendDescription {  get { return $"Raise up your shield and gain {Defend} temporary AR";  } }

    public bool TakeDamage(MonsterManager attacker)
    {
        int damage = Mathf.FloorToInt(attacker.BasicAttack * Random.Range(0.9f, 1f));
        Debug.Log(attacker.Stats.Strength);
        Debug.Log(damage);
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

    public void DefendAction()
    {
        defendAR = AR;
        AR += Defend;
        Debug.Log(AR);
    }

    public void PostDefend()
    {
        if (AR > 0 && defendAR < AR)
        {
            AR -= Defend;
            if (AR <= 0)
            {
                AR = 0;
            }
        }
    }
}
