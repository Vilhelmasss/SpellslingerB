using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRanged : EnemyNavMeshAI
{
    // Start is called before the first frame update
    private void Awake()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        Invoke($"CheckLineOfSight", 0.25f);
        InstantiateAttack();
        destroyTimeCast = 10f;
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
        spawnPos = FirePoint.transform.position + Vector3.up * 0.5f;
    }
}
