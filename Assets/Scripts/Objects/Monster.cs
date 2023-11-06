using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Unknown/Create new monster")]
public class Monster : ScriptableObject
{
    [SerializeField] string displayName;

    [TextArea]
    [SerializeField] string description;

    // Base Stats
    [SerializeField] int strength;
    [SerializeField] int toughness;
    [SerializeField] int speed;

    [SerializeField] List<Abilities> abilities;
    [SerializeField] List<Items> items;
}
