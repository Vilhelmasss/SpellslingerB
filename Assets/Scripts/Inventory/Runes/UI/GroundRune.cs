using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRune : MonoBehaviour
{
    public InvRuneData referenceRune;

    public void OnHandlePickupRune()
    {
        InvRuneSystem.Instance.Add(referenceRune);
        Destroy(this.gameObject);

    }
}
