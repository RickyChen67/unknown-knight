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
    [SerializeField] bool isPlayer;
    [SerializeField] TMP_Text currentMaxHP;
    [SerializeField] TMP_Text currentMaxAR;

    public void SetData(MonsterManager monster)
    {
        nameText.SetText(monster.Stats.Name);
        levelText.SetText("Lvl " + monster.Level);
        hpBar.SetHP((float) monster.HP / (float) monster.MaxHealth);
        if (monster.MaxArmor > 0)
            arBar.SetAR((float) monster.AR / (float) monster.MaxArmor);
        else 
            arBar.SetAR(0);

        if (isPlayer)
        {
            currentMaxHP.SetText(monster.HP + "/" + monster.MaxHealth);
            currentMaxAR.SetText(monster.AR + "/" + monster.MaxArmor);
        }
    }
}
