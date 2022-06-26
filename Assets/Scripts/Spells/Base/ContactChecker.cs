using UnityEngine;

public class ContactChecker : MonoBehaviour
{
    public LayerMask targetMask;
    public float survivalTimeInCase = 3.5f;
    void Start()
    {
        Destroy(this, survivalTimeInCase);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(targetMask != null)
        if (collision.gameObject.layer == targetMask)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }

    }

}