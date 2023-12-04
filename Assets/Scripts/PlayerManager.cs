using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private MonsterObject playerObject;
    public MonsterManager PlayerObject { get; set; }
    [SerializeField] private Dictionary<Items, int> items = new Dictionary<Items, int>();
    public TMP_Text Health;
    public TMP_Text Armor;
    public TMP_Text Strength;
    public TMP_Text Toughness;
    public TMP_Text Speed;
    public TMP_Text Crit;
    public TMP_Text AbilitiesText;
    public TMP_Text Items;
    public TMP_Text Cooldown;
    public TMP_Text Count;


    void Start()
    {
        PlayerObject = new MonsterManager(playerObject, playerObject.Level) ;
        // Input ESC to open/close pause menu
        // Input E to open/close player inventory
        // Use player.Stats.Strengh, player.Stats.Toughness, player.Stats.Speed for showing base stats dynamically
        // Use player.HP and player.AR to get current health and armor
        // Use player.MaxHealth and player.MaxArmor to get the max health and armor
        // Use player.CritRate to get critical chance
        // Use player.Stats.Abilities to get the abilities
        // Use items to get both the items and quantity

        Health.SetText("Health: " + PlayerObject.HP + "");
        Armor.SetText("Armor: " + PlayerObject.AR + "");
        Strength.SetText("Strength: " + PlayerObject.Monster.Strength + "");
        Toughness.SetText("Toughness: " + PlayerObject.Monster.Toughness + "");
        Speed.SetText("Speed: " + PlayerObject.Monster.Speed + "");
        Crit.SetText("Crit Chance: " + PlayerObject.CritRate + "%");
        AbilitiesText.SetText("");
        Cooldown.SetText("");
        for (int i = 0; i < PlayerObject.Monster.Abilities.Count; i++)
        {
            
            AbilitiesText.SetText("" + AbilitiesText.text + "" + PlayerObject.Monster.Abilities[i].Name + "   CD: " + PlayerObject.Monster.Abilities[i].Cooldown + "\n");
        }
        //Items.SetText("" + items + " ");
    }
}
