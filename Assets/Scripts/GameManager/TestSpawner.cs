using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform spawner;
    public Transform spawner2;
    public GameObject spawnVfx;
    public GameObject player;
    public KeyCode summonIdles1;
    public KeyCode summonIdles2;
    private float summonDelay = 0f;



    void Update()
    {
        if (Input.GetKeyDown(summonIdles1))
        {
            SpawnBunch1();
        }
    }

    void SpawnSimpleCreature()
    {
        Vector3 currentSpawnPosition = spawner.position;
        Vector3 newSpawn = new Vector3(currentSpawnPosition.x + Random.Range(-3f, 3f), 5f, currentSpawnPosition.z + Random.Range(-3f, 3f));

        if (spawnVfx != null)
        {
            Instantiate(spawnVfx, newSpawn, Quaternion.identity);
        }
        GameObject enemy = Instantiate(this.enemy, newSpawn, Quaternion.identity);
    }

    void SpawnBunch1()
    {
        summonDelay = 0f;
        for (int i = 0; i < 10; i++)
        {
            Invoke("SpawnSimpleCreature", summonDelay);
            summonDelay += 0.2f;

        }
    }

    void SpawnBunch2()
    {
        summonDelay = 0f;
        for (int i = 0; i < 10; i++)
        {
            Invoke("SpawnSimpleCreature", summonDelay);
            summonDelay += 0.2f;

        }
    }



}
