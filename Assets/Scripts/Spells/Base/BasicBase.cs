using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicBase : MonoBehaviour
{
    public SpellProjectileBase basicProjectileBase;
    public SpellProjectileStats basicProjectileStats;

    public GameObject FirePoint;

    public TextMeshProUGUI basicName;
    public TextMeshProUGUI cd;
    public TextMeshProUGUI stacks;

    public string spellBase = "Projectile";
    void Start()
    {
        switch (spellBase)
        {
            case "Projectile":
                ProjectileBaseStart(basicProjectileStats);
                basicProjectileBase.AssignToZero();
                basicProjectileBase.AssignToBase();
                basicProjectileBase.AssignFromBase();
                InitializeTMP();
                break;
            default:
                Debug.Log("Didn't find the base");
                break;
        }
    }

    void Update()
    {
        Invoke($"{spellBase}Call", 0f);
    }

    private void UpdateTMP()
    {
        cd.text = basicProjectileBase.currCooldownTimer.ToString("0.0");
        stacks.text = basicProjectileBase.stackCount.ToString();
    }

    private void InitializeTMP()
    {
        basicName.text = basicProjectileBase.projectileStats.basicName;
        cd.text = basicProjectileBase.currCooldownTimer.ToString("0.0");
        stacks.text = basicProjectileBase.stackCount.ToString();
    }

    public void ProjectileBaseStart(SpellProjectileStats projectileStats)
    {
        basicProjectileBase.projectileStats = projectileStats;
    }

    void ProjectileCall()
    {
        basicProjectileBase.Update();
        UpdateTMP();
        if (basicProjectileBase.AttemptCasting())
        {
            if (gameObject.GetComponent<PlayerStats>().GetMana() >= basicProjectileBase.manaCost)
            {
                basicProjectileBase.CastProjectile(gameObject, FirePoint);
                gameObject.GetComponent<PlayerStats>().ConsumeMana(basicProjectileBase.manaCost);
            }
        }
    }
}
