using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public bool canMove = true;
    public bool canRotate = true;
    public Rigidbody rb;
    public float movementSpeed;
    public Quaternion targetRotation;

    void Start()
    {
        movementSpeed = 5f;
        rb = gameObject.GetComponent<Rigidbody>();
        canMove = true;
    }

    void FixedUpdate()
    {
        Movement();

        Rotation();
    }

    private void Rotation()
    {
        if (canRotate)
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitDist = 0f;
            if (playerPlane.Raycast(ray, out hitDist))
            {
                Vector3 targetPoint = ray.GetPoint(hitDist);
                targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.fixedDeltaTime);
            }
        }
    }

    private void Movement()
    {
        if (canMove)
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            rb.MovePosition(transform.position + direction * movementSpeed * Time.fixedDeltaTime);
        }
    }


    private void PlayerSpeedChange(float speedChange, float duration, bool itCasted = true)
    {
        // movementSpeed += speedChange;

    }

}
