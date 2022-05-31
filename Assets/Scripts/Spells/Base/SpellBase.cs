using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{
    public string basicName;

    public float cooldownBase;
    public float manaCostBase;
    public float recastTimerMaxBase;
    public int stackMaxCountBase;
    public float lifespanBase;
    public float speedBase;
    public float damageModBase = 1f;

    public float damageMod;
    public float cooldown;
    public float manaCost;
    public float lifespan;
    public float speed;
    public int stackMaxCount;
    public int stackCount;
    public float currCooldownTimer;
    public float recastTimerMax;
    public float recastTimer;
    public bool canRecast;

    public SpellProjectileStats projectileStats;

    public abstract void GetSpellStats(ScriptableObject _spellStats);

    public abstract void AssignToBase();
    public abstract void AssignToZero();
    public abstract void AssignFromBase();
    public abstract bool AttemptCasting();
    public abstract void AdjustForRunes(GameObject go);
    public abstract void CastSpell(GameObject player, GameObject firePoint);

    public abstract void Update();




}
