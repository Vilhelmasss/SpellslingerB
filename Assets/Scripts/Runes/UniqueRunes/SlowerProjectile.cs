using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerProjectile : MonoBehaviour, IRuneInterface
{
    public GameObject ExecuteAll(GameObject go = null)
    {
        return null;
    }

    public GameObject ExecuteAwake(GameObject go = null)
    {
        if (go != null)
        {
            go.GetComponent<SpellBase>().speed *= 0.7f;
            go.GetComponent<SpellBase>().damageMod +=
            go.GetComponent<SpellBase>().damageModBase * 0.3f;
        }

        return go;
    }

    public GameObject ExecuteEnd(GameObject go = null)
    {
        return null;
    }

    public GameObject ExecuteStart(GameObject go = null)
    {
        return null;
    }
}
