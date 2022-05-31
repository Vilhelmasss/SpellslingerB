using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FasterProjectile : MonoBehaviour, IRuneInterface
{

    public GameObject ExecuteAwake(GameObject go)
    {
        Debug.Log("prenull");
        if (go != null)
        {
            Debug.Log("!null");
            go.GetComponent<SpellBase>().speed *= 1.5f;
        }

        return go;
    }

    public GameObject ExecuteStart(GameObject go)
    {
        return null;
    }
    public GameObject ExecuteEnd(GameObject go)
    {
        Debug.Log("Piss");
        return null;
    }

    public GameObject ExecuteAll(GameObject go)
    {
        ExecuteAwake(go);
        ExecuteStart(go);
        ExecuteEnd(go);
        return go;

    }


}
