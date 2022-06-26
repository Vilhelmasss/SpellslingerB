using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrimaryBase : MonoBehaviour
{
    public SpellCursorStats primaryCursorStats;
    public GameObject player;
    public GameObject primaryKeeper;

    public GameObject FirePoint;


    public TextMeshProUGUI basicName;
    public TextMeshProUGUI cd;
    public TextMeshProUGUI stacks;

    public string spellBase = "Projectile";
    void Start()
    {
        switch (spellBase)
        {
            case "Cursor":
                primaryKeeper.AddComponent<SpellCursorBase>();
                CursorBaseStart(primaryCursorStats);
                break;
            default:
                Debug.Log("Didn't find the base");
                break;
        }

        gameObject.GetComponent<SpellBase>().keyCode = KeyCode.Q;

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

    public void CursorBaseStart(SpellCursorStats _cursorStats)
    {
        gameObject.GetComponent<SpellBase>().GetSpellStats(_cursorStats);
    }

    void CursorCall()
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