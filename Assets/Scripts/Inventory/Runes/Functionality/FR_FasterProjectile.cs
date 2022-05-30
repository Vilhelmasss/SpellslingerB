using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FR_FasterProjectile : MonoBehaviour
{
//    public static FR_FasterProjectile Instance { get; private set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ProjectileSpeed()
    {
        Debug.Log("Access to FR_FasterProjectile");
    }

    public T GenericMethod<T>(T param)
    {
        return param;
    }
}
