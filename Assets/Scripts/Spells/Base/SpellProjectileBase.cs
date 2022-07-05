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
    private GameObject lmao;
    public GameObject spellVfx;
    public List<string> Runes = new List<string>();
    public override void GetSpellStats(ScriptableObject _spellStats)
    {
        projectileStats = (SpellProjectileStats)_spellStats;
    }


    public override void SetRunes(List<string> runes)
    {
        if(runes != null)
        Runes = runes;
    }
    public override void AdjustForRunes(GameObject go)
    {
        lmao = go;
        for (int i = 0; i < Runes.Count; i++)
        {
            CommandCenter.Instance.GetComponent<CommandCenter>().ExecuteAwake(Runes[i], gameObject);
        }

        if (go.transform.localScale.x > 1 )
        {
            spellVfx.transform.localScale += new Vector3(3f, 3f, 3f);
        }

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
        Vector3 direction = firePoint.transform.position - player.transform.position;
        GameObject vfx = Instantiate(spellVfx, firePoint.transform.position + Vector3.up * 0.5f,
            Quaternion.LookRotation(direction));
        if (lmao.transform.localScale.x > 1)
        {
//            vfx.transform.localScale += new Vector3(3f, 3f, 3f);    
        }
        stackCount--;    
        Destroy(vfx, projectileStats.lifespan);

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
        basicName = projectileStats.spellName;
        cooldownBase = projectileStats.cooldown;
        manaCostBase = projectileStats.manaCost;
        recastTimerMax = projectileStats.recastTime;
        stackMaxCountBase = projectileStats.stackMaxCount;
        lifespanBase = projectileStats.lifespan;
        spellVfx = projectileStats.spellVfx;
        
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
        stackMaxCount = stackMaxCountBase;
        lifespan = lifespanBase;
    }

}
