using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell Projectile Stats")]

public class SpellProjectileStats : ScriptableObject
{
    public string basicName;
    public float manaCost;
    public float cooldown;
    public float recastTime;
    public int stackMaxCount;
    public bool extraScript;
    public string scriptName;
}
