using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactChecker : MonoBehaviour
{
    public LayerMask targetLayers;
    public float survivalTimeInCase = 3.5f;
    void Start()
    {
        Destroy(this, survivalTimeInCase);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == targetLayers)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }

    }

}
