using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBase : MonoBehaviour
{
    private Vector3 mov;
    [SerializeField] private bool shouldDash = false;
    [SerializeField] private bool canMove = true;

    void Update()
    {
        AttemptVD();
        CheckDash();
    }

    void AttemptVD()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (gameObject.GetComponent<PlayerController>().CanItMove())
            {
                StartCoroutine(VD());
                float horizontal = 0;
                float vertical = 0;
                if (Input.GetKey(KeyCode.A))
                {
                    horizontal -= 1;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    horizontal += 1;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    vertical += 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    vertical -= 1;
                }
                if (horizontal != 0 && vertical != 0)
                {
                    horizontal *= 0.7f;
                    vertical *= 0.7f;
                }
                float moveForce = 4;
                mov = new Vector3(horizontal * moveForce, 0, vertical * moveForce);
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                rb.AddForce(mov, ForceMode.Impulse);
            }
        }
    }

    void CheckDash()
    {
        if (shouldDash)
        {
            transform.Translate(mov * gameObject.GetComponent<PlayerController>().movementSpeed * Time.deltaTime, Space.World);
        }
    }

    IEnumerator VD()
    {
        canMove = false;
        shouldDash = true;
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            canMove = true;
            shouldDash = false;
            yield break;
        }
    }

    void AttemptDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canMove)
            {
                StartCoroutine(StartDash());
                StopCoroutine(StartDash());
            }
        }
    }

    IEnumerator StartDash(float dashTimer = 0.5f)
    {
        canMove = false;
        while (true)
        {
            yield return new WaitForSeconds(dashTimer);
            canMove = true;
            StopCoroutine(StartDash());
        }
    }
}
