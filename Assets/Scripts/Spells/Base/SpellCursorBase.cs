using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SpellCursorBase : SpellBase
{
    [SerializeField] private List<InvRuneData> attachedRunes = new List<InvRuneData>(6);

    public GameObject spellVfx;
    
    public override void GetSpellStats(ScriptableObject _spellStats)
    {
        cursorStats = (SpellCursorStats)_spellStats;
    }

    public override void AdjustForRunes(GameObject go)
    {
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
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        recastTimer = recastTimerMax;

        if (Physics.Raycast(_ray, out _hit))
        {
            Vector3 spawnPoint = new Vector3(_hit.point.x, transform.position.y, _hit.point.z);
            GameObject vfx = Instantiate(spellVfx, spawnPoint, player.transform.rotation);
            stackCount--;
            Destroy(vfx, cursorStats.lifespan);
        }


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
        basicName = cursorStats.spellName;
        cooldownBase = cursorStats.cooldown;
        manaCostBase = cursorStats.manaCost;
        recastTimerMaxBase = cursorStats.recastTime;
        stackMaxCountBase = cursorStats.stackMaxCount;
        lifespanBase = cursorStats.lifespan;
        spellVfx = cursorStats.spellVfx;
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
