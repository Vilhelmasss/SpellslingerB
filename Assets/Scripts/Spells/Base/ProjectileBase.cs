using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellProjectileBase : MonoBehaviour
{
    public float cooldownBase;
    public float manaCostBase;
    public float recastTimerMaxBase;
    public int stackMaxCountBase;

    public float cooldown;
    public float manaCost;
    public int stackMaxCount;
    public int stackCount;
    public float currCooldownTimer;
    public float recastTimerMax;
    public float recastTimer;
    public bool canRecast;

    public TextMeshProUGUI dashName;
    public TextMeshProUGUI cd;
    public TextMeshProUGUI stacks;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
