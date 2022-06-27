using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySummoner : EnemyNavMeshAI
{
    private Vector3 startingPosition;
    private Vector3 destination;
    [SerializeField] private List<GameObject> enemyList;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        startingPosition = gameObject.transform.position;
        destination = startingPosition;
        WalkToRandomPosition();
        FaceTarget(movePosTransform.position);
        Invoke("SpawnMinion", 5f);
    }


    void Update()
    {
        if (navMeshOn)
        {
            navMeshAgent.destination = destination;
        }
        FaceTarget(movePosTransform.position);

    }

    void SpawnMinion()
    {
        for (int i = 0; i < 10; i++)
        {
            int randomEnemy = Random.Range(0, 2);
            Vector3 newEnemySpawnPoint = new Vector3(gameObject.transform.position.x + Random.Range(-5f, 5f),
                gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-5f, 5f));
            GameObject spawnedEnemy = Instantiate(enemyList[randomEnemy], newEnemySpawnPoint, Quaternion.identity);
            Destroy(spawnedEnemy, 30f);
        }
        Invoke("SpawnMinion", 30f);
    }

    void WalkToRandomPosition()
    {
        destination = new Vector3(startingPosition.x + Random.Range(-5f, 5f), startingPosition.y, startingPosition.z + Random.Range(-5f, 5f));
        Invoke("WalkToRandomPosition", 5f);
    }

}
