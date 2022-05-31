using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float hitPoints;

    [SerializeField] private float mana;
    [SerializeField] private float manaRegen;
    private float movSpeed;
    private float manaThreshold;
    private float hitPointsMax;
    private float manaMax;
    
    private float hitPointsBase = 100f;
    private float manaBase = 100f;
    private float manaRegenBase = 20f;
    private float movSpeedBase = 4f;
    private float manaThresholdMaxBase = 300f;

    public bool canTakeDamage;
    public TextMeshProUGUI hitpointsTMP;
    public TextMeshProUGUI manapointsTMP;
    public TextMeshProUGUI thresholdTMP;

    void Start()
    {
        hitPoints = hitPointsBase;
        hitPointsMax = hitPointsBase;
        manaMax = manaBase;
        mana = manaBase;
        manaRegen = manaRegenBase;
        movSpeed = movSpeedBase;
        manaThreshold = 0f;

        UpdateHitpointsUI();
        UpdateManapointsUI();
        UpdateManaThresholdUI();

        gameObject.GetComponent<PlayerController>().movementSpeed = movSpeed;
        canTakeDamage = true;
    }

    void Update()
    {
        RegenerateMana();
        UpdateStatsUI();
    }

    public float GetMana()
    {
        return mana;
    }

    public void TakeDamage(float damage = 0)
    {
        if (canTakeDamage)
        {
            hitPoints -= damage;
        }
    }

    public void RegenerateHealth(float hitpoints = 0)
    {
        hitPoints += hitpoints; 
    }


    public void RegenerateMana()
    {
        mana +=  manaRegen * Time.deltaTime;
        if (mana > manaMax)
        {
            mana = manaMax;
        }
    }

    public void RegenerateMana(float manaCount)
    {
        mana += manaCount;
        if (mana > manaMax)
        {
            mana = manaMax;
        }
        UpdateManapointsUI();
    }

    public void ConsumeMana(float manaCost)
    {
        mana -= manaCost;
        manaThreshold += manaCost;
        CheckThreshold();   
        UpdateManaThresholdUI();
    }

    private void CheckThreshold()
    {
        if (manaThreshold >= manaThresholdMaxBase)
        {
            ReachThreshold();

        }
    }

    public void ReachThreshold()
    {
        manaThreshold = 0f;
        RegenerateMana(25);
    }

    private void UpdateStatsUI()
    {
        UpdateHitpointsUI();
        UpdateManapointsUI();
        UpdateManaThresholdUI();
    }

    public void UpdateManaThresholdUI()
    {
        thresholdTMP.text = $"{manaThreshold.ToString("0"),5} / {manaThresholdMaxBase.ToString("0"),5}";
    }

    public void UpdateHitpointsUI()
    {
        hitpointsTMP.text = $"{hitPoints.ToString("0"), 5} / {hitPointsMax.ToString("0"), 5}";

    }

    public void UpdateManapointsUI()
    {
        manapointsTMP.text = $"{mana.ToString("0"), 5} / {manaMax.ToString("0"), 5}";
    }


}
