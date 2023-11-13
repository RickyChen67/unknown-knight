using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUD;
    [SerializeField] BattleUnit monsterUnit;
    [SerializeField] BattleHUD monsterHUD;

    private void Start()
    {
        SetupBattle();
    }

    public void SetupBattle()
    {
        playerUnit.SetUp();
        monsterUnit.SetUp();
        playerHUD.SetData(playerUnit.Monster);
        monsterHUD.SetData(monsterUnit.Monster);
    }
}
