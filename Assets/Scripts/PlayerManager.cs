using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private MonsterObject playerObject;
    private Player player;
    [SerializeField] private Dictionary<Items, int> items = new Dictionary<Items, int>();

    void Start()
    {
        player = new Player(playerObject);
    }

    private void Update()
    {
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
