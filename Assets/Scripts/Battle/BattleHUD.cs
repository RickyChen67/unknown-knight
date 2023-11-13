using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text levelText;
    [SerializeField] HPBar hpBar;
    [SerializeField] ARBar arBar;

    public void SetData(MonsterManager monster)
    {
        nameText.SetText(monster.Stats.Name);
        Debug.Log("No?");
        levelText.SetText("Lvl " + monster.Level);
        hpBar.SetHP((float) monster.HP / (float) monster.MaxHealth);
        arBar.SetAR((float) monster.AR / (float) monster.MaxArmor);
    }
}
