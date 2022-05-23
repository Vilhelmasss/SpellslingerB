using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell Dash Stats")]

public class SpellDashStats : ScriptableObject
{
    public string dashName;
    public float dashTime;
    public float dashDistance;
    public float manaCost;
    public float cooldown;
    public float recastTime;
    public int stackMaxCount;
    public bool extraScript;
    public string scriptName;
}
