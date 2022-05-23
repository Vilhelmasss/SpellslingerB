using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float hitPoints;
    private float mana;
    private float manaRegen;
    private float movSpeed;
    private float manaThreshold;

    private float hitPointsBase = 100f;
    private float manaBase = 100f;
    private float manaRegenBase = 10f;
    private float movSpeedBase ;
    private float manaThresholdBase = 1000f;

    void Start()
    {
        hitPoints = hitPointsBase;
        mana = manaBase;
        manaRegenBase = manaRegen;
        movSpeed = movSpeedBase;
        manaThreshold = manaThresholdBase;
    }
}
