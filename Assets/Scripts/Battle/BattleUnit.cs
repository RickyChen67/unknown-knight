using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] MonsterObject monster;
    [SerializeField] int level;
    [SerializeField] bool isPlayer;
    [SerializeField] Animator animator;

    public MonsterManager Monster { get; set; }

    public void SetUp()
    {
        //level = Monster.Monster.Level;
        Monster = new MonsterManager(monster, level);
        if (!isPlayer)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Image>().sprite = Monster.Monster.Monster;
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = Monster.Monster.Animator;
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Hurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

    public void Dead()
    {
        GetComponent<Image>().enabled = false;
    }
}