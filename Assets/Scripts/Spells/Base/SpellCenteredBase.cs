using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SpellCenteredBase : SpellBase
{
    public GameObject spellVfx;

    public override void GetSpellStats(ScriptableObject _spellStats)
    {
        centeredStats = (SpellCenteredStats)_spellStats;
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
        if (Input.GetKeyDown(keyCode))
        {
            if (canRecast && stackCount > 0)
            {
                canRecast = false;
                return true;
            }
        }
        return false;
    }

    public override void CastSpell(GameObject player, GameObject firePoint)
    {
        recastTimer = recastTimerMax;
        Vector3 spawnPoint = player.transform.position;
        GameObject vfx = Instantiate(spellVfx, spawnPoint, player.transform.rotation);
        stackCount--;
        Destroy(vfx, centeredStats.lifespan);

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
        return cursorStats.spellName;
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
        cooldownBase = centeredStats.cooldown;
        manaCostBase = centeredStats.manaCost;
        recastTimerMaxBase = centeredStats.recastTime;
        stackMaxCountBase = centeredStats.stackMaxCount;
        lifespanBase = centeredStats.lifespan;
        spellVfx = centeredStats.spellVfx;
    }

    public override void AssignToZero()
    {
        cooldownBase = 0f;
        manaCostBase = 0f;
        recastTimerMaxBase = 0f;
        stackMaxCountBase = 0;
        lifespanBase = 0f;
        spellVfx = null;
    }

    public override void AssignFromBase()
    {
        cooldown = cooldownBase;
        manaCost = manaCostBase;
        recastTimer = recastTimerMaxBase;
        recastTimerMax = recastTimerMaxBase;
        stackMaxCount = stackMaxCountBase;
        lifespan = lifespanBase;
    }

}
