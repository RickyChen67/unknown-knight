using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private MonsterObject playerObject;
    private Player player;
    [SerializeField] private Dictionary<Items, int> items = new Dictionary<Items, int>();
    public TMP_Text Health;
    public TMP_Text Armor;
    public TMP_Text Strength;
    public TMP_Text Toughness;
    public TMP_Text Speed;
    public TMP_Text Crit;
    public TMP_Text Abilities;
    public TMP_Text Items;



    void Start()
    {
        player = new Player(playerObject);
    }

    private void Update()
    {
        Health.SetText("Health: "+player.HP+"");
        Armor.SetText("Armor: " + player.AR + "");
        Strength.SetText("Strength: " + player.Stats.Strength + "");
        Toughness.SetText("Toughness: " + player.Stats.Toughness + "");
        Speed.SetText("Speed: " + player.Stats.Speed + "");
        Crit.SetText("Critical Chance: " + player.CritRate + "");
        Abilities.SetText("" + player.Stats.Abilities[0].Name + "   Cooldown: "+ player.Stats.Abilities[0].Cooldown+"");


        //Items.SetText("" + items + " ");


        // Input ESC to open/close pause menu
        // Input E to open/close player inventory
        // Use player.Stats.Strengh, player.Stats.Toughness, player.Stats.Speed for showing base stats dynamically
        // Use player.HP and player.AR to get current health and armor
        // Use player.MaxHealth and player.MaxArmor to get the max health and armor
        // Use player.CritRate to get critical chance
        // Use player.Stats.Abilities to get the abilities
        // Use items to get both the items and quantity
    }
}
