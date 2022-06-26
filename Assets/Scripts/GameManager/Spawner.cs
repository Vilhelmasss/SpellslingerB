using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyList;

    public List<Transform> spawner;
    public GameObject spawnVfx;

    public GameObject player;

    void Start()
    {
        Wave1();
    }

    void SpawnSimpleCreature()
    {
        Vector3 currentSpawnPosition = spawner[Random.Range(0, 3)].position;
        Instantiate(spawnVfx, currentSpawnPosition, Quaternion.identity);
        GameObject enemy = Instantiate(enemyList[Random.Range(0, 1)], currentSpawnPosition, Quaternion.identity);
        enemy.GetComponent<EnemyNavMeshAI>().movePosTransform = player.transform;
    }

    void SpawnSummoner()
    {

    }

    void Wave1()
    {
        for (int i = 0; i < 3; i++)
        {
            float spawnStart = Random.Range(0f, 3f);
            for (int j = 0; j < Random.Range(0, 2); j++)
            {
                
                Invoke("SpawnSimpleCreature", spawnStart++);
            }

        }
    }

    void Wave2()
    {
        for (int i = 0; i < 3; i++)
        {
            float spawnStart = Random.Range(0f, 3f);
            for (int j = 0; j < Random.Range(0, 10); j++)
            {

                Invoke("SpawnSimpleCreature", spawnStart++);
            }

        }
    }

    void Wave3()
    {
        for (int i = 0; i < 3; i++)
        {
            float spawnStart = Random.Range(0f, 3f);
            for (int j = 0; j < Random.Range(0, 10); j++)
            {

                Invoke("SpawnSimpleCreature", spawnStart++);
            }

        }
    }

    void Wave4()
    {
        for (int i = 0; i < 3; i++)
        {
            float spawnStart = Random.Range(0f, 3f);
            for (int j = 0; j < Random.Range(0, 10); j++)
            {

                Invoke("SpawnSimpleCreature", spawnStart++);
            }

        }
    }



}
