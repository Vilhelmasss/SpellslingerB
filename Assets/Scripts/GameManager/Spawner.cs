using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyList;
    public List<GameObject> spawnedEnemy;
    public List<Transform> spawner;
    public GameObject spawnVfx;

    void Wave1()
    {
        for (int i = 0; i < 3; i++)
        {
            float spawnStart = Random.Range(0f, 3f);
            for (int j = 0; j < Random.Range(0, 2); j++)
            {

            }

        }
    }

    void SpawnSimpleCreature()
    {
//        Instantiate()
    }

    void SpawnSummoner()
    {

    }

}
