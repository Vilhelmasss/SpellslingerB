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
            if (collision.gameObject.layer == 10)
            {
                Debug.Log($"Found Enemy by {gameObject.name}");
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (collision.gameObject.layer == 11)
            {
                Destroy(gameObject);
            }
//            else if(collision.)
//            {
//                
//            }
        }

    }

//    void OnColliderEnter(Collider other)
//    {
//        Debug.Log(other.gameObject.name);
//    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);
        }
    }


}