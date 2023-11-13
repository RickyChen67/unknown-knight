using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] Monster monsterBase;
    [SerializeField] int level;
    [SerializeField] bool isPlayer;

    public MonsterManager Monster {  get; set; }

    public void SetUp()
    {
        Monster = new MonsterManager(monsterBase, level);
        if (!isPlayer)
            GetComponent<Image>().sprite = Monster.Stats.Sprite;
    }
}
