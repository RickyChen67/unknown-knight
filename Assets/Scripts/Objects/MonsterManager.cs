using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager
{
    public MonsterObject Monster { get; set; }
    public int Level { get; set; }
    int statPoints;

    public int HP { get; set; }
    public int AR { get; set; }
    public int defendAR;

    public MonsterManager(MonsterObject _stats, int _level = 1)
    {
        Monster = _stats;
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
    
    public int MaxHealth { get { return Mathf.FloorToInt(Monster.Toughness * 1.5f) + 10; } }
    public int MaxArmor { get { if (!Monster.HasArmor) return 0; return Mathf.FloorToInt(Monster.Toughness) + 10; } }
    public float CritRate {  get { return Monster.Speed * 0.5f; } }

    public int BasicAttack { get { return Mathf.FloorToInt(Monster.Strength); } }
    public string BasicAttackDescription { get { return $"Basic attack. Deals {BasicAttack} AR damage to armored enemies, {BasicAttack} HP damage otherwise"; } }

    public int Defend {  get { return Mathf.FloorToInt(MaxArmor * 0.5f);  } }
    public string DefendDescription {  get { return $"Raise up your shield and gain {Defend} temporary AR";  } }

    public bool TakeDamage(MonsterManager attacker)
    {
        int damage = Mathf.FloorToInt(attacker.BasicAttack * Random.Range(0.9f, 1f));
        Debug.Log(attacker.Monster.Strength);
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
        if (AR > MaxArmor)
        {
            AR = MaxArmor;
        }
        else if (AR > 0 && defendAR > AR)
        {
            AR -= Defend;
            if (AR <= 0)
            {
                AR = 0;
            }
        }
    }
}
