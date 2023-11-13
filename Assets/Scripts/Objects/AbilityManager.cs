using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager
{
    public Abilities ability { get; set; }
    
    public AbilityManager(Abilities _ability) { 
        ability = _ability;
    }
}
