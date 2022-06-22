using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed;
    public LayerMask targetMask = 10;
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No speed");
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == targetMask)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }

    }
     


}
