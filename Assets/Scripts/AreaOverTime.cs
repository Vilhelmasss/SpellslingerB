using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOverTime : MonoBehaviour
{
    private float timer = 0f;
    private float maxTimer = 1f;
    private bool dealDamage = false;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0f;
            dealDamage = true;  
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (dealDamage)
        {
            dealDamage = false;
            if (other.gameObject.layer == 10)
            {
                Debug.Log("Enemy Found");
                // deal damage
            }
        }
    }
}
