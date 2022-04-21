using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Rune")
        {
            other.gameObject.GetComponent<GroundRune>().OnHandlePickupRune();
        }
        else if (other.tag == "SpellPick")
        {
            other.gameObject.GetComponent<GroundSpell>().OnHandlePickupRune();

        }
    }
}