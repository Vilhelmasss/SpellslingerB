using UnityEngine;

public class ContactChecker : MonoBehaviour
{
    public LayerMask targetMask;
    public float survivalTimeInCase = 1f;
    void Start()
    {
        Debug.Log("what");
        Destroy(gameObject, survivalTimeInCase);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (targetMask != 0)
        {
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

}