using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicBase : MonoBehaviour
{
    public SpellProjectileStats projectileStats;
    public SpellProjectileStats basicProjectileStats;
    public GameObject basicKeeper;

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
                gameObject.AddComponent<SpellProjectileBase>();
                ProjectileBaseStart(basicProjectileStats);
                break;
            default:
                Debug.Log("Didn't find the base");
                break;
        }
        gameObject.GetComponent<SpellBase>().AssignToZero();
        gameObject.GetComponent<SpellBase>().AssignToBase();
        gameObject.GetComponent<SpellBase>().AssignFromBase();
        gameObject.GetComponent<SpellBase>().AdjustForRunes(gameObject);
        InitializeTMP();
    }

    void Update()
    {
        Invoke($"{spellBase}Call", 0f);
    }

    private void UpdateTMP()
    {
        cd.text = gameObject.GetComponent<SpellBase>().currCooldownTimer.ToString("0.0");
        stacks.text = gameObject.GetComponent<SpellBase>().stackCount.ToString();
    }

    private void InitializeTMP()
    {
        basicName.text = gameObject.GetComponent<SpellBase>().basicName;
        cd.text = gameObject.GetComponent<SpellBase>().currCooldownTimer.ToString("0.0");
        stacks.text = gameObject.GetComponent<SpellBase>().stackCount.ToString();
    }

    public void ProjectileBaseStart(SpellProjectileStats _projectileStats)
    {
        gameObject.GetComponent<SpellBase>().GetSpellStats(_projectileStats);
    }

    void ProjectileCall()
    {
        gameObject.GetComponent<SpellBase>().Update();
        UpdateTMP();
        if (gameObject.GetComponent<SpellBase>().AttemptCasting())
        {
            if (gameObject.GetComponent<PlayerStats>().GetMana() >= gameObject.GetComponent<SpellBase>().manaCost)
            {
                gameObject.GetComponent<SpellBase>().CastSpell(gameObject, FirePoint);
                gameObject.GetComponent<PlayerStats>().ConsumeMana(gameObject.GetComponent<SpellBase>().manaCost);
            }
        }
    }
}
