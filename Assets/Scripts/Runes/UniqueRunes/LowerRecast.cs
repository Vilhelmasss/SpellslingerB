using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerRecast : MonoBehaviour, IRuneInterface
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
        go.GetComponent<SpellBase>().recastTimerMax -= go.GetComponent<SpellBase>().recastTimerMaxBase * 0.3f;
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