using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicBase : MonoBehaviour
{
    public SpellProjectileStats basicProjectileStats;
    public GameObject player;
    public KeyCode keycode = KeyCode.Mouse0;
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
                Debug.Log("hah");
                break;
            default:
                Debug.Log("Didn't find the base");
                break;
        }

        gameObject.GetComponent<SpellBase>().keyCode = KeyCode.Mouse0;
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

    public void InitializeTMP()
    {
        basicName.text = gameObject.GetComponent<SpellBase>().basicName;
        cd.text = gameObject.GetComponent<SpellBase>().currCooldownTimer.ToString("0.0");
        stacks.text = gameObject.GetComponent<SpellBase>().stackCount.ToString();
    }

    public void ProjectileBaseStart(SpellProjectileStats _projectileStats)
    {
        gameObject.GetComponent<SpellBase>().GetSpellStats(_projectileStats);
        gameObject.GetComponent<SpellBase>().basicName = _projectileStats.spellName;
    }

    void ProjectileCall()
    {
        gameObject.GetComponent<SpellBase>().Update();
        UpdateTMP();
        if (gameObject.GetComponent<SpellBase>().AttemptCasting())
        {
            if (player.GetComponent<PlayerStats>().GetMana() >= gameObject.GetComponent<SpellBase>().manaCost)
            {
                gameObject.GetComponent<SpellBase>().CastSpell(gameObject, FirePoint);
                player.GetComponent<PlayerStats>().ConsumeMana(gameObject.GetComponent<SpellBase>().manaCost);
            }
        }
    }
}
