using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DashBase : MonoBehaviour
{
    private Vector3 mov;
    [SerializeField] private bool shouldDash = false;
    [SerializeField] private bool canMove = true;
    // Dash / Blink
    [SerializeField] private string dashType;

    [SerializeField]
    private SpellDashStats dash;

    public float dashTimeBase;
    public float dashDistanceBase;
    public float cooldownBase;
    public float manaCostBase;
    public float recastTimerMaxBase;
    public int stackMaxCountBase;

    public float dashTime;
    public float dashDistance;
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


    // StartCaroutine OnStart (If Exists)
    // StartCaroutine OnEnd (If Exists)

    void Start()
    {
        AssignToBase(dash);
        AssignFromBase();

        canRecast = true;
        stackCount = stackMaxCount;
        currCooldownTimer = cooldown;
        recastTimer = recastTimerMax;
        
    }

    void Update()
    {
        RechargeCooldown();
        RecastTimer();
        UpdateUI();
        AttemptVD();
        CheckDash();
    }

    void AssignToBase(SpellDashStats dashStats)
    {
        dashTimeBase = dashStats.dashTime;
        dashDistanceBase = dashStats.dashDistance;
        cooldownBase = dashStats.cooldown;
        manaCostBase = dashStats.manaCost;
        recastTimerMax = dashStats.recastTime;
        stackMaxCountBase = dashStats.stackMaxCount;
    }

    void AssignFromBase()
    {
        dashTime = dashTimeBase;
        dashDistance = dashDistanceBase;
        cooldown = cooldownBase;
        manaCost = manaCostBase;
        recastTimer = recastTimerMaxBase;
        stackMaxCount = stackMaxCountBase;
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

    void UpdateUI()
    {
        cd.text = currCooldownTimer.ToString("0.0");
        stacks.text = stackCount.ToString();
    }

    void AddStack(int addedAmount = 1)
    {
        if (stackCount < stackMaxCount)
        {
            stackCount += addedAmount;
        }
    }

    void AttemptVD()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.GetComponent<PlayerController>().CanItMove() && canRecast && stackCount > 0)
            {
                StartCoroutine(VD());
                float horizontal = 0;
                float vertical = 0;
                if (Input.GetKey(KeyCode.A))
                {
                    horizontal -= 1;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    horizontal += 1;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    vertical += 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    vertical -= 1;
                }
                if (horizontal != 0 && vertical != 0)
                {
                    horizontal *= 0.7f;
                    vertical *= 0.7f;
                }
                mov = new Vector3(horizontal * dashDistance, 0, vertical * dashDistance);
                stackCount--;
                currCooldownTimer = cooldown;

            }
        }
    }

    void CheckDash()
    {
        if (shouldDash)
        {
            transform.Translate(mov * gameObject.GetComponent<PlayerController>().movementSpeed * Time.deltaTime, Space.World);
        }
    }

    IEnumerator VD()
    {
        canMove = false;
        shouldDash = true;
        while (true)
        {
            yield return new WaitForSeconds(dashTime);
            canMove = true;
            shouldDash = false;
            yield break;
        }
    }

    void AttemptDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canMove)
            {
                StartCoroutine(StartDash());
                StopCoroutine(StartDash());
            }
        }
    }

    IEnumerator StartDash(float dashTimer = 0.5f)
    {
        canMove = false;
        while (true)
        {
            yield return new WaitForSeconds(dashTimer);
            canMove = true;
            StopCoroutine(StartDash());
        }
    }
}