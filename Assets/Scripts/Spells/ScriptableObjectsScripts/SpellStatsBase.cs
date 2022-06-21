using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStatsBase : ScriptableObject
{
    public string spellName;
    public string instantiationType;
    public float lifespan;
    public float manaCost;
    public float cooldown;
    public float recastTime;
    public int stackMaxCount;
    
    public GameObject spellVfx;
}
