using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell Centered Stats")]

public class SpellCenteredStats : ScriptableObject
{
    public string basicName;
    public float lifespan;
    public float manaCost;
    public float cooldown;
    public float recastTime;
    public int stackMaxCount;

    public GameObject centered;

}
