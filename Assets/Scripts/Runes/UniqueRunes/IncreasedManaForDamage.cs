using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasedManaForDamage : MonoBehaviour, IRuneInterface
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
        go.GetComponent<SpellBase>().manaCost -= go.GetComponent<SpellBase>().manaCostBase* 0.2f;
        go.GetComponent<SpellBase>().damageMod += go.GetComponent<SpellBase>().damageModBase * 0.1f;
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