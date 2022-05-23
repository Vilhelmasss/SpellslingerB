using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBase : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {
        CheckBasic();
    }

    void CheckBasic()
    {

    }

    void CheckPrimary()
    {

    }

    void CheckDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.GetComponent<PlayerController>().CanItMove())
            {
                
            }
        }
    }

    void CheckUltimate()
    {

    }
    void CheckUtility()
    {

    }

}
