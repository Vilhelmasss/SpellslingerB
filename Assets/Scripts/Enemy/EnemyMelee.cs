using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : EnemyNavMeshAI
{

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        movePosTransform = GM_Main.Instance.Player.transform;
    }
    void Start()
    {
        Invoke($"CheckLineOfSight", 0.25f);
        InstantiateAttack();
        destroyTimeCast = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshOn)
        {
            if(movePosTransform != null)
            navMeshAgent.destination = movePosTransform.position;
        }
        else
        {
            FaceTarget(movePosTransform.position);
        }
    }

    public override void FindSpawnPos()
    {
        spawnPos = new Vector3(FirePoint.position.x, FirePoint.position.y - 0.8f, FirePoint.position.z);
    }
}
