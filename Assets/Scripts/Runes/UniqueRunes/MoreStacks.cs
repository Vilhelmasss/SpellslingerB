using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreStacks : MonoBehaviour, IRuneInterface
{
    public GameObject ExecuteAll(GameObject go = null)
    {
        ExecuteAwake(go);
        ExecuteStart(go);
        ExecuteEnd(go);
        return go;
    }


    public GameObject ExecuteAwake(GameObject go = null)
    {

        if (go != null)
        {
            go.GetComponent<SpellBase>().stackMaxCount += 1;
        }

        return go;
    }

    public GameObject ExecuteEnd(GameObject go = null)
    {
        return go;
    }

    public GameObject ExecuteStart(GameObject go = null)
    {
        return go;
    }
}