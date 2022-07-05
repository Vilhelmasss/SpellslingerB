using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMeshAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public LayerMask layerMask;
    public GameObject vfx;
    public Transform movePosTransform;
    public Transform FirePoint;
    public string rangeTester;
    public float maxRange;
    public Vector3 spawnPos;
    public bool navMeshOn = true;
    public float destroyTimeCast = 15f;

    public void FindPlayer()
    {
        navMeshAgent.destination = GM_Main.Instance.Player.transform.position;
    }

    public void InstantiateAttack()
    {
        if (!navMeshOn)
        {
            Vector3 direction = FirePoint.transform.position - gameObject.transform.position;
            GameObject enemySpell = Instantiate(vfx, spawnPos, Quaternion.LookRotation(direction));
            Destroy(enemySpell, destroyTimeCast);
            enemySpell.layer = 8;
            enemySpell.GetComponent<ContactChecker>().targetMask = 6;
        }
        Invoke("InstantiateAttack", 0.5f);
    }

    public void CheckLineOfSightMelee()
    {
        RaycastHit hit;
        layerMask = ~layerMask;
        Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, maxRange, layerMask);
        Debug.Log(hit.collider.gameObject.layer);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 6)
            {
                Debug.Log("Target Acquired");
                navMeshOn = false;
                navMeshAgent.enabled = false;
            }
            else
            {
                Debug.Log("Target Lost");
                navMeshOn = true;
                navMeshAgent.enabled = true;
            }
        }
        else
        {
            Debug.Log("Target Lost");
            navMeshOn = true;
            navMeshAgent.enabled = true;
        }

        Invoke($"CheckLineOfSight", 0.25f);

    }

    public virtual void CheckLineOfSight()
    {
        RaycastHit hit;
        layerMask = 1 << 8;
        layerMask = ~layerMask;

        //        layerMask.value = -641;
        Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, maxRange, layerMask);
        FindSpawnPos();

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 6)
            {
                navMeshOn = false;
                navMeshAgent.enabled = false;

            }
            else
            {
                navMeshOn = true;
                navMeshAgent.enabled = true;
            }
        }
        else
            {
                navMeshOn = true;
                navMeshAgent.enabled = true;
            }
        

        Invoke($"CheckLineOfSight", 0.25f);
            
    }

    public virtual void FindSpawnPos()
    {
        spawnPos = Vector3.zero;
    }
    public void FaceTarget(Vector3 destination)
    {
        transform.LookAt(movePosTransform.position);
    }
}