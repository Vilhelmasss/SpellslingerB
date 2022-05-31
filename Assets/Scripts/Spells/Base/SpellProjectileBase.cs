using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SpellProjectileBase : SpellBase
{
    [SerializeField] private List<InvRuneData> attachedRunes = new List<InvRuneData>(6);   

    public GameObject projectile;

    public override void GetSpellStats(ScriptableObject _spellStats)
    {
        projectileStats = (SpellProjectileStats)_spellStats;
    }

    public override void AdjustForRunes(GameObject go)
    {
//        CommandCenter.Instance.GetComponent<CommandCenter>().AllRunesDictionary();
        CommandCenter.Instance.GetComponent<CommandCenter>().ExecuteAwake("MoreStacks", gameObject);
        CommandCenter.Instance.GetComponent<CommandCenter>().ExecuteAwake("ReduceManaCost", gameObject);
        CommandCenter.Instance.GetComponent<CommandCenter>().ExecuteAwake("DecreaseCooldown", gameObject);


    }

    public override void Update()
    {
        
        RecastTimer();
        RechargeCooldown();
    }


    public override bool AttemptCasting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (canRecast && stackCount > 0)
            {
                return true;
            }
        }
        return false;
    }

    public override void CastSpell(GameObject player, GameObject firePoint)
    {
        Vector3 direction = firePoint.transform.position - player.transform.position;
        GameObject vfx = Instantiate(projectile, firePoint.transform.position + Vector3.up * 0.5f,
            Quaternion.LookRotation(direction));
        stackCount--;    
        Destroy(vfx, projectileStats.lifespan);

    }

    public float GetCooldown()
    {
        return currCooldownTimer;
    }

    public int GetStacks()
    {
        return stackCount;

    }

    public string GetProjectileName()
    {
        return projectileStats.basicName;
    }

    void RecastTimer()
    {
        recastTimer -= Time.deltaTime;
        if (recastTimer < 0)
        {
            recastTimer = recastTimerMax;
            canRecast = true;
        }
    }
    void RechargeCooldown()
    {
        currCooldownTimer -= Time.deltaTime;
        if (currCooldownTimer < 0)
        {
            currCooldownTimer = cooldown;
            AddStack();
        }

    }

    void AddStack(int addedAmount = 1)
    {
        if (stackCount < stackMaxCount)
        {
            stackCount += addedAmount;
        }
    }
    public override void AssignToBase()
    {
        cooldownBase = projectileStats.cooldown;
        manaCostBase = projectileStats.manaCost;
        recastTimerMax = projectileStats.recastTime;
        stackMaxCountBase = projectileStats.stackMaxCount;
        lifespanBase = projectileStats.lifespan;
        projectile = projectileStats.projectile;
    }

    public override void AssignToZero()
    {
        cooldownBase = 0f;
        manaCostBase = 0f;
        recastTimerMaxBase = 0f;
        stackMaxCountBase = 0;
        lifespanBase = 0f;
        projectile = null;
    }

    public override void AssignFromBase()
    { 
        cooldown = cooldownBase;
        manaCost = manaCostBase;
        recastTimer = recastTimerMaxBase;
        stackMaxCount = stackMaxCountBase;
        lifespan = lifespanBase;
    }

}
