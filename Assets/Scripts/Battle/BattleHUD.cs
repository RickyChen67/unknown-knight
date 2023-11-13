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

    [SerializeField] MonsterManager monster;

    public void SetData(MonsterManager _monster)
    {
        monster = _monster;
        nameText.SetText(_monster.Stats.Name);
        levelText.SetText("Lvl " + _monster.Level);
        hpBar.SetHP((float) _monster.HP / (float) _monster.MaxHealth);
        if (_monster.MaxArmor > 0)
            arBar.SetAR((float) _monster.AR / (float) _monster.MaxArmor);
        else 
            arBar.SetAR(0);

        if (isPlayer)
        {
            currentMaxHP.SetText(_monster.HP + "/" + _monster.MaxHealth);
            currentMaxAR.SetText(_monster.AR + "/" + _monster.MaxArmor);
        }
    }

    public void UpdateAR()
    {
        arBar.SetAR((float)monster.AR / (float)monster.MaxArmor);
        if (isPlayer)
        {
            currentMaxHP.SetText(monster.HP + "/" + monster.MaxHealth);
            currentMaxAR.SetText(monster.AR + "/" + monster.MaxArmor);
        }
    }

    public void UpdateHP()
    {
        hpBar.SetHP((float)monster.HP / (float)monster.MaxHealth);
        if (isPlayer)
        {
            currentMaxHP.SetText(monster.HP + "/" + monster.MaxHealth);
            currentMaxAR.SetText(monster.AR + "/" + monster.MaxArmor);
        }
    }
}
