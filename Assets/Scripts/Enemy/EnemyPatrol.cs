using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Transform> MoveToNext;
    private NavMeshAgent navAgent;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
//        if(MoveToNext[0] != null)
//        FindNewSpot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindNewSpot()
    {
        int nextTarget = Random.Range(0, MoveToNext.Count);
        navAgent.destination = MoveToNext[nextTarget].position;
        Invoke("FindNewSpot", Random.Range(5f, 10f));
    }
}
