using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int level;
    [SerializeField] bool isPlayer;
    [SerializeField] Animator animator;

    public MonsterManager Monster { get; set; }

    public void SetUp(MonsterObject _monster = null)
    {
        //level = Monster.Monster.Level;
        if (!isPlayer)
        {
            Monster = new MonsterManager(_monster, level);
            GetComponent<Image>().enabled = true;
            GetComponent<Image>().sprite = Monster.Monster.Monster;
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = Monster.Monster.Animator;
        }
        else
            Monster = player.GetComponent<PlayerManager>().PlayerObject;
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