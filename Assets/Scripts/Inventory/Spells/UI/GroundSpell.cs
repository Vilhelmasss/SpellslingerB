using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpell : MonoBehaviour
{
    public InvSpellData referenceSpell;

    public void OnHandlePickupRune()
    {
        InvSpellSystem.Instance.Add(referenceSpell);
        Destroy(this.gameObject);

    }
}
