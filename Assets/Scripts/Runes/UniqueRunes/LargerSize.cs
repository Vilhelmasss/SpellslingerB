using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargerSize : MonoBehaviour, IRuneInterface
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
        Debug.Log($"Here {go.name}");
        Vector3 scaleChange = new Vector3(1f, 1f, 1f);
        go.transform.localScale += scaleChange;
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